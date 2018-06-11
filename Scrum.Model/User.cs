using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Scrum.Common;

namespace Scrum.Model
{
    public class User : EntityBase
    {
        protected User()
        {

        }

        public User(IContext context) : base(context)
        {
            Groomings = new ObservableCollection<Grooming>();
            Validations = new ObservableCollection<Validation>();
            CodeReviews = new ObservableCollection<CodeReview>();
        }

        public string UserId
        {
            get
            {
                if (string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(LastName))
                {
                    return (Name.Substring(0, 3) + LastName.Substring(0, 3)).ToUpper();
                };
                return null;
            }
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public Guid? TimeCardId { get; set; }
        public virtual Timecard Timecard { get; set; }
        public bool IsSuperUser { get; set; }
        public Guid? CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<Grooming> Groomings { get; set; }
        public virtual ICollection<CodeReview> CodeReviews { get; set; }
        public virtual ICollection<Validation> Validations { get; set; }
        public virtual ICollection<Project> POProjects { get; set; }
        public virtual ICollection<Project> ScrumProjects { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}