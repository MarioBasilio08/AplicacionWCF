using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace TareaWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        Task<bool> InsertEmployee(Employee obj);

        [OperationContract]
        Task<List<Employee>> GetAllEmployee();

        [OperationContract]
        Task<bool> DeleteEmployee(int id);

        [OperationContract]
        Task<bool> UpdateEmployee(Employee obj);

        // TODO: agregue aquí sus operaciones de servicio
    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class Employee
    {
        [DataMember]
        public int EmployeeID;
        [DataMember]
        public string EmployeeName;
        [DataMember]
        public string Email;
        [DataMember]
        public int Age;
    }
}
