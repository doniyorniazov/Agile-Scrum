using System.Collections.Generic;
using Scrum.Model;
using Scrum.SQL;
using System.Windows;
using System.Windows.Controls;
using Scrum.ViewModels;

namespace Scrum.View.Pages
{
    /// <summary>
    /// Interaction logic for CompanyPage.xaml
    /// </summary>
    public partial class CompanyPage : Window
    {
        public CompanyPage()
        {
            InitializeComponent();
            DataContext = new CompanyViewModel();
        }
    }
}
