using Entities.Helper;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class AnimalForm : Form
    {
        private readonly AnimalRepository _animalRepository;
        private readonly CageRepository _cageRepository;
        private List<Animal> _animals = new List<Animal>();
        public AnimalForm()
        {
            _animalRepository = new AnimalRepository();
            _cageRepository = new CageRepository();
            InitializeComponent();

            ShowListOfAnimal();

            var cage = _cageRepository.GetAll();
            var listCage = new List<Cage>();

            listCage = cage.ToList();

            listCage.Insert(0, new Cage { Id = 0, CageName = "Select Cage" });
            cbCage.DataSource = listCage;
            cbCage.DisplayMember = "CageName";
            cbCage.ValueMember = "Id";

            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnCurrentAnimal.Enabled = false;

        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            btnCreate.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            var animalName = txtAnimalName.Text;
            var hadAnimal = _animalRepository.GetAll().Where(e => e.AnimalName.Equals(animalName)).FirstOrDefault();
            if (hadAnimal != null)
            {
                MessageBox.Show("Animal existed!");
                return;
            }
            var animalSpecies = txtSpecies.Text;

            var isValidAge = int.TryParse(txtAge.Text, out int age);


            if (cbCage.SelectedItem == null)
            {
                MessageBox.Show("Please select the cage for Animal");
                btnCreate.Enabled = true;
                return;
            }

            Cage? cage = cbCage.SelectedItem as Cage;

            if (cage == null)
            {
                MessageBox.Show("The cage can not be null!");
                return;
            }

            Animal animal = new Animal()
            {
                AnimalName = animalName,
                Species = animalSpecies,
                Age = age,
                CageId = cage.Id
            };

            AnimalValidationHelper validator = new();
            var result = validator.Validate(animal);

            if (!result.IsValid)
            {
                var errorsMessage = result.ToString("\n");
                MessageBox.Show(errorsMessage);
                btnCreate.Enabled = true;
                return;
            }

            await _animalRepository.AddAsync(animal);

            this.ShowListOfAnimal();
            btnCreate.Enabled = true;
            this.ClearTextBox();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;
            var id = int.Parse(txtID.Text);
            var animalName = txtAnimalName.Text;
            var animalSpecies = txtSpecies.Text;
            var hadAnimal = _animalRepository.GetAll().Where(e => e.AnimalName.Equals(animalName) && e.Id != id).FirstOrDefault();
            if (hadAnimal != null)
            {
                MessageBox.Show("Animal name duplicate!");
                btnUpdate.Enabled = true;
                return;
            }

            var isValidAge = int.TryParse(txtAge.Text, out int age);
            var animalUpdate = await _animalRepository.GetByIdAsync(id);
            if (animalUpdate is null)
            {
                MessageBox.Show("The animal does not exist!!");
                btnUpdate.Enabled = true;

                return;
            }

            if (cbCage.SelectedItem == null)
            {
                MessageBox.Show("Please select the cage for Animal");
                btnUpdate.Enabled = true;
                return;
            }

            Cage cage = (Cage)cbCage.SelectedItem;

            animalUpdate.CageId = cage.Id;
            animalUpdate.Age = age;
            animalUpdate.Species = animalSpecies;
            animalUpdate.AnimalName = animalName;

            AnimalValidationHelper validator = new();
            var result = validator.Validate(animalUpdate);

            if (!result.IsValid)
            {
                var errorsMessage = result.ToString("\n");
                MessageBox.Show(errorsMessage);
                btnUpdate.Enabled = true;
                return;
            }

            await _animalRepository.UpdateAsync(animalUpdate);

            MessageBox.Show("Updated");

            this.ShowListOfAnimal();
            this.ClearTextBox();
            btnUpdate.Enabled = false;
            btnCreate.Enabled = true;
            btnDelete.Enabled = false;
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            btnCreate.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            var IsValidId = int.TryParse(txtID.Text, out int id);
            if (IsValidId == false)
            {
                MessageBox.Show("ID is not valid");
                btnDelete.Enabled = true;
                return;
            }

            var animal = _animalRepository.GetAll().Where(a => a.Id == id).FirstOrDefault();
            if (animal == null)
            {
                MessageBox.Show("Animal is not exist");
                btnDelete.Enabled = true;
                return;
            }

            var isDeleted = await _animalRepository.DeleteUserAsync(animal);
            if (isDeleted)
            {
                MessageBox.Show("Deleted");
            }
            else
            {
                MessageBox.Show("Delete failed!");
            }

            this.ShowListOfAnimal();

            this.ClearTextBox();

        }

        private void dgvAnimal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnCreate.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnRecovery.Enabled = true;

            var data = dgvAnimal.Rows[e.RowIndex].Cells;

            txtID.Text = data[0].Value.ToString();
            txtAnimalName.Text = data[1].Value.ToString();
            txtSpecies.Text = data[2].Value.ToString();
            txtAge.Text = data[3].Value.ToString();
            cbCage.Text = data[4].Value.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var searchString = txtSearch.Text;
            Search(searchString);
        }

        private void btnCurrentAnimal_Click(object sender, EventArgs e)
        {
            ClearTextBox();
            btnDeletedAnimal.Enabled = true;
            btnCurrentAnimal.Enabled = false;

            btnCreate.Enabled = true;

            btnCreate.Visible = true;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;

            btnRecovery.Enabled = false;
            btnRecovery.Visible = false;
            btnClear.Visible = true;
            ShowListOfAnimal();
        }

        private void btnDeletedAnimal_Click(object sender, EventArgs e)
        {
            ClearTextBox();
            btnCurrentAnimal.Enabled = true;
            btnDeletedAnimal.Enabled = false;

            btnCreate.Visible = false;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;

            btnRecovery.Enabled = false;
            btnRecovery.Visible = true;
            btnClear.Visible = false;
            ShowListOfDeleteAnimal();
        }

        private async void btnRecovery_Click(object sender, EventArgs e)
        {
            var animal = GetCurrentAnimal();
            var isRecovered = await _animalRepository.RecoveryUserAsync(animal);
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
            btnDeletedAnimal.Enabled = true;
            btnCurrentAnimal.Enabled = false;

            btnCreate.Visible = true;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            btnClear.Visible = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            ShowListOfAnimal();
        }

        private void Search(string searchString)
        {

            if (btnRecovery.Visible == false)
            {
                _animals = _animalRepository.GetAll().
                                   Where(a => a.IsDelete == false
                                   && a.AnimalName.Contains(searchString))
                                   .Include(p => p.Cage)
                                   .AsNoTracking().ToList();
            }
            if (btnRecovery.Visible == true)
            {
                _animals = _animalRepository.GetAll().
                                    Where(a => a.IsDelete == true
                                    && a.AnimalName.Contains(searchString))
                                    .Include(p => p.Cage)
                                    .AsNoTracking().ToList();
            }

            dgvAnimal.DataSource = _animals.Select(a => new
            {
                Id = a.Id,
                Name = a.AnimalName,
                Species = a.Species,
                Age = a.Age,
                Cage = a.Cage.CageName
            }).ToList();

        }

        private Animal GetCurrentAnimal()
        {
            var id = txtID.Text;
            var animalName = txtAnimalName.Text;
            var species = txtSpecies.Text;
            var age = txtAge.Text;
            var cage = cbCage.SelectedItem as Cage;

            var currentAnimal = new Animal()
            {
                Id = int.Parse(id),
                AnimalName = animalName,
                Species = species,
                Age = int.Parse(age),
                Cage = cage,
                IsDelete = false
            };
            return currentAnimal;
        }

        private void ShowListOfAnimal()
        {
            var listAnimal = _animalRepository.GetAll().AsNoTracking()
                                .Where(a => a.IsDelete == false)
                                .Include(p => p.Cage)
                                .ToList();

            dgvAnimal.DataSource = listAnimal.Select(a => new
            {
                Id = a.Id,
                Name = a.AnimalName,
                Species = a.Species,
                Age = a.Age,
                Cage = a.Cage?.CageName
            }).ToList();
        }

        private void ShowListOfDeleteAnimal()
        {
            var listAnimal = _animalRepository.GetAll().AsNoTracking()
                                .Where(a => a.IsDelete == true)
                                .Include(p => p.Cage)
                                .ToList();


            dgvAnimal.DataSource = listAnimal.Select(a => new
            {
                Id = a.Id,
                Name = a.AnimalName,
                Species = a.Species,
                Age = a.Age,
                Cage = a.Cage?.CageName
            }).ToList();

        }

        private void ClearTextBox()
        {
            txtID.Text = "";
            txtAnimalName.Text = "";
            txtSpecies.Text = "";
            txtAge.Text = "";
            txtID.Text = "";
            cbCage.Text = "";
        }


        private void EmptyBoxes()
        {
            txtID.Text = String.Empty;
            txtAnimalName.Text = String.Empty;
            txtSpecies.Text = String.Empty;
            txtAge.Text = String.Empty;
            txtSearch.Text = String.Empty;
            cbCage.Text = String.Empty;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearTextBox();
            btnCreate.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }
    }
}
