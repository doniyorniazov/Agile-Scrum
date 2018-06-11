using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scrum.Model;
using Scrum.SQL;

namespace Scrum.ViewModels
{
    public class ProjectViewModel : BaseViewModel
    {
        private EntityContext Context;

        public ProjectViewModel(Company company)
        {
            Context = new EntityContext();
            Company = company;
            Projects = new ObservableCollection<Project>(company.Projects);
        }

        ObservableCollection<Sprint> _sprints;
        public ObservableCollection<Sprint> Sprints
        {
            get
            {
                return _sprints ?? (_sprints =
                           new ObservableCollection<Sprint>(Context.GetEntities<Sprint>().Where(s => s.Project == SelectedProject)));
            }
            set { _sprints = value; OnPropertyChanged(); }
        }

        Project _selectedProject;
        public Project SelectedProject
        {
            get => _selectedProject;
            set { _selectedProject = value; OnPropertyChanged(); }
        }


        string _currentSprintEndDate;
        public string CurrentSprintEndDate
        {
            get => _currentSprintEndDate;
            set { _currentSprintEndDate = value; OnPropertyChanged(); }
        }

        string _currentSprintNumber;
        public string CurrentSprintNumber
        {
            get => _currentSprintNumber;
            set { _currentSprintNumber = value; OnPropertyChanged(); }
        }

        string _name;
        public string Name
        {
            get
            {
                if (SelectedProject != null)
                {
                    return SelectedProject.Name;
                }
                return Name;

            }
            set { _name = value; OnPropertyChanged(); }
        }

        Company _company;
        public Company Company
        {
            get => _company;
            set { _company = value; OnPropertyChanged(); }
        }


        private ObservableCollection<Project> _projects;

        public ObservableCollection<Project> Projects
        {
            get
            {
                if (_projects == null)
                {
                    _projects = new ObservableCollection<Project>(Context.GetEntities<Project>());
                }
                return _projects;
            }
            set { _projects = value; OnPropertyChanged(); }
        }

    }
}
