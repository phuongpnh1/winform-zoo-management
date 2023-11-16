using Entities.Models;

namespace Zoo.Management.WinformApp
{
	public static class StripMenuHelper
	{
		public static void ShowAreaForm()
		{
			AreaForm areaForm = new AreaForm();
			areaForm.Show();
		}

		public static void ShowCageForm()
		{
			CageForm cageForm = new CageForm();
			cageForm.Show();
		}

		public static void ShowUserForm(ApplicationUser user)
		{
			UserForm userForm = new UserForm(user);
			userForm.Show();
		}

		public static void ShowAnimalForm()
		{
			AnimalForm animalForm = new AnimalForm();
			animalForm.Show();
		}

		public static void Exist(UserForm user)
		{
			Login login = new Login();
			login.Show();
			user.Hide();
		}
	}
}
