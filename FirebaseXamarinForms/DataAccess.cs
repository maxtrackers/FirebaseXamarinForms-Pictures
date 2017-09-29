using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite.Net;
namespace FirebaseXamarinForms
{
    public class DataAccess
    {
        SQLiteConnection dbConn;
        public DataAccess()
        {
            dbConn = DependencyService.Get<ISQLite>().GetConnection();
            // create the table(s)
            dbConn.CreateTable<Employees>();
        }
        public List<Employees> GetAllEmployees()
        {
            return dbConn.Query<Employees>("Select * From [Employees]");
        }
        public int SaveEmployee(Employees aEmployee)
        {
            return dbConn.Insert(aEmployee);
        }
        public int DeleteEmployee(Employees aEmployee)
        {
            return dbConn.Delete(aEmployee);
        }
        public int EditEmployee(Employees aEmployee)
        {
            return dbConn.Update(aEmployee);
        }
    }   
}
