using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TareaWCF.DTO;
using Dapper;

namespace TareaWCF.DAL
{
    public class EmployeeDO
    {
        public EmployeeDTO Bind(Employee employee)
        {
            EmployeeDTO employeeResult = new EmployeeDTO();
            employeeResult.Id = employee.EmployeeID;
            employeeResult.Name = employee.EmployeeName;
            employeeResult.Email = employee.Email;
            employeeResult.Age = employee.Age;
            return employeeResult;
        }

        public List<Employee> BindList(List<EmployeeDTO> employeeList)
        {
            List<Employee> result = new List<Employee>();
            employeeList.ForEach(x =>
            {
                Employee employee = new Employee();
                employee.EmployeeID = x.Id;
                employee.EmployeeName = x.Name;
                employee.Email = x.Email;
                employee.Age = x.Age;
                result.Add(employee);
            });

            return result;
        }

        public async Task<bool> Save(Employee employee)
        {
            bool result = false;
            try
            {
                EmployeeDTO employeeSave = Bind(employee);
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeesBD"].ConnectionString))
                {
                    connection.Open();
                    await connection.ExecuteAsync("PuntoDeVenta.spEmployeeSave", employeeSave, commandType: CommandType.StoredProcedure);
                    result = true;
                }

            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public async Task<List<Employee>> GetAll()
        {
            List<Employee> result = new List<Employee>();
            try
            {

                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeesBD"].ConnectionString))
                {
                    connection.Open();
                    var x = await connection.QueryAsync<EmployeeDTO>("PuntoDeVenta.spEmployeeGetList", commandType: CommandType.StoredProcedure);
                    result = BindList(x.ToList());
                }

            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public async Task<bool> Delete(int id)
        {
            bool result = false;
            try
            {
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeesBD"].ConnectionString))
                {
                    connection.Open();
                    await connection.ExecuteAsync("PuntoDeVenta.spEmployeeDelete", new { Id=  id }, commandType: CommandType.StoredProcedure);
                    result = true;
                }

            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public async Task<bool> Update(Employee employee)
        {
            bool result = false;
            try
            {
                EmployeeDTO employeeEdit = Bind(employee);
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeesBD"].ConnectionString))
                {
                    connection.Open();
                    await connection.ExecuteAsync("PuntoDeVenta.spEmployeeEdit", employeeEdit, commandType: CommandType.StoredProcedure);
                    result = true;
                }

            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

    }
}