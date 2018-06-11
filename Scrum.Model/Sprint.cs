using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Scrum.Common;


namespace Scrum.Model
{
    public class Sprint : EntityBase
    {
        protected Sprint()
        {

        }
        public Sprint(IContext context) : base(context)
        {
            Tasks = new ObservableCollection<Task>();
        }

        /// <summary>
        /// Sprint number: 0001
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Period of sprint: 2 weeks or 4 weeks
        /// </summary>
        public int Period { get; set; }

        /// <summary>
        /// Date which sprint starts
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Date which sprint ends
        /// </summary>
        public DateTime? EndDate { get; set; }

        public Guid? ProjectId { get; set; }
        /// <summary>
        /// Project of sprint
        /// </summary>
        public virtual Project Project { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}