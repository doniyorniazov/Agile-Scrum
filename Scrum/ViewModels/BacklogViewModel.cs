using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Scrum.Model;
using Scrum.SQL;

namespace Scrum.ViewModels
{
    public class BacklogViewModel : BaseViewModel
    {
        public BacklogViewModel()
        {
            Context = new EntityContext();
        }

        public EntityContext Context { get; set; }

        private ObservableCollection<Task> _tasks;

        public ObservableCollection<Task> Tasks
        {
            get
            {
                return _tasks ?? (_tasks =
                           new ObservableCollection<Task>(Context.GetEntities<Task>().Where(t => t.TaskStatus == TaskStatus.NotStarted)));
            }
            set => _tasks = value;
        }
    }
}
