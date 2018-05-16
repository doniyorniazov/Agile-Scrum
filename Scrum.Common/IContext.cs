using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum.Common
{
    public interface IContext
    {
        IQueryable<T> GetEntities<T>() where T : EntityBase;
        int SaveChanges();
    }
}
