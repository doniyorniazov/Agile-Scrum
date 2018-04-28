using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using Scrum.Model;
using Scrum.SQL;
using Scrum.View;

namespace Scrum.ViewModels
{
    public class CompanyViewModel : BaseViewModel
    {
        private EntityContext Context;

        public CompanyViewModel()
        {
            Context = new EntityContext();
            InitCommands();
        } 

        Company selectedCompany;
        public Company SelectedCompany
        {
            get => selectedCompany;
            set { selectedCompany = value; OnPropertyChanged(); }
        }


        void InitCommands()
        {
            var canRemove = this.WhenAny(x => x.Company, (e) => e.Value != null);

            RemoveCommand = ReactiveCommand.CreateFromTask(async _ =>
            {
                var company = Context.GetEntities<Company>().FirstOrDefault(c => c == Company);
                if (company != null)
                {
                    Context.Companies.Remove(company);
                }
            }, canRemove);
        }

        private ICommand _removeCommand;

        public ICommand RemoveCommand
        {
            get => _removeCommand;
            set => _removeCommand = value;
        }

        Company _company;
        public Company Company
        {
            get => _company;
            set { _company = value; OnPropertyChanged(); }
        }

        ObservableCollection<Company> _comanies;
        public ObservableCollection<Company> Companies
        {
            get
            {
                if (_comanies == null)
                {
                    _comanies = new ObservableCollection<Company>(Context.GetEntities<Company>());
                }
                return _comanies;
            }

            set { _comanies = value; OnPropertyChanged(); }
        }
    }
}
