using System;
using Scrum.Common;

namespace Scrum.Model
{
    public class Validation : EntityBase
    {
        protected Validation() { }

        public Validation(Task task) : base(task.Context)
        {
            Task = task;
        }

        public Guid? ValidatorId { get; set; }
        public virtual User Validator { get; set; }

        public ValidationStatus ValidationStatus { get; set; }

        //public Guid? TaskId { get; set; }
        public virtual Task Task { get; set; }
    }
    public enum ValidationStatus
    {
        NeedsTesting = 0,
        WaitingTesting = 1,
        Complete = 2,
    }
}