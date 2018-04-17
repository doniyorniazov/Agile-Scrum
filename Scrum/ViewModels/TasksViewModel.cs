using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scrum.SQL;

namespace Scrum.ViewModels
{
    public class TasksViewModel
    {
        private EntityContext Context;
        public TasksViewModel()
        {
            Context = new EntityContext();
            Tasks = GetTasks();
        }

        public List<Model.Task> Tasks { get; set; }

        public List<Model.Task> GetTasks()
        {
            using (var db = new EntityContext())
            {
                return db.GetEntities<Model.Task>().Where(t => t.Assignee != null).ToList();
            }
        }


    }
}
