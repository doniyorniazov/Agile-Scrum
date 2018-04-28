using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Scrum.Common;


namespace Scrum.Model
{
    public class Project : EntityBase
    {
        protected Project()
        {

        }

        public Project(IContext context) : base(context)
        {
            Sprints = new ObservableCollection<Sprint>();
        }

        /// <summary>
        /// Project name
        /// </summary>
        public string Name { get; set; }

        public Guid? ProductOwnerId { get; set; }
        /// <summary>
        /// Projects product owner
        /// </summary>
        public virtual User ProductOwner { get; set; }

        public Guid? ScrumMasterId { get; set; }
        /// <summary>
        /// Project scrum master
        /// </summary>
        public virtual User ScrumMaster { get; set; }

        /// <summary>
        /// Company of project
        /// </summary>

        public Guid? CompanyId { get; set; }
        public virtual Company Company { get; set; }

        /// <summary>
        /// Project Sprints
        /// </summary>
        public virtual ICollection<Sprint> Sprints { get; set; }
    }
}