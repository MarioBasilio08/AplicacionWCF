using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using TareaWCF.BLL;

namespace TareaWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        public async Task<bool> InsertEmployee(Employee obj)
        {
            EmployeeBO employeeBO = new EmployeeBO();
            return await employeeBO.Save(obj);
        }

        public async Task<List<Employee>> GetAllEmployee()
        {
            EmployeeBO employeeBO = new EmployeeBO();
            return await employeeBO.GetAll();
        }
        public async Task<bool> DeleteEmployee(int id)
        {
            EmployeeBO employeeBO = new EmployeeBO();
            return await employeeBO.Delete(id);
        }

        public async Task<bool> UpdateEmployee(Employee obj)
        {
            EmployeeBO employeeBO =new EmployeeBO();
            return await employeeBO.Update(obj);
        }

    }
}
