using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scrum.Model;
using Scrum.SQL;

namespace Scrum.ViewModels
{
    public class WorkerViewModel : BaseViewModel
    {
        private EntityContext Context;
        public WorkerViewModel(Company selectedCompany)
        {
            Context = new EntityContext();
            SelectedCompany = selectedCompany;
        }

        Company selectedCompany;
        public Company SelectedCompany
        {
            get => selectedCompany;
            set { selectedCompany = value; OnPropertyChanged(); }
        }

        string _name;
        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        string lastName;
        public string LastName
        {
            get => lastName;
            set { lastName = value; OnPropertyChanged(); }
        }


        ObservableCollection<User> _workers;
        public ObservableCollection<User> Workers
        {
            get
            {
                if (_workers == null)
                {
                    _workers = new ObservableCollection<User>(Context.GetEntities<User>());
                }
                return _workers;
            }
            set { _workers = value; OnPropertyChanged(); }
        }

    }
}
