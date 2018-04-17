using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Scrum.Common;


namespace Scrum.Model
{
    public class Timecard : EntityBase
    {
        protected Timecard()
        {

        }

        public Timecard(IContext context) : base(context)
        {
            Users = new ObservableCollection<User>();
            Task = new Task(context);
        }

        public DateTime DateTime { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public decimal Hours { get; set; }

        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public Guid? TaskId { get; set; }

        public virtual Task Task { get; set; }
    }
}