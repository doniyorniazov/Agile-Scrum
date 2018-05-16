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
using Scrum.Model;
using Scrum.ViewModels;

namespace Scrum.View.Controls
{
    /// <summary>
    /// Interaction logic for Company.xaml
    /// </summary>
    public partial class CompanyControl : UserControl
    {
        public CompanyControl()
        {
            InitializeComponent();
        }

        private void OpenProjects_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button.DataContext is Model.Company selectedCompany)
            {
                var projectWindow = new ProjectWindow() { DataContext = new ProjectViewModel(selectedCompany) };
                projectWindow.ShowDialog();
            }
        }

        private void Open_Users_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button.DataContext is Company selectedCompany)
            {
                var userWindow = new WorkerWindow() { DataContext = new WorkerViewModel(selectedCompany) };
                userWindow.ShowDialog();
            }
        }
    }
}
