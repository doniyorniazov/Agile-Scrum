
using System;
using Scrum.Common;

namespace Scrum.Model
{
    public class CodeReview : EntityBase
    {
        protected CodeReview()
        {
        }

        public CodeReview(Task task) : base(task.Context)
        {
            task = Task;
        }

        public CodeReviewStatus Status { get; set; }

        public Guid? ReviewerId { get; set; }

        public virtual User Reviewer { get; set; }

        public Guid? TaskId { get; set; }

        public virtual Task Task { get; set; }

    }
    public enum CodeReviewStatus
    {
        NeedsCpr = 0,
        WaitingForCpr = 1,
        CprComplete = 2,
        CprSkipped = 3
    }
}