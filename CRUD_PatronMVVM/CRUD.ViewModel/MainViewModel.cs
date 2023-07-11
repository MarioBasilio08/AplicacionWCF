using CRUD.ViewModel.EmployeeService;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using static System.Net.Mime.MediaTypeNames;

namespace CRUD.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private int id;
        private int age;
        private string name;
        private string email;
        private ObservableCollection<Employee> lista;

        private Employee selectedPerson;
        EmployeeService.Service1Client servicio;

        private bool isButtonEnabled;

        private bool isTextBoxEnabled;

        private ICommand saveCommand;
        private ICommand deleteCommand;
        private ICommand newCommand;

        private ICommand doubleClickCommand;

        public ICommand DoubleClickCommand
        {
            get
            {
                if (doubleClickCommand == null)
                {
                    doubleClickCommand = new RelayCommand(ExecuteDoubleClick);
                }
                return doubleClickCommand;
            }
        }

        public bool IsButtonEnabled
        {
            get { return isButtonEnabled; }
            set
            {
                isButtonEnabled = value;
                OnPropertyChanged(); 
            }
        }

        public bool IsTextBoxEnabled
        {
            get { return isTextBoxEnabled; }
            set
            {
                isTextBoxEnabled = value;
                OnPropertyChanged();
            }
        }

        public Employee SelectedPerson
        {
            get { return selectedPerson; }
            set
            {
                selectedPerson = value;
                OnPropertyChanged();
            }
        }

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                OnPropertyChanged("Age");
            }
        }

        public string Name
        {
            get { return name; }
            set { 
                name = value; 
                OnPropertyChanged("Name");
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        public ObservableCollection<Employee> Lista
        {
            get { return lista; }
            set
            {
                lista = value;
                OnPropertyChanged(nameof(lista));
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand(p => this.Delete());
                }
                return deleteCommand;
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                {
                    saveCommand = new RelayCommand(p => this.Save());
                }
                return saveCommand;
            }
        }

        public ICommand NewCommand
        {
            get
            {
                if (newCommand == null)
                {
                    newCommand = new RelayCommand(p => this.New());
                }
                return newCommand;
            }
        }

        public MainViewModel()
        {
            servicio = new EmployeeService.Service1Client();

            IsButtonEnabled = true;
            isTextBoxEnabled = false;

            GetAllEmployee();


        }

        public void GetAllEmployee()
        {
            Employee[] listaAux = servicio.GetAllEmployee();
            listaAux = servicio.GetAllEmployee();
            Lista = new ObservableCollection<Employee>(listaAux);
        }

        public void Save()
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || age <= 0)
            {
                MessageBox.Show("Hay campos erroneos o incompletos, por favor revise todos los campos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Employee persona = new Employee();
                persona.EmployeeID = id;
                persona.EmployeeName = name;
                persona.Email = email;
                persona.Age = age;

                if (id != 0)
                {
                    MessageBoxResult result = MessageBox.Show("¿Seguro que desea editar la información?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {                        
                        if (servicio.UpdateEmployee(persona))
                        {
                            Limpiar();
                            GetAllEmployee();
                            IsButtonEnabled = true;
                        }
                        else
                        {
                            MessageBox.Show($"No se puedo actualizar el employee", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }

                }
                else
                {
                    if (servicio.InsertEmployee(persona))
                    {
                        Limpiar();
                        GetAllEmployee();
                    }
                    else
                    {
                        MessageBox.Show($"El Id: {persona.EmployeeID} ya se encuentra registrado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

            }

        }

        public void Delete()
        {
            if (SelectedPerson != null)
            {
                MessageBoxResult result = MessageBox.Show("¿Seguro que desea eliminar la información?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    if (servicio.DeleteEmployee(SelectedPerson.EmployeeID))
                    {
                        Limpiar();
                        GetAllEmployee();
                    }
                    else
                    {
                        MessageBox.Show($"Se ha eliminado el registro", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    SelectedPerson = null;
                }
            }
            else
            {
                MessageBox.Show($"No hay ningun elemento seleccionado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void ExecuteDoubleClick(object parameter)
        {
            if (SelectedPerson != null)
            {
                id = SelectedPerson.EmployeeID;
                OnPropertyChanged("Id");

                age = SelectedPerson.Age;
                OnPropertyChanged("Age");

                name = SelectedPerson.EmployeeName;
                OnPropertyChanged("Name");

                email = SelectedPerson.Email;
                OnPropertyChanged("Email");

                IsButtonEnabled = false;
            }
        }

        public void New()
        {
            IsButtonEnabled = true;
            SelectedPerson = null;
            Limpiar();
        }

        public void Limpiar()
        {
            id = 0;
            OnPropertyChanged("Id");

            age = 0;
            OnPropertyChanged("Age");

            name = null;
            OnPropertyChanged("Name");

            email = null;
            OnPropertyChanged("Email");
        }

        //public void PersonAddedChange(object s, Employee e)
        //{
        //    MessageBox.Show($"Se ha agredado una nueva persona {e.EmployeeID}-{e.Name}", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
        //}

        //public void PersonEditChange(object s, Employee e)
        //{
        //    MessageBox.Show($"Se editado la persona {e.EmployeeID} - {e.Name}", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
        //}
    }
}
