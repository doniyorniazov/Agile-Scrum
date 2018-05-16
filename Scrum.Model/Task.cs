using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.Threading.Tasks;
using Scrum.Common;

namespace Scrum.Model
{
    public class Task : EntityBase
    {
        private Task()
        {

        }

        public Task(IContext context) : base(context)
        {
            Timecards = new ObservableCollection<Timecard>();
        }

        public Guid? AssigneeId { get; set; }

        public virtual User Assignee { get; set; }

        public string TicketNumber { get; set; }

        public int RankNumber { get; set; }

        public string Description { get; set; }

        public Priority Priority { get; set; }

        public decimal RemainingHours { get; set; }

        public decimal EstimatedHours { get; set; }

        public virtual ICollection<Timecard> Timecards { get; set; }

        public Guid? SpintId { get; set; }

        public int Size { get; set; }    

        public virtual Sprint Sprint { get; set; }

        public TaskStatus TaskStatus { get; set; }

        public virtual Grooming Grooming { get; set; }

        public virtual Validation Validation { get; set; }

        public virtual CodeReview CodeReview { get; set; }

        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<User> Workers { get; set; }

        public Guid? TaskCreatorId { get; set; }
        public virtual User TaskCreator { get; set; }
    }

    public enum TaskStatus
    {
        NotStarted,
        Started,
        NotValidated,
        Completed
    }

    public enum Priority
    {
        Low,
        Normal,
        High,
        Emeregency
    }
}