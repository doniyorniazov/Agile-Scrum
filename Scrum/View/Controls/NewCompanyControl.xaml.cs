using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Scrum.SQL;

namespace Scrum.View.Controls
{
    /// <summary>
    /// Interaction logic for NewCompanyControl.xaml
    /// </summary>
    public partial class NewCompanyControl : Window
    {
        public NewCompanyControl()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var name = txtName.Text;
            var title = txtTitle.Text;
            var context = new EntityContext();
            var company = new Scrum.Model.Company(context);
            company.Name = name;
            company.Title = title;
            context.Companies.Add(company);
            context.SaveChanges();
        }
    }
}
