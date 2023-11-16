using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities.Helper;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Zoo.Management.WinformApp
{
    public partial class AreaForm : Form
    {

        private readonly AreaRepository _areaRepository;
        public AreaForm()
        {
            InitializeComponent();

            _areaRepository = new AreaRepository();

            GetDataForDataGridView();

            txtId.ReadOnly = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnCurrentArea.Enabled = false;

        }

        private void dgvArea_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnRecovery.Visible != true)
            {
                btnCreate.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
            btnRecovery.Enabled = true;

            var row = dgvArea.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtName.Text = row.Cells[1].Value.ToString();

        }
        private bool CheckValidation(Area area)
        {
            AreaValidationHelper validator = new();
            var result = validator.Validate(area);

            if (!result.IsValid)
            {
                var errorsMessage = result.ToString("\n");
                MessageBox.Show(errorsMessage);
                return false;
            }
            return true;
        }
        private int CheckValidId()
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Id must be integer");
                return -1;
            }
            if (txtId.Text == "0")
            {
                MessageBox.Show("Id must be positive");
                return 0;
            }
            return id;
        }
        private void ClearText()
        {
            txtId.Text = "";
            txtName.Text = "";
        }

        private void GetDataForDataGridView()
        {
            var areaList = _areaRepository.GetAll().Where(c => !c.IsDeleted).Include(c => c.Cages).ToList();
            if (areaList.Count > 0 && areaList is not null)
            {
                dgvArea.DataSource = areaList.Select(c => new
                {
                    id = c.Id,
                    Name = c.Name,
                }).ToList();
            }
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            btnCreate.Enabled = false;

            try
            {
                var hadArea = _areaRepository.GetAll().Where(e => e.Name.Equals(txtName.Text)).FirstOrDefault();
                if (hadArea != null)
                {
                    MessageBox.Show("Area already exist!", "Warn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var areaName = txtName.Text;


                var newArea = new Area()
                {
                    Name = areaName,
                };

                if (!CheckValidation(newArea)) return;

                await _areaRepository.AddAsync(newArea);
                GetDataForDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ClearText();
                btnCreate.Enabled = true;
            }
        }
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                btnUpdate.Enabled = false;

                var id = CheckValidId();
                var hadArea = _areaRepository.GetAll().Where(e => e.Name.Equals(txtName.Text) && e.Id != id).FirstOrDefault();
                if (hadArea != null)
                {
                    MessageBox.Show("Area already exist!", "Warn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnCreate.Enabled = true;
                    return;
                }
                if (id <= 0) return;

                var area = _areaRepository.GetAll().Where(c => c.Id == id && !c.IsDeleted).FirstOrDefault();
                if (area is null)
                {
                    MessageBox.Show("Area is not found. Can not update!");
                    btnUpdate.Enabled = true;
                    return;
                }

                area.Name = txtName.Text;

                if (!CheckValidation(area))
                {
                    btnUpdate.Enabled = true;
                    return;
                }
                await _areaRepository.UpdateAsync(area);


                GetDataForDataGridView();

                ClearText();
                btnCreate.Enabled = true;
                btnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                btnUpdate.Enabled = true;
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                btnDelete.Enabled = false;

                var id = CheckValidId();
                if (id <= 0) return;

                var deleteArea = new Area();

                var name = txtName.Text;


                if (name == "")
                {
                    deleteArea = _areaRepository.GetAll().Where(c => c.Id == id).FirstOrDefault();
                }
                else
                {

                    deleteArea = _areaRepository.GetAll().Where(c => c.Id == id
                                                                && c.Name == name).FirstOrDefault();
                }

                if (deleteArea is null)
                {
                    MessageBox.Show("Area is not found. Can not delete!");
                    btnDelete.Enabled = true;
                    return;
                }
                if (deleteArea.IsDeleted)
                {
                    MessageBox.Show("Area is deleted. Can not delete again!");
                    btnDelete.Enabled = true;
                    return;
                }

                deleteArea.IsDeleted = true;

                await _areaRepository.UpdateAsync(deleteArea);

                GetDataForDataGridView();

                ClearText();
                btnCreate.Enabled = true;
                btnUpdate.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                btnDelete.Enabled = true;
            }
        }

        private void btnCurrentArea_Click(object sender, EventArgs e)
        {
            btnDeletedArea.Enabled = true;
            btnCurrentArea.Enabled = false;

            btnCreate.Enabled = true;

            btnCreate.Visible = true;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;

            btnRecovery.Enabled = false;
            btnRecovery.Visible = false;
            GetDataForDataGridView();
        }
        private Area GetCurrentArea()
        {
            var id = txtId.Text;


            var currentArea = new Area()
            {
                Id = int.Parse(id),
                IsDeleted = false
            };
            return currentArea;
        }
        private async void btnRecovery_Click(object sender, EventArgs e)
        {
            var area = GetCurrentArea();
            var isRecovered = await _areaRepository.RecoveryUserAsync(area);
            EmptyBoxes();
            if (isRecovered)
            {
                MessageBox.Show("Recovered");
            }
            else
            {
                MessageBox.Show("Recover failed!");
            }
            btnCreate.Enabled = true;
            btnRecovery.Enabled = false;
            btnRecovery.Visible = false;
            btnDeletedArea.Enabled = true;
            btnCurrentArea.Enabled = false;
            btnDelete.Visible = true;
            btnCreate.Visible = true;
            btnUpdate.Visible = true;
            GetDataForDataGridView();

        }
        private void EmptyBoxes()
        {
            txtId.Text = String.Empty;
            txtName.Text = String.Empty;
        }
        private void ShowListOfDeletedArea()
        {
            var listArea = _areaRepository.GetAll().AsNoTracking()
                                .Where(a => a.IsDeleted == true)
                                .Select(a => new
                                {
                                    Id = a.Id,
                                    Name = a.Name
                                }).ToList();


            dgvArea.DataSource = listArea;

        }

        private void btnDeletedArea_Click(object sender, EventArgs e)
        {
            btnCurrentArea.Enabled = true;
            btnDeletedArea.Enabled = false;

            btnCreate.Visible = false;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;

            btnRecovery.Enabled = false;
            btnRecovery.Visible = true;
            ShowListOfDeletedArea();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            EmptyBoxes();
            btnCreate.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
    }
}
