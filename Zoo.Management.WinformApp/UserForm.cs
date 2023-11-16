using Microsoft.VisualBasic.ApplicationServices;
using Repositories;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Entities.Helper;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Zoo.Management.WinformApp
{
	public partial class UserForm : Form
	{
		private readonly UserRepository _resipotory;
		private readonly ApplicationUser _user;
		private List<ApplicationUser> _applicationUsers = new List<ApplicationUser>();
		public UserForm(ApplicationUser applicationUser)
		{
			_resipotory = new UserRepository();
			_user = applicationUser;

			InitializeComponent();
			this.ShowListUser();
		}

		private ApplicationUser GetCurrentUser()
		{
			var userName = txtUserName.Text;
			var password = txtPassword.Text;
			var fullName = txtFullName.Text;
			var email = txtEmail.Text;
			var phoneNumber = txtPhoneNumber.Text;
			var id = txtId.Text;

			var gender = cbGender.Text;
			var role = cbRole.Text;
			var dob = dtpDateOfBirth.Value;

			var currentUser = new ApplicationUser()
			{
				Id = int.Parse(id),
				UserName = userName,
				Password = password,
				FullName = fullName,
				Email = email,
				PhoneNumber = phoneNumber,
				Gender = gender,
				Role = role,
				Dob = dob,
				IsDeleted = false
			};
			return currentUser;
		}
		private void ShowListUser()
		{
			_applicationUsers = _resipotory.GetAll()
				.Where(u => u.IsDeleted == false)
				.AsNoTracking().ToList();
			dgvUser.DataSource = _applicationUsers.Select(u => new
			{
				Id = u.Id.ToString(),
				userName = u.UserName,
				fullName = u.FullName,
				email = u.Email,
				phoneNumber = u.PhoneNumber,
				gender = u.Gender,
				role = u.Role,
				DateOfBirth = u.Dob,
			}).ToList();
		}
		private void ShowDeletedUser()
		{
			_applicationUsers = _resipotory.GetAll()
				.Where(u => u.IsDeleted == true)
				.AsNoTracking().ToList();
			dgvUser.DataSource = _applicationUsers.Select(u => new
			{
				Id = u.Id.ToString(),
				userName = u.UserName,
				fullName = u.FullName,
				email = u.Email,
				phoneNumber = u.PhoneNumber,
				gender = u.Gender,
				role = u.Role,
				DateOfBirth = u.Dob,
			}).ToList();
		}
		private void Search(string searchString)
		{
			if (btnRecovery.Visible == false)
			{
				_applicationUsers = _resipotory.GetAll()
					.Where(u => u.IsDeleted == false && u.FullName.Contains(searchString))
					.AsNoTracking().ToList();
			}
			if (btnRecovery.Visible == true)
			{
				_applicationUsers = _resipotory.GetAll()
					.Where(u => u.IsDeleted == true && u.FullName.Contains(searchString))
					.AsNoTracking().ToList();
			}

			dgvUser.DataSource = _applicationUsers.Select(u => new
			{
				Id = u.Id.ToString(),
				userName = u.UserName,
				fullName = u.FullName,
				email = u.Email,
				phoneNumber = u.PhoneNumber,
				gender = u.Gender,
				role = u.Role,
				DateOfBirth = u.Dob,
			}).ToList();
		}
		private void EmptyBoxes()
		{
			txtId.Text = String.Empty;
			txtUserName.Text = String.Empty;
			txtPassword.Text = String.Empty;
			txtFullName.Text = String.Empty;
			txtEmail.Text = String.Empty;
			txtPhoneNumber.Text = String.Empty;
			cbGender.Text = String.Empty;
			cbRole.Text = String.Empty;
			dtpDateOfBirth.Value = DateTime.UtcNow;
		}

		private async void btnCreate_Click(object sender, EventArgs e)
		{
			var userName = txtUserName.Text;
			var hadUser = _resipotory.GetAll().Where(e => e.UserName == userName).FirstOrDefault();
			if (hadUser != null) 
			{
                MessageBox.Show("UserName is already exist!!");
                return;
            }
			var password = txtPassword.Text;
			var fullName = txtFullName.Text;
			var email = txtEmail.Text;
			var phone = txtPhoneNumber.Text;
			var isValidPhoneNumber = Regex.IsMatch(txtPhoneNumber.Text, @"^\d+$");
			if (!isValidPhoneNumber)
			{
				MessageBox.Show("Phone number is not valid!!");
				return;
			}
			var gender = "";

            if (cbGender.Text == "Male" || cbGender.Text == "Female" || cbGender.Text == "Other")
			{
				gender = cbGender.Text;
            } 
			else
			{
                MessageBox.Show("Invalid Gender, Please select given value!!");
                return;
            }
			var role = "";
            if (cbRole.Text == "Admin" || cbRole.Text == "Staff" || cbRole.Text == "ZooTrainer")
            {
				role = cbRole.Text;
            }
			else
			{
                MessageBox.Show("Invalid Role, Please select given value!!");
                return;
            }
			var dob = dtpDateOfBirth.Value;

			var newUser = new ApplicationUser()
			{
				UserName = userName,
				Password = password,
				FullName = fullName,
				Email = email,
				PhoneNumber = phone,
				Gender = gender,
				Role = role,
				Dob = dob,
			};

			ApplicationUserValidationHelper validator = new();
			var result = validator.Validate(newUser);

			if (!result.IsValid)
			{
				var errorsMessage = result.ToString("\n");
				MessageBox.Show(errorsMessage);
				return;
			}

			await _resipotory.AddAsync(newUser);
			ShowListUser();
		}

		private async void btnUpdate_Click(object sender, EventArgs e)
		{
			var user = await _resipotory.GetByIdAsync(int.Parse(txtId.Text));

			if (user is null)
			{
				MessageBox.Show("The user is not exist!!");
				return;
			}
			var isValidPhoneNumber = Regex.IsMatch(txtPhoneNumber.Text, @"^\d+$");
			if (!isValidPhoneNumber)
            {
                MessageBox.Show("Phone number is not valid!!");
                return;
			}
            var hadUser = _resipotory.GetAll().Where(e => e.UserName == txtUserName.Text && e.Id != user.Id).FirstOrDefault();
            if (hadUser != null)
            {
                MessageBox.Show("UserName is already exist!!");
                return;
            }
            user.UserName = txtUserName.Text;
			user.Password = txtPassword.Text;
			user.Dob = dtpDateOfBirth.Value;
			user.PhoneNumber = txtPhoneNumber.Text;
			user.Gender = cbGender.Text;
			user.Role = cbRole.Text;
			user.Email = txtEmail.Text;
			user.FullName = txtFullName.Text;

			ApplicationUserValidationHelper validator = new();
			var result = validator.Validate(user);

			if (!result.IsValid)
			{
				var errorsMessage = result.ToString("\n");
				MessageBox.Show(errorsMessage);
				return;
			}

			await _resipotory.UpdateAsync(user);
			EmptyBoxes();
			MessageBox.Show("Updated");
			btnCreate.Enabled = true;
			btnUpdate.Enabled = false;
			btnDelete.Enabled = false;
			ShowListUser();
		}

		private async void btnDelete_Click(object sender, EventArgs e)
		{
			var user = await _resipotory.GetByIdAsync(int.Parse(txtId.Text));
			if (user is null)
			{
				MessageBox.Show("The user is not exist!!");
				return;
			}
			if (user.Id == _user.Id)
			{
				MessageBox.Show("Can not delete your account!!");
				return;
			}

			var isDeleted = await _resipotory.DeleteUserAsync(user);
			if (isDeleted)
			{
				MessageBox.Show("Deleted");
			}
			else
			{
				MessageBox.Show("Delete failed!");
			}
			EmptyBoxes();
			btnCreate.Enabled = true;
			btnDelete.Enabled = false;
			btnUpdate.Enabled = false;
			ShowListUser();
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			var searchString = txtSearch.Text;
			Search(searchString);
		}

		private void dgvUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (btnRecovery.Visible != true)
			{
				btnUpdate.Enabled = true;
				btnDelete.Enabled = true;
				btnCreate.Enabled = false;
			}

			var data = _applicationUsers[e.RowIndex];

			txtId.Text = data.Id.ToString();
			txtUserName.Text = data.UserName;
			txtPassword.Text = data.Password;
			txtFullName.Text = data.FullName;
			txtEmail.Text = data.Email;
			txtPhoneNumber.Text = data.PhoneNumber;
			cbGender.Text = data.Gender.ToString();
			cbRole.Text = data.Role.ToString();
			dtpDateOfBirth.Text = data.Dob.ToString();
		}

		private void btnDeletedList_Click(object sender, EventArgs e)
		{
			btnCurrentList.Enabled = true;
			btnDeletedList.Enabled = false;

			btnDelete.Enabled = false;
			btnCreate.Enabled = false;
			btnUpdate.Enabled = false;

			btnRecovery.Enabled = true;
			btnRecovery.Visible = true;
			ShowDeletedUser();
		}

		private void btnCurrentList_Click(object sender, EventArgs e)
		{
			btnDeletedList.Enabled = true;
			btnCurrentList.Enabled = false;

			btnCreate.Enabled = true;

			btnRecovery.Enabled = false;
			btnRecovery.Visible = false;
			ShowListUser();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			EmptyBoxes();
			btnCreate.Enabled = true;
			btnDelete.Enabled = false;
			btnUpdate.Enabled = false;
		}

		private async void btnRecovery_Click(object sender, EventArgs e)
		{
			var user = GetCurrentUser();
			var isRecovered = await _resipotory.RecoveryUserAsync(user);
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
			btnDeletedList.Enabled = true;
			btnCurrentList.Enabled = false;
			ShowListUser();
		}

		private void areasCagesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StripMenuHelper.ShowAreaForm();
		}

		private void animalToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			StripMenuHelper.ShowAnimalForm();
		}

		private void animalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StripMenuHelper.Exist(this);
		}
		private void cagesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StripMenuHelper.ShowCageForm();
		}

		private void animalStatusToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var isExist = MessageBox.Show("Do you want to exit?", "", MessageBoxButtons.YesNo).ToString();
			if (isExist == "Yes")
			{
				this.Close();
			}
		}

	}

}
