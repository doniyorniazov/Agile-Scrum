using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scrum.Model;

namespace Scrum.SQL
{
    public class DemoDataCreator
    {
        public EntityContext Context { get; set; }
        public DemoDataCreator()
        {
            Context = new EntityContext();
        }

        public void CreateTestCompany()
        {
            var SuperUser = new User(Context);
            SuperUser.Name = "Doniyor";
            SuperUser.LastName = "Niyozov";
            SuperUser.IsSuperUser = true;
            SuperUser.Password = Security.HashSHA1("medonam");
            Context.Users.Add(SuperUser);

            // Company1
            var company1 = new Company(Context);
            company1.Name = "Silk Road Professionals";

            var project1 = new Project(Context);
            project1.Name = "Test Project 1";
            project1.Company = company1;

            var DoniyorWorker = new User(Context);
            DoniyorWorker.Name = "Doniyor";
            DoniyorWorker.LastName = "Niyozov";
            DoniyorWorker.Company = company1;
            project1.ProductOwner = DoniyorWorker;

            var TohirWorker = new User(Context);
            TohirWorker.Name = "Tohir";
            TohirWorker.LastName = "Tohirov";
            TohirWorker.Company = company1;
            project1.ScrumMaster = TohirWorker;

            var AlisherWorker = new User(Context);
            AlisherWorker.Name = "Alisher";
            AlisherWorker.LastName = "Azimov";
            AlisherWorker.Company = company1;

            var QutfulloWorker = new User(Context);
            QutfulloWorker.Name = "Qutfullo";
            QutfulloWorker.LastName = "Ochilov";
            QutfulloWorker.Company = company1;

            var JamshedWorker = new User(Context);
            JamshedWorker.Name = "Akhmedov";
            JamshedWorker.LastName = "Jamshed";
            JamshedWorker.Company = company1;

            var project2 = new Project(Context) { Company = company1 };
            project2.Name = "Test Project 2";
            project2.ProductOwner = DoniyorWorker;
            project2.ScrumMaster = AlisherWorker;

            // Company2
            var company2 = new Company(Context);
            company2.Name = "Soghd Software Systems";

            var project3 = new Project(Context);
            project3.Name = "Test Project 3";
            project3.Company = company2;

            var DalerWorker = new User(Context);
            DalerWorker.Name = "Daler";
            DalerWorker.LastName = "Yunusov";
            DalerWorker.Company = company1;
            project3.ProductOwner = DalerWorker;

            var MirzodalerWorker = new User(Context);
            MirzodalerWorker.Name = "Mirzodaler";
            MirzodalerWorker.LastName = "Ataev";
            MirzodalerWorker.Company = company2;
            project3.ScrumMaster = TohirWorker;

            var UsmonjonWorker = new User(Context);
            UsmonjonWorker.Name = "Usmonjon";
            UsmonjonWorker.LastName = "Nurmatov";
            UsmonjonWorker.Company = company2;

            var JavohirWorker = new User(Context);
            JavohirWorker.Name = "Javohir";
            JavohirWorker.LastName = "Avlihodjaev";
            JavohirWorker.Company = company2;

            var AhrorWorker = new User(Context);
            AhrorWorker.Name = "Ahror";
            AhrorWorker.LastName = "Kayumov";
            AhrorWorker.Company = company2;

            var project4 = new Project(Context) { Company = company2 };
            project4.Name = "Test Project 4";
            project4.ProductOwner = JavohirWorker;
            project4.ScrumMaster = AhrorWorker;

            Context.Companies.Add(company1);
            Context.Companies.Add(company2);

            Context.Projects.Add(project1);
            Context.Projects.Add(project2);
            Context.Projects.Add(project3);
            Context.Projects.Add(project4);

            Context.Users.Add(DoniyorWorker);
            Context.Users.Add(TohirWorker);
            Context.Users.Add(AlisherWorker);
            Context.Users.Add(QutfulloWorker);
            Context.Users.Add(JamshedWorker);
            Context.Users.Add(MirzodalerWorker);
            Context.Users.Add(AhrorWorker);
            Context.Users.Add(JavohirWorker);
            Context.Users.Add(DalerWorker);
            Context.Users.Add(UsmonjonWorker);

            Context.SaveChanges();
        }
    }
}
