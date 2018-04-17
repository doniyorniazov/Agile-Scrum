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

        public ProjectViewModel()
        {
            Context = new EntityContext();
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
