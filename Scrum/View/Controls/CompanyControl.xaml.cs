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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Userwindow = new UserWindow();
            Userwindow.ShowDialog();
        }

        private void OpenProjects_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button.DataContext is Model.Company selectedCompany)
            {
                var ProjectWindow = new ProjectWindow() { DataContext = new ProjectViewModel(selectedCompany) };
                ProjectWindow.ShowDialog();
            }
        }
    }
}
