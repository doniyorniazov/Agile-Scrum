using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using Scrum.Model;
using Scrum.SQL;
using Scrum.View.Commands;
using Scrum.View.Controls;
using Company = Scrum.Model.Company;

namespace Scrum.ViewModels
{
    public class SuperUserViewModel : BaseViewModel
    {
        public EntityContext Context { get; set; }

        public SuperUserViewModel()
        {
            Context = new EntityContext();
            Init();
        }

        public ICommand RunDialogCommand => new AnotherCommandImplementation(ExecuteRunDialog);

        private void ExecuteRunDialog(object obj)
        {
            
        }

        private void Init()
        {
            this.WhenAny(t => t.SelectedCompany, (c) => c.Value != null).Subscribe((r) =>
            {
                if (r)
                {
                    Projects = new ObservableCollection<Project>(SelectedCompany.Projects);
                    Users = new ObservableCollection<User>(SelectedCompany.Users);
                }
            });
        }


        int _projectCount;
        public int ProjectCount
        {
            get
            {
                if (Projects == null) return _projectCount;
                _projectCount = Projects.Count;
                return _projectCount;
            }

            set { _projectCount = value; OnPropertyChanged(); }
        }

        int _workerCount;
        public int WorkerCount
        {
            get
            {
                if (Users == null) return _workerCount;
                _workerCount = Users.Count;
                return _workerCount;
            }
            set { _workerCount = value; OnPropertyChanged(); }
        }


        ObservableCollection<User> _users;
        public ObservableCollection<User> Users
        {
            get => _users;
            set { _users = value; OnPropertyChanged(); }
        }

        ObservableCollection<Project> _projects;
        public ObservableCollection<Project> Projects
        {
            get => _projects;
            set { _projects = value; OnPropertyChanged(); }
        }

        Company _selectedCompany;
        public Company SelectedCompany
        {
            get => _selectedCompany;
            set { _selectedCompany = value; OnPropertyChanged(); }
        }

        private string _companyLogo;

        public string CompanyLogo
        {
            get
            {
                if (SelectedCompany != null)
                {
                    var splittedCompanyName = SelectedCompany.Name.Split(' ');
                    foreach (var word in splittedCompanyName)
                    {
                        _companyLogo += word.Substring(0, 1);
                    }
                }
                return _companyLogo;
            }
            set { _companyLogo = value; OnPropertyChanged(); }
        }

        ObservableCollection<Company> _companies;
        public ObservableCollection<Company> Companies
        {
            get
            {
                if (_companies == null)
                {
                    _companies = new ObservableCollection<Company>(Context.GetEntities<Company>());
                }
                return _companies;
            }
            set { _companies = value; OnPropertyChanged(); }
        }

        public ICommand MyCommand { get; set; }
    }
}
