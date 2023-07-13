using CRUD.Model;
using CRUD.Model.EmployeeService;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace CRUD.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private int id;
        private int age;
        private string name;
        private string email;
        private ObservableCollection<Employee> lista;

        ServiceAdapter serv;

        private Employee selectedPerson;

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
            
            IsButtonEnabled = true;
            isTextBoxEnabled = false;

            serv = new ServiceAdapter();
            AllEmployee();
        }


        public void Save()
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || age <= 0)
            {
                MessageBox.Show("Hay campos erroneos o incompletos, por favor revise todos los campos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                EmployeeLocal persona = new EmployeeLocal();
                persona.Id = id;
                persona.Name = name;
                persona.Email = email;
                persona.Age = age;

                if (id != 0)
                {
                    MessageBoxResult result = MessageBox.Show("¿Seguro que desea editar la información?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {                        
                        if (serv.updateEmployeeService(persona))
                        {
                            Limpiar();
                            AllEmployee();
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
                    if (serv.insertEmployeeService(persona))
                    {
                        Limpiar();
                        AllEmployee();
                    }
                    else
                    {
                        MessageBox.Show($"El Id: {persona.Id} ya se encuentra registrado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    if (serv.deleteEmployeeService(SelectedPerson.EmployeeID))
                    {
                        Limpiar();
                        AllEmployee();
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

        public void AllEmployee()
        {
            Employee[] listaAux = serv.getAllEmployee();
            Lista = new ObservableCollection<Employee>(listaAux);
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
