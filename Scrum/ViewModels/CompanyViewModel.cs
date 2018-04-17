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
    public class CompanyViewModel : BaseViewModel
    {
        private EntityContext Context;

        public CompanyViewModel()
        {
            Context = new EntityContext();
        }

        Company selectedCompany;
        public Company SelectedCompany
        {
            get => selectedCompany;
            set { selectedCompany = value; OnPropertyChanged(); }
        }


        private string companyLogo;

        public string CompanyLogo
        {
            get
            {
                if (SelectedCompany != null)
                {
                    var splittedCompanyName = SelectedCompany.Name.Split(' ');
                    foreach (var word in splittedCompanyName)
                    {
                        companyLogo += word.Substring(0, 1);
                    }
                }
                return companyLogo;
            }

            set { companyLogo = value; }
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
