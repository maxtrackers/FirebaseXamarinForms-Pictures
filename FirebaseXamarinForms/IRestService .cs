using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseXamarinForms
{
    public interface IRestService { Task<List<Employees>> ConsultaEmpleados(); }
}
