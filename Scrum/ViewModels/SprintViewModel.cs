using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scrum.Model;
using Scrum.SQL;
using Task = Scrum.Model.Task;

namespace Scrum.ViewModels
{
    public class SprintViewModel : BaseViewModel
    {
        private EntityContext Context;
        public SprintViewModel()
        {
            Context = new EntityContext();
        }

        ObservableCollection<Model.Task> _tasks;
        public ObservableCollection<Model.Task> Tasks
        {
            get
            {
                if (_tasks == null)
                    _tasks = new ObservableCollection<Task>(Context.GetEntities<Model.Task>().Where(t => t.Assignee != null));
                return _tasks;
            }
            set { _tasks = value; OnPropertyChanged(); }
        }

        User _currentWorker;
        public User CurrentWorker
        {
            get => _currentWorker;
            set { _currentWorker = value; OnPropertyChanged(); }
        }

        ObservableCollection<User> _workers;
        public ObservableCollection<User> Workers
        {
            get
            {
                if (_workers == null)
                    _workers = new ObservableCollection<User>(Context.GetEntities<Model.User>().Where(u => u.Tasks.Any()));
                return _workers;
            }

            set { _workers = value; OnPropertyChanged(); }
        }
    }
}
