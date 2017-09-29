using Xamarin.Forms;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FirebaseXamarinForms
{
	public class MainPage : TabbedPage
	{
		public MainPage ()
		{
            RestService _restService = new RestService();
            _restService.RefreshDataAsync();
            Title = "Firebase + Xamarin Forms";
            Employees emp = new Employees();
            emp.EmployeeId = 9;
            emp.FirstName = "Maxi";
            emp.LastName = "Vazquez";
            emp.Title = "CEO2";
            emp.HireDate = DateTime.Now;
            emp.Fax = "1234";
            emp.Phone = "344";
            //App.DAUtil.SaveEmployee(emp);
            App.DAUtil.EditEmployee(emp);
            var vList = App.DAUtil.GetAllEmployees();
            

            Children.Add (new SendPage ());
			Children.Add (new ListPage ());
            
        }
	}
}