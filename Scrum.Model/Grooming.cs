
using System;
using Scrum.Common;

namespace Scrum.Model
{
    public class Grooming : EntityBase
    {
        protected Grooming() { }

        public Grooming(Task task) : base(task.Context)
        {
            Task = task;
        }

        public GroomingStatus Status { get; set; }
        public virtual Guid? ArchitectId { get; set; }

        /// <summary>
        /// Person who is groomer to this task.
        /// </summary>
        public virtual User Architect { get; set; }

        //public Guid? TaskId { get; set; }
        public virtual Task Task { get; set; }
    }
    public enum GroomingStatus
    {
        Needsgrooming,
        Ready,
    }
}