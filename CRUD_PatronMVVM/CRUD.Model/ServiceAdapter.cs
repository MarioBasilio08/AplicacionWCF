using CRUD.Model.EmployeeService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Model
{
    public class ServiceAdapter
    {
        public bool insertEmployeeService(EmployeeLocal obj)
        {
            EmployeeService.Service1Client servicio = new EmployeeService.Service1Client();
            EmployeeService.Employee employee = new EmployeeService.Employee();
            employee.EmployeeName = obj.Name;
            employee.Email = obj.Email;
            employee.Age = obj.Age;
            return servicio.InsertEmployee(employee);
        }

        public bool updateEmployeeService(EmployeeLocal obj)
        {
            EmployeeService.Service1Client servicio = new EmployeeService.Service1Client();
            EmployeeService.Employee employee = new EmployeeService.Employee();
            employee.EmployeeID = obj.Id;
            employee.EmployeeName = obj.Name;
            employee.Email = obj.Email;
            employee.Age = obj.Age;
            return servicio.UpdateEmployee(employee);
        }

        public bool deleteEmployeeService(int id)
        {
            EmployeeService.Service1Client servicio = new EmployeeService.Service1Client();
            return servicio.DeleteEmployee(id);
        }

        public Employee[] getAllEmployee()
        {
            EmployeeService.Service1Client servicio = new EmployeeService.Service1Client();

            return servicio.GetAllEmployee();
        }
    }
}
