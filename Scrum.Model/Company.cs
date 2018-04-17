using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Scrum.Common;

namespace Scrum.Model
{
    public class Company : EntityBase
    {
        protected Company()
        {

        }

        public Company(IContext context) : base(context)
        {
            Users = new ObservableCollection<User>();
            Projects = new ObservableCollection<Project>();
        }

        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
