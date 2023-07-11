using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using TareaWCF.DAL;

namespace TareaWCF.BLL
{
    public class EmployeeBO
    {
        public async Task<bool> Save(Employee employee)
        {
            EmployeeDO employeeDO = new EmployeeDO();
            return await employeeDO.Save(employee);
        }

        public async Task<List<Employee>> GetAll()
        {
            EmployeeDO employeeDO = new EmployeeDO();
            return await employeeDO.GetAll();

        }

        public async Task<bool> Delete(int id)
        {
            EmployeeDO employeeDO = new EmployeeDO();
            return await employeeDO.Delete(id);
        }

        public async Task<bool> Update(Employee employee)
        {
            EmployeeDO employeeDO = new EmployeeDO();
            return await employeeDO.Update(employee);
        }
    }
}