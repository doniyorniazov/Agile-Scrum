using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scrum.Model;
using Scrum.SQL;
using Task = Scrum.Model.Task;
using TaskStatus = Scrum.Model.TaskStatus;

namespace Scrum.ViewModels
{
    public class SprintViewModel : BaseViewModel
    {
        public SprintViewModel(Sprint currentSprint)
        {
            Context = new EntityContext();
            CurrentSprint = currentSprint;
        }

        Sprint _currentSprint;
        public Sprint CurrentSprint
        {
            get => _currentSprint;
            set { _currentSprint = value; OnPropertyChanged(); }
        }

        ObservableCollection<Task> _notStartedTasks;
        public ObservableCollection<Task> NotStartedTasks
        {
            get
            {
                return _notStartedTasks ?? (_notStartedTasks =
                           new ObservableCollection<Task>(Context.GetEntities<Model.Task>()
                               .Where(t => t.TaskStatus == TaskStatus.NotStarted)));
            }
            set { _notStartedTasks = value; OnPropertyChanged(); }
        }

        ObservableCollection<Task> _startedTasks;
        public ObservableCollection<Task> StartedTasks
        {
            get
            {
                return _startedTasks ?? (_startedTasks =
                           new ObservableCollection<Task>(Context.GetEntities<Model.Task>()
                               .Where(t => t.TaskStatus == TaskStatus.Started)));
            }
            set { _startedTasks = value; OnPropertyChanged(); }
        }

        ObservableCollection<Task> _notValidatedTasks;
        public ObservableCollection<Task> NotValidatedTasks
        {
            get
            {
                return _notValidatedTasks ?? (_notValidatedTasks =
                           new ObservableCollection<Task>(Context.GetEntities<Model.Task>()
                               .Where(t => t.TaskStatus == TaskStatus.NotValidated)));
            }
            set { _notValidatedTasks = value; OnPropertyChanged(); }
        }

        ObservableCollection<Task> _completedTasks;
        public ObservableCollection<Task> CompletedTasks
        {
            get
            {
                return _completedTasks ?? (_completedTasks =
                           new ObservableCollection<Task>(Context.GetEntities<Model.Task>()
                               .Where(t => t.TaskStatus == TaskStatus.Completed)));
            }
            set { _completedTasks = value; OnPropertyChanged(); }
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
                return _workers ?? (_workers = new ObservableCollection<User>(Context.GetEntities<Model.User>()
                           .Where(u => u.Tasks.Any() || u.Validations.Any() || u.CodeReviews.Any())));
            }

            set { _workers = value; OnPropertyChanged(); }
        }
    }
}
