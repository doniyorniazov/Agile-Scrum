using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Scrum.Model;
using Scrum.SQL;

namespace Scrum.ViewModels
{
    public class TaskInfoViewModel : BaseViewModel
    {
        public TaskInfoViewModel(Task currentTask)
        {
            Context = currentTask.Context;
            CurrentTask = currentTask;
        }

        ObservableCollection<User> _workers;
        public ObservableCollection<User> Workers
        {
            get
            {
                return _workers ?? (_workers =
                           new ObservableCollection<User>(Context.GetEntities<User>().Where(t => t.Company != null)));
            }
            set
            { _workers = value; OnPropertyChanged(); }
        }

        Task _currentTask;
        public Task CurrentTask
        {
            get => _currentTask;
            set { _currentTask = value; OnPropertyChanged(); }
        }
    }
}
