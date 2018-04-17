using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using Scrum.Common;
using Scrum.Model;

namespace Scrum.SQL
{
    public class EntityContext : DbContext, IContext
    {
        public EntityContext()
            : base("data source=localhost;initial catalog=Scrum;integrated security=True;")
        {
            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
            Database.CreateIfNotExists();
            var context = ((IObjectContextAdapter)this).ObjectContext;
            context.ObjectStateManager.ObjectStateManagerChanged += ObjectStateManager_ObjectStateManagerChanged;
            context.ObjectMaterialized += Context_ObjectMaterialized;
        }

        void Context_ObjectMaterialized(object sender, ObjectMaterializedEventArgs e)
        {
            if (!(e.Entity is EntityBase entity))
                return;
            SetEntityContext(entity);
        }

        void ObjectStateManager_ObjectStateManagerChanged(object sender, CollectionChangeEventArgs e)
        {
            if (!(e.Element is EntityBase entity))
                return;
            SetEntityContext(entity);
        }

        void SetEntityContext(EntityBase entity)
        {
            if (entity.Context == null)
            {
                entity.SetContext(this);
            }
        }

        public IQueryable<T> GetEntities<T>() where T : EntityBase
        {
            try
            {
                var type = typeof(T);
                return GetEntities(type).Cast<T>();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Invalid Entity Type supplied for Lookup", ex);
            }
        }

        public IQueryable<T> GetEntities<T>(IEnumerable<string> properties) where T : EntityBase
        {
            var result = GetEntities(typeof(T)).Cast<T>();
            ;
            return properties.Aggregate(result, (current, property) => current.Include(property)).Cast<T>();
        }

        public IQueryable GetEntities(Type typeOfEntity)
        {
            try
            {
                return Set(typeOfEntity).AsQueryable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Mappings

        public DbSet<Company> Companies { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Sprint> Sprints { get; set; }

        public DbSet<Model.Task> Tasks { get; set; }

        public DbSet<Validation> Validations { get; set; }

        public DbSet<CodeReview> CodeReviews { get; set; }

        public DbSet<Grooming> Groomings { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Timecard> Timecards { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<EntityBase>();
            modelBuilder.Entity<EntityBase>().HasKey(e => e.Id);
            CompanyMapping(modelBuilder);
            ProjectMapping(modelBuilder);
            SprintMapping(modelBuilder);
            TaskMapping(modelBuilder);
            TimecardMapping(modelBuilder);
            UserMapping(modelBuilder);
            ValidationMapping(modelBuilder);
            CodeReviewMappint(modelBuilder);
            GroomingMapping(modelBuilder);
        }

        private void GroomingMapping(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grooming>().ToTable(nameof(Grooming));
            modelBuilder.Entity<Grooming>().HasOptional(g => g.Architect).WithMany(a => a.Groomings)
                .HasForeignKey(g => g.ArchitectId);
        }

        private void CodeReviewMappint(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CodeReview>().ToTable(nameof(CodeReview));
            modelBuilder.Entity<CodeReview>().HasOptional(cr => cr.Reviewer).WithMany(r => r.CodeReviews)
                .HasForeignKey(cr => cr.ReviewerId);
        }

        private void ValidationMapping(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Validation>().ToTable(nameof(Validation));
            modelBuilder.Entity<Validation>().HasOptional(v => v.Validator).WithMany(u => u.Validations)
                .HasForeignKey(v => v.ValidatorId);
        }

        private void UserMapping(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable(nameof(User));
            modelBuilder.Entity<User>().HasOptional(u => u.Timecard).WithMany(t => t.Users)
                .HasForeignKey(u => u.TimeCardId);
        }

        private void TimecardMapping(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Timecard>().ToTable(nameof(Timecard));
            modelBuilder.Entity<Timecard>().HasOptional(tc => tc.Task).WithMany(t => t.Timecards)
                .HasForeignKey(tc => tc.TaskId);
        }

        private void TaskMapping(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().ToTable(nameof(Task));
            modelBuilder.Entity<Task>().HasOptional(t => t.Sprint).WithMany(s => s.Tasks).HasForeignKey(t => t.SpintId);
            modelBuilder.Entity<Task>().HasOptional(t => t.Grooming).WithOptionalDependent(g => g.Task);
            modelBuilder.Entity<Task>().HasOptional(t => t.CodeReview).WithOptionalDependent(c => c.Task);
            modelBuilder.Entity<Task>().HasOptional(t => t.Validation).WithOptionalDependent(v => v.Task);
        }

        private void SprintMapping(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sprint>().ToTable(nameof(Sprint));
            modelBuilder.Entity<Sprint>().HasOptional(s => s.Project).WithMany(p => p.Sprints)
                .HasForeignKey(s => s.ProjectId);
        }

        private void ProjectMapping(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().ToTable(nameof(Project));
            modelBuilder.Entity<Project>().HasOptional(p => p.ScrumMaster).WithMany(s => s.ScrumProjects)
                .HasForeignKey(p => p.ScrumMasterId);
            modelBuilder.Entity<Project>().HasOptional(p => p.ProductOwner).WithMany(o => o.POProjects)
                .HasForeignKey(p => p.ProductOwnerId);
            modelBuilder.Entity<Project>().HasOptional(p => p.Company).WithMany(c => c.Projects)
                .HasForeignKey(p => p.CompanyId);
        }

        private void CompanyMapping(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().ToTable(nameof(Company));
        }
        #endregion
    }
}
