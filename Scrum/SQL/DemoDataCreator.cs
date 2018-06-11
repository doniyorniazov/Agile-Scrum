using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scrum.Model;
using TaskStatus = Scrum.Model.TaskStatus;

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
            SuperUser.Password = Security.HashSHA1("test");
            Context.Users.Add(SuperUser);

            // Company1
            var company1 = new Company(Context);
            company1.Name = "Silk Road Professionals";
            company1.Title =
                "We are one of the biggest programming team in Tajikistan that works in C#. And our goal is to achieve something.";

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
            company2.Title =
                "Our company is produces ASP.NET web sites and Desktop based application with .NET languages such as a C#";

            var project3 = new Project(Context);
            project3.Name = "Test Project 3";
            project3.Company = company2;

            var DalerWorker = new User(Context);
            DalerWorker.Name = "Daler";
            DalerWorker.LastName = "Yunusov";
            DalerWorker.Company = company1;
            project3.ProductOwner = DalerWorker;

            var AnyDevWorker = new User(Context);
            AnyDevWorker.Name = "Any";
            AnyDevWorker.LastName = "Dev";
            AnyDevWorker.Company = company2;
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

            var sprint = new Sprint(Context);
            project1.Sprints.Add(sprint);
            sprint.Number = "0001";
            sprint.StartDate = new DateTime(2018, 1, 1);
            sprint.EndDate = new DateTime(2018, 1, 14);

            sprint.Project = project1;

            var sprint1 = new Sprint(Context);
            project1.Sprints.Add(sprint);
            sprint1.Number = "0002";
            sprint1.StartDate = new DateTime(2018, 1, 15);
            sprint1.EndDate = new DateTime(2018, 1, 29);
            sprint1.Project = project1;

            var sprint2 = new Sprint(Context);
            project1.Sprints.Add(sprint);
            sprint2.Number = "0003";
            sprint2.StartDate = new DateTime(2018, 1, 30);
            sprint2.EndDate = new DateTime(2018, 2, 12);
            sprint2.Project = project1;

            var sprint3 = new Sprint(Context);
            project1.Sprints.Add(sprint);
            sprint3.Number = "0004";
            sprint3.StartDate = new DateTime(2018, 1, 13);
            sprint3.EndDate = new DateTime(2018, 2, 27);
            sprint3.Project = project1;

            Context.Companies.Add(company1);
            Context.Companies.Add(company2);

            Context.Projects.Add(project1);
            Context.Projects.Add(project2);
            Context.Projects.Add(project3);
            Context.Projects.Add(project4);

            Context.Sprints.Add(sprint);
            Context.Sprints.Add(sprint1);
            Context.Sprints.Add(sprint2);
            Context.Sprints.Add(sprint3);


            Context.Users.Add(DoniyorWorker);
            Context.Users.Add(TohirWorker);
            Context.Users.Add(AlisherWorker);
            Context.Users.Add(QutfulloWorker);
            Context.Users.Add(JamshedWorker);
            Context.Users.Add(AnyDevWorker);
            Context.Users.Add(AhrorWorker);
            Context.Users.Add(JavohirWorker);
            Context.Users.Add(DalerWorker);
            Context.Users.Add(UsmonjonWorker);

            var task1 = new Model.Task(Context);
            task1.RankNumber = 1;
            task1.Assignee = AnyDevWorker;
            task1.CreatedDate = new DateTime(2018, 5, 2);
            task1.TicketNumber = "000001";
            task1.TaskCreator = DoniyorWorker;
            task1.Size = 22;
            task1.Title = "Ҳалли масъалаи рақами 50 аз китоби Абрамян";
            task1.Description =
                "Адади натуралӣ адади комил номида мешавад, агар он ба ҳосили ҷамъи ҳамаи тақсимкунандаҳои худ (ба ғайр аз худи адад) баробар бошад.  Масалан, адади 6 адади натуралии комил аст, зеро 1+2+3=6, адади 8 адади натуралии комил нест зеро  . Адади натуралии n дода шудааст. Ададҳои комили хурд аз n бударо муайян кунед.";
            task1.Grooming = new Grooming(task1)
            {
                Task = task1,
                Architect = DalerWorker,
                Status = GroomingStatus.Needsgrooming
            };
            task1.Validation = new Validation(task1) { Validator = AlisherWorker, ValidationStatus = ValidationStatus.NeedsTesting };
            task1.CodeReview = new CodeReview(task1) { Reviewer = JavohirWorker, Status = CodeReviewStatus.NeedsCpr };


            var task2 = new Model.Task(Context);
            task2.RankNumber = 2;
            task2.Assignee = AnyDevWorker;

            task2.CreatedDate = new DateTime(2018, 5, 10);
            task2.TicketNumber = "000002";
            task2.Grooming = new Grooming(task2)
            {
                Architect = DalerWorker,
                Status = GroomingStatus.Needsgrooming
            };
            task2.TaskCreator = DoniyorWorker;
            task2.Size = 22;
            task2.Title = "Ҳалли масъалаи рақами 50 аз китоби Абрамян";
            task2.Description =
                "Адади натуралӣ адади комил номида мешавад, агар он ба ҳосили ҷамъи ҳамаи тақсимкунандаҳои худ (ба ғайр аз худи адад) баробар бошад.  Масалан, адади 6 адади натуралии комил аст, зеро 1+2+3=6, адади 8 адади натуралии комил нест зеро  . Адади натуралии n дода шудааст. Ададҳои комили хурд аз n бударо муайян кунед.";
            task2.Validation = new Validation(task2) { Validator = JamshedWorker, ValidationStatus = ValidationStatus.NeedsTesting };
            task2.CodeReview = new CodeReview(task2) { Reviewer = QutfulloWorker, Status = CodeReviewStatus.NeedsCpr };

            var task3 = new Model.Task(Context);
            task3.RankNumber = 3;
            task3.Assignee = AnyDevWorker;
            task3.CreatedDate = new DateTime(2018, 4, 13);
            task3.TicketNumber = "000003";
            task3.Grooming = new Grooming(task3)
            {
                Architect = DalerWorker,
                Status = GroomingStatus.Needsgrooming
            };
            task3.TaskCreator = DoniyorWorker;
            task3.Size = 4;
            task3.Title = "Ҳалли масъалаи рақами 50 аз китоби Абрамян";
            task3.Description =
                "Адади натуралӣ адади комил номида мешавад, агар он ба ҳосили ҷамъи ҳамаи тақсимкунандаҳои худ (ба ғайр аз худи адад) баробар бошад.  Масалан, адади 6 адади натуралии комил аст, зеро 1+2+3=6, адади 8 адади натуралии комил нест зеро  . Адади натуралии n дода шудааст. Ададҳои комили хурд аз n бударо муайян кунед.";
            task3.Validation = new Validation(task3) { Validator = JavohirWorker, ValidationStatus = ValidationStatus.NeedsTesting };
            task3.CodeReview = new CodeReview(task3) { Reviewer = DoniyorWorker, Status = CodeReviewStatus.NeedsCpr };

            var task4 = new Model.Task(Context);
            task4.RankNumber = 5;
            task4.Assignee = AnyDevWorker;
            task4.CreatedDate = new DateTime(2018, 4, 25);
            task4.TicketNumber = "000004";
            task4.Grooming = new Grooming(task4)
            {
                Task = task4,
                Architect = DalerWorker,
                Status = GroomingStatus.Needsgrooming
            };
            task4.TaskCreator = DoniyorWorker;
            task4.Size = 10;
            task4.Title = "Ҳалли масъалаи рақами 50 аз китоби Абрамян";
            task4.Description =
                "Адади натуралӣ адади комил номида мешавад, агар он ба ҳосили ҷамъи ҳамаи тақсимкунандаҳои худ (ба ғайр аз худи адад) баробар бошад.  Масалан, адади 6 адади натуралии комил аст, зеро 1+2+3=6, адади 8 адади натуралии комил нест зеро  . Адади натуралии n дода шудааст. Ададҳои комили хурд аз n бударо муайян кунед.";
            task4.Validation = new Validation(task4) { Validator = AnyDevWorker, ValidationStatus = ValidationStatus.NeedsTesting };
            task4.CodeReview = new CodeReview(task4) { Reviewer = TohirWorker, Status = CodeReviewStatus.NeedsCpr };

            var task5 = new Model.Task(Context);
            task5.RankNumber = 6;
            task5.Assignee = AnyDevWorker;
            task5.CreatedDate = new DateTime(2018, 5, 30);
            task5.TicketNumber = "000005";
            task5.Grooming = new Grooming(task5)
            {
                Task = task5,
                Architect = DalerWorker,
                Status = GroomingStatus.Needsgrooming
            };
            task5.TaskCreator = DoniyorWorker;
            task5.Size = 16;
            task5.Title = "Ҳалли масъалаи рақами 50 аз китоби Абрамян";
            task5.Description =
                "Адади натуралӣ адади комил номида мешавад, агар он ба ҳосили ҷамъи ҳамаи тақсимкунандаҳои худ (ба ғайр аз худи адад) баробар бошад.  Масалан, адади 6 адади натуралии комил аст, зеро 1+2+3=6, адади 8 адади натуралии комил нест зеро  . Адади натуралии n дода шудааст. Ададҳои комили хурд аз n бударо муайян кунед.";
            task5.Validation = new Validation(task5) { Validator = TohirWorker, ValidationStatus = ValidationStatus.NeedsTesting };
            task5.CodeReview = new CodeReview(task5) { Reviewer = DalerWorker, Status = CodeReviewStatus.NeedsCpr };

            var task6 = new Model.Task(Context);
            task6.RankNumber = 7;
            task6.Assignee = AnyDevWorker;
            task6.CreatedDate = new DateTime(2018, 3, 22);

            task6.TicketNumber = "000006";
            task6.Grooming = new Grooming(task6)
            {
                Task = task6,
                Architect = DalerWorker,
                Status = GroomingStatus.Needsgrooming
            };
            task6.TaskCreator = DoniyorWorker;
            task6.Size = 4;
            task6.Title = "Ҳалли масъалаи рақами 50 аз китоби Абрамян";
            task6.Description =
                "Адади натуралӣ адади комил номида мешавад, агар он ба ҳосили ҷамъи ҳамаи тақсимкунандаҳои худ (ба ғайр аз худи адад) баробар бошад.  Масалан, адади 6 адади натуралии комил аст, зеро 1+2+3=6, адади 8 адади натуралии комил нест зеро  . Адади натуралии n дода шудааст. Ададҳои комили хурд аз n бударо муайян кунед.";
            task6.Validation = new Validation(task6) { Validator = DalerWorker, ValidationStatus = ValidationStatus.NeedsTesting };
            task6.CodeReview = new CodeReview(task6) { Reviewer = DoniyorWorker, Status = CodeReviewStatus.NeedsCpr };

            var task7 = new Model.Task(Context);
            task7.RankNumber = 8;
            task7.Assignee = AnyDevWorker;
            task7.CreatedDate = new DateTime(2018, 4, 6);
            task7.TicketNumber = "000007";
            task7.Grooming = new Grooming(task7)
            {
                Task = task7,
                Architect = DalerWorker,
                Status = GroomingStatus.Needsgrooming
            };
            task7.TaskCreator = DoniyorWorker;
            task7.Size = 10;
            task7.Title = "Ҳалли масъалаи рақами 50 аз китоби Абрамян";
            task7.Description =
                "Адади натуралӣ адади комил номида мешавад, агар он ба ҳосили ҷамъи ҳамаи тақсимкунандаҳои худ (ба ғайр аз худи адад) баробар бошад.  Масалан, адади 6 адади натуралии комил аст, зеро 1+2+3=6, адади 8 адади натуралии комил нест зеро  . Адади натуралии n дода шудааст. Ададҳои комили хурд аз n бударо муайян кунед.";
            task7.Validation = new Validation(task7) { Validator = DoniyorWorker, ValidationStatus = ValidationStatus.NeedsTesting };
            task7.CodeReview = new CodeReview(task7) { Reviewer = TohirWorker, Status = CodeReviewStatus.NeedsCpr };

            var task8 = new Model.Task(Context);
            task8.RankNumber = 9;
            task8.Assignee = AnyDevWorker;
            task8.CreatedDate = new DateTime(2018, 5, 15);

            task8.TicketNumber = "000009";
            task8.Grooming = new Grooming(task8)
            {
                Task = task8,
                Architect = DalerWorker,
                Status = GroomingStatus.Needsgrooming
            };
            task8.TaskCreator = DoniyorWorker;
            task8.Size = 22;
            task8.Title = "Ҳалли масъалаи рақами 50 аз китоби Абрамян";
            task8.Description =
                "Адади натуралӣ адади комил номида мешавад, агар он ба ҳосили ҷамъи ҳамаи тақсимкунандаҳои худ (ба ғайр аз худи адад) баробар бошад.  Масалан, адади 6 адади натуралии комил аст, зеро 1+2+3=6, адади 8 адади натуралии комил нест зеро  . Адади натуралии n дода шудааст. Ададҳои комили хурд аз n бударо муайян кунед.";
            task8.Validation = new Validation(task8) { Validator = AhrorWorker, ValidationStatus = ValidationStatus.NeedsTesting };
            task8.CodeReview = new CodeReview(task8) { Reviewer = UsmonjonWorker, Status = CodeReviewStatus.NeedsCpr };

            var task9 = new Model.Task(Context);
            task9.RankNumber = 10;
            task9.CreatedDate = new DateTime(2018, 5, 15);

            task9.TicketNumber = "000010";
            task9.Assignee = AnyDevWorker;
            task9.Grooming = new Grooming(task9)
            {
                Task = task9,
                Architect = DalerWorker,
                Status = GroomingStatus.Needsgrooming
            };
            task9.TaskCreator = DoniyorWorker;
            task9.Size = 5;
            task9.Title = "Ҳалли масъалаи рақами 50 аз китоби Абрамян";
            task9.Description =
                "Адади натуралӣ адади комил номида мешавад, агар он ба ҳосили ҷамъи ҳамаи тақсимкунандаҳои худ (ба ғайр аз худи адад) баробар бошад.  Масалан, адади 6 адади натуралии комил аст, зеро 1+2+3=6, адади 8 адади натуралии комил нест зеро  . Адади натуралии n дода шудааст. Ададҳои комили хурд аз n бударо муайян кунед.";
            task9.Validation = new Validation(task9) { Validator = QutfulloWorker, ValidationStatus = ValidationStatus.NeedsTesting };
            task9.CodeReview = new CodeReview(task9) { Reviewer = JavohirWorker, Status = CodeReviewStatus.NeedsCpr };

            var task10 = new Model.Task(Context);
            task10.RankNumber = 11;
            task10.CreatedDate = new DateTime(2018, 5, 15);
            task10.TicketNumber = "000011";
            task10.Grooming = new Grooming(task10)
            {
                Task = task10,
                Architect = DalerWorker,
                Status = GroomingStatus.Needsgrooming
            };
            task10.TaskCreator = DoniyorWorker;
            task10.Size = 7;
            task10.Title = "Ҳалли масъалаи рақами 50 аз китоби Абрамян";
            task10.Description =
                "Адади натуралӣ адади комил номида мешавад, агар он ба ҳосили ҷамъи ҳамаи тақсимкунандаҳои худ (ба ғайр аз худи адад) баробар бошад.  Масалан, адади 6 адади натуралии комил аст, зеро 1+2+3=6, адади 8 адади натуралии комил нест зеро  . Адади натуралии n дода шудааст. Ададҳои комили хурд аз n бударо муайян кунед.";
            task10.Validation = new Validation(task10) { Validator = UsmonjonWorker, ValidationStatus = ValidationStatus.NeedsTesting };
            task10.CodeReview = new CodeReview(task10) { Reviewer = AlisherWorker, Status = CodeReviewStatus.NeedsCpr };

            var task11 = new Model.Task(Context);
            task11.RankNumber = 12;
            task11.CreatedDate = new DateTime(2018, 5, 15);
            task11.TicketNumber = "000012";
            task11.Assignee = AhrorWorker;
            task11.Grooming = new Grooming(task11)
            {
                Task = task11,
                Architect = DalerWorker,
                Status = GroomingStatus.Needsgrooming
            };
            task11.TaskStatus = TaskStatus.NotStarted;
            task11.TaskCreator = DoniyorWorker;
            task11.Size = 7;
            task11.Title = "Ҳалли масъалаи рақами 50 аз китоби Абрамян";
            task11.Description =
                "Адади натуралӣ адади комил номида мешавад, агар он ба ҳосили ҷамъи ҳамаи тақсимкунандаҳои худ (ба ғайр аз худи адад) баробар бошад.  Масалан, адади 6 адади натуралии комил аст, зеро 1+2+3=6, адади 8 адади натуралии комил нест зеро  . Адади натуралии n дода шудааст. Ададҳои комили хурд аз n бударо муайян кунед.";
            task11.Validation = new Validation(task11) { Validator = UsmonjonWorker, ValidationStatus = ValidationStatus.NeedsTesting };
            task11.CodeReview = new CodeReview(task11) { Reviewer = AlisherWorker, Status = CodeReviewStatus.NeedsCpr };

            var task12 = new Model.Task(Context);
            task12.RankNumber = 13;
            task12.Assignee = DoniyorWorker;
            task12.CreatedDate = new DateTime(2018, 5, 15);
            task12.TicketNumber = "000013";
            task12.Grooming = new Grooming(task12)
            {
                Task = task12,
                Architect = DalerWorker,
                Status = GroomingStatus.Needsgrooming
            };
            task12.TaskCreator = DoniyorWorker;
            task12.TaskStatus = TaskStatus.Started;
            task12.Size = 7;
            task12.Title = "Ҳалли масъалаи рақами 50 аз китоби Абрамян";
            task12.Description =
                "Адади натуралӣ адади комил номида мешавад, агар он ба ҳосили ҷамъи ҳамаи тақсимкунандаҳои худ (ба ғайр аз худи адад) баробар бошад.  Масалан, адади 6 адади натуралии комил аст, зеро 1+2+3=6, адади 8 адади натуралии комил нест зеро  . Адади натуралии n дода шудааст. Ададҳои комили хурд аз n бударо муайян кунед.";
            task12.Validation = new Validation(task12) { Validator = UsmonjonWorker, ValidationStatus = ValidationStatus.NeedsTesting };
            task12.CodeReview = new CodeReview(task12) { Reviewer = AlisherWorker, Status = CodeReviewStatus.NeedsCpr };

            var task13 = new Model.Task(Context);
            task13.RankNumber = 14;
            task13.Assignee = JavohirWorker;
            task13.CreatedDate = new DateTime(2018, 5, 15);
            task13.TicketNumber = "000014";
            task13.Grooming = new Grooming(task13)
            {
                Task = task13,
                Architect = DalerWorker,
                Status = GroomingStatus.Needsgrooming
            };
            task13.TaskCreator = DoniyorWorker;
            task13.TaskStatus = TaskStatus.Started;
            task13.Size = 20;
            task13.Title = "Ҳалли масъалаи рақами 50 аз китоби Абрамян";
            task13.Description =
                "Адади натуралӣ адади комил номида мешавад, агар он ба ҳосили ҷамъи ҳамаи тақсимкунандаҳои худ (ба ғайр аз худи адад) баробар бошад.  Масалан, адади 6 адади натуралии комил аст, зеро 1+2+3=6, адади 8 адади натуралии комил нест зеро  . Адади натуралии n дода шудааст. Ададҳои комили хурд аз n бударо муайян кунед.";
            task13.Validation = new Validation(task13) { Validator = UsmonjonWorker, ValidationStatus = ValidationStatus.NeedsTesting };
            task13.CodeReview = new CodeReview(task13) { Reviewer = AlisherWorker, Status = CodeReviewStatus.NeedsCpr };

            var task14 = new Model.Task(Context);
            task14.RankNumber = 15;
            task14.Assignee = AlisherWorker;
            task14.CreatedDate = new DateTime(2018, 5, 15);
            task14.TicketNumber = "000015";
            task14.Grooming = new Grooming(task14)
            {
                Task = task14,
                Architect = DalerWorker,
                Status = GroomingStatus.Needsgrooming
            };
            task14.TaskCreator = DoniyorWorker;
            task14.TaskStatus = TaskStatus.NotValidated;
            task14.Size = 16;
            task14.Title = "Ҳалли масъалаи рақами 50 аз китоби Абрамян";
            task14.Description =
                "Адади натуралӣ адади комил номида мешавад, агар он ба ҳосили ҷамъи ҳамаи тақсимкунандаҳои худ (ба ғайр аз худи адад) баробар бошад.  Масалан, адади 6 адади натуралии комил аст, зеро 1+2+3=6, адади 8 адади натуралии комил нест зеро  . Адади натуралии n дода шудааст. Ададҳои комили хурд аз n бударо муайян кунед.";
            task14.Validation = new Validation(task14) { Validator = UsmonjonWorker, ValidationStatus = ValidationStatus.NeedsTesting };
            task14.CodeReview = new CodeReview(task14) { Reviewer = AlisherWorker, Status = CodeReviewStatus.NeedsCpr };

            var task15 = new Model.Task(Context);
            task15.RankNumber = 15;
            task15.Assignee = TohirWorker;
            task15.CreatedDate = new DateTime(2018, 5, 15);
            task15.TicketNumber = "000016";
            task15.Grooming = new Grooming(task15)
            {
                Task = task15,
                Architect = DalerWorker,
                Status = GroomingStatus.Needsgrooming
            };
            task15.TaskCreator = DoniyorWorker;
            task15.TaskStatus = TaskStatus.NotValidated;
            task15.Size = 17;
            task15.Title = "Ҳалли масъалаи рақами 50 аз китоби Абрамян";
            task15.Description =
                "Адади натуралӣ адади комил номида мешавад, агар он ба ҳосили ҷамъи ҳамаи тақсимкунандаҳои худ (ба ғайр аз худи адад) баробар бошад.  Масалан, адади 6 адади натуралии комил аст, зеро 1+2+3=6, адади 8 адади натуралии комил нест зеро  . Адади натуралии n дода шудааст. Ададҳои комили хурд аз n бударо муайян кунед.";
            task15.Validation = new Validation(task15) { Validator = UsmonjonWorker, ValidationStatus = ValidationStatus.NeedsTesting };
            task15.CodeReview = new CodeReview(task15) { Reviewer = AlisherWorker, Status = CodeReviewStatus.NeedsCpr };

            var task16 = new Model.Task(Context);
            task16.RankNumber = 18;
            task16.Assignee = UsmonjonWorker;
            task16.CreatedDate = new DateTime(2018, 5, 15);
            task16.TicketNumber = "000017";
            task16.Grooming = new Grooming(task16)
            {
                Task = task16,
                Architect = DalerWorker,
                Status = GroomingStatus.Needsgrooming
            };
            task16.TaskCreator = DoniyorWorker;
            task16.TaskStatus = TaskStatus.Completed;
            task16.Size = 6;
            task16.Title = "Ҳалли масъалаи рақами 50 аз китоби Абрамян";
            task16.Description =
                "Адади натуралӣ адади комил номида мешавад, агар он ба ҳосили ҷамъи ҳамаи тақсимкунандаҳои худ (ба ғайр аз худи адад) баробар бошад.  Масалан, адади 6 адади натуралии комил аст, зеро 1+2+3=6, адади 8 адади натуралии комил нест зеро  . Адади натуралии n дода шудааст. Ададҳои комили хурд аз n бударо муайян кунед.";
            task16.Validation = new Validation(task16) { Validator = UsmonjonWorker, ValidationStatus = ValidationStatus.NeedsTesting };
            task16.CodeReview = new CodeReview(task16) { Reviewer = AlisherWorker, Status = CodeReviewStatus.NeedsCpr };


            Context.Tasks.Add(task1);
            Context.Tasks.Add(task2);
            Context.Tasks.Add(task3);
            Context.Tasks.Add(task4);
            Context.Tasks.Add(task5);
            Context.Tasks.Add(task6);
            Context.Tasks.Add(task7);
            Context.Tasks.Add(task8);
            Context.Tasks.Add(task9);
            Context.Tasks.Add(task10);
            Context.Tasks.Add(task11);
            Context.Tasks.Add(task12);
            Context.Tasks.Add(task13);
            Context.Tasks.Add(task14);
            Context.Tasks.Add(task15);
            Context.Tasks.Add(task16);
            //Context.Tasks.Add(task10);

            Context.SaveChanges();
        }
    }
}
