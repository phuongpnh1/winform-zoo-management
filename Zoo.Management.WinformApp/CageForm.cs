using Entities.Helper;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zoo.Management.WinformApp
{
    public partial class CageForm : Form
    {
        private readonly CageRepository _cageRepository;
        private readonly AreaRepository _areaRepository;

        public CageForm()
        {
            InitializeComponent();
            _cageRepository = new CageRepository();
            _areaRepository = new AreaRepository();

            GetDataForDataGridView();

            instantiateDataForCbBox();
        }

        private void dgvListCage_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (btnDeletedCages.Enabled)
                {
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                    btnClear.Enabled = true;
                    btnCreate.Enabled = false;
                    btnRecover.Enabled = false;
                }
                else
                {
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    btnClear.Enabled = false;
                    btnCreate.Enabled = false;
                    btnRecover.Enabled = true;
                }

                var row = dgvListCage.Rows[e.RowIndex];
                txtId.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                cbArea.Text = row.Cells[2].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            btnCreate.Enabled = false;
            try
            {
                var cageName = txtName.Text;
                var hadCage = _cageRepository.GetAll().Where(e => e.CageName.Equals(cageName)).FirstOrDefault();
                if (hadCage != null)
                {
                    MessageBox.Show("Cage already exist!", "Warn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var area = cbArea.SelectedItem as Area;

                if (area is null)
                {
                    MessageBox.Show("Please choose area!", "Warn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                };

                var newCage = new Cage()
                {
                    CageName = cageName,
                    AreaId = area.Id,
                };

                if (!CheckValidation(newCage)) return;

                await _cageRepository.AddAsync(newCage);
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
                if (id <= 0) return;

                var cage = _cageRepository.GetAll().Where(c => c.Id == id && !c.IsDeleted).FirstOrDefault();
                if (cage is null)
                {
                    MessageBox.Show("Cage is not found. Can not update!");
                    btnUpdate.Enabled = true;
                    return;
                }

                var area = cbArea.SelectedItem as Area;
                if (area is null)
                {
                    MessageBox.Show("Please choose area!", "Warn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnUpdate.Enabled = true;
                    return;
                };

                var hadCage = _cageRepository.GetAll().Where(e => e.CageName.Equals(txtName.Text) && e.Id != cage.Id).FirstOrDefault();
                if (hadCage != null)
                {
                    MessageBox.Show("Duplicate name!", "Warn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnUpdate.Enabled = true;
                    return;
                }
                cage.CageName = txtName.Text;
                cage.AreaId = area.Id;

                if (!CheckValidation(cage))
                {
                    btnUpdate.Enabled = true;
                    return;
                }
                await _cageRepository.UpdateAsync(cage);

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

                var deleteCage = new Cage();

                var cageName = txtName.Text;
                var area = cbArea.SelectedItem as Area;

                if (cageName == "" && area is null)
                {
                    deleteCage = _cageRepository.GetAll().Where(c => c.Id == id).FirstOrDefault();
                }
                else
                {
                    if (area is null)
                    {
                        MessageBox.Show("Please choose area");
                        btnDelete.Enabled = true;
                        return;
                    }
                    deleteCage = _cageRepository.GetAll().Where(c => c.Id == id
                                                                && c.CageName == cageName
                                                                && c.AreaId == area.Id).FirstOrDefault();
                }

                if (deleteCage is null)
                {
                    MessageBox.Show("Cage is not found. Can not delete!");
                    btnDelete.Enabled = true;
                    return;
                }
                if (deleteCage.IsDeleted)
                {
                    MessageBox.Show("Cage is deleted. Can not delete again!");
                    btnDelete.Enabled = true;
                    return;
                }

                deleteCage.IsDeleted = true;

                await _cageRepository.UpdateAsync(deleteCage);

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

        private void btnClear_Click(object sender, EventArgs e)
        {
            btnClear.Enabled = false;

            ClearText();

            btnClear.Enabled = true;
            btnCreate.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnCurrentCages_Click(object sender, EventArgs e)
        {
            disableReadOnlyForAll();
            ClearText();

            btnCreate.Enabled = true;
            btnClear.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnRecover.Enabled = false;

            btnDeletedCages.Enabled = true;
            btnCurrentCages.Enabled = false;

            GetDataForDataGridView();
        }

        private void btnDeletedCages_Click(object sender, EventArgs e)
        {
            ClearText();

            btnRecover.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnCreate.Enabled = false;
            btnClear.Enabled = false;

            btnDeletedCages.Enabled = false;
            btnCurrentCages.Enabled = true;

            setReadOnlyForAll();

            try
            {

                var cageList = _cageRepository.GetAll().Where(c => c.IsDeleted).Include(c => c.Area).ToList();
                if (cageList.Count == 0 || cageList is null)
                {
                    dgvListCage.DataSource = null;
                    return;
                }
                if (cageList.Count > 0 && cageList is not null)
                {
                    dgvListCage.DataSource = cageList.Select(c => new
                    {
                        id = c.Id,
                        Name = c.CageName,
                        Area = c.Area?.Name,
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnRecover_Click(object sender, EventArgs e)
        {
            try
            {
                btnRecover.Enabled = false;

                var id = CheckValidId();
                if (id <= 0) return;

                var cage = _cageRepository.GetAll().Where(c => c.Id == id).FirstOrDefault();
                if (cage is null)
                {
                    MessageBox.Show("Cage is not found. Can not recover!");
                    return;
                }
                if (!cage.IsDeleted)
                {
                    MessageBox.Show("Cage is recovered. Can not recover!");
                    return;
                }

                cage.IsDeleted = false;

                if (!CheckValidation(cage))
                {
                    return;
                }
                await _cageRepository.UpdateAsync(cage);

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
                btnClear.Enabled = true;
                btnCurrentCages.Enabled = true;
                btnDeletedCages.Enabled = false;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;

                btnCurrentCages.Enabled = false;
                btnDeletedCages.Enabled = true;
                disableReadOnlyForAll();
            }
        }

        private void ClearText()
        {
            txtId.Text = "";
            txtName.Text = "";
            btnCreate.Enabled = true;
        }

        private void GetDataForDataGridView()
        {
            try
            {
                var cageList = _cageRepository.GetAll().Where(c => !c.IsDeleted).Include(c => c.Area).ToList();
                if (cageList.Count > 0 && cageList is not null)
                {
                    dgvListCage.DataSource = cageList.Select(c => new
                    {
                        id = c.Id,
                        Name = c.CageName,
                        Area = c.Area?.Name,
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private bool CheckValidation(Cage cage)
        {
            CageValidationHelper validator = new();
            var result = validator.Validate(cage);

            if (!result.IsValid)
            {
                var errorsMessage = result.ToString("\n");
                MessageBox.Show(errorsMessage);
                return false;
            }
            return true;
        }

        private void setReadOnlyForAll()
        {
            txtId.ReadOnly = true;
            txtName.ReadOnly = true;
            cbArea.Enabled = false;
        }

        private void disableReadOnlyForAll()
        {
            txtName.ReadOnly = false;
            cbArea.Enabled = true;
        }

        private void instantiateDataForCbBox()
        {
            try
            {
                var areaList = _areaRepository.GetAll().Where(a => !a.IsDeleted).ToList();
                if (areaList is not null && areaList.Count > 0)
                {
                    cbArea.DataSource = areaList;
                    cbArea.DisplayMember = "Name";
                    cbArea.ValueMember = "Id";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
