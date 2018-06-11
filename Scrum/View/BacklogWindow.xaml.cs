using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using Scrum.Model;
using Scrum.SQL;
using Scrum.ViewModels;
using Task = Scrum.Model.Task;

namespace Scrum.View
{
    /// <summary>
    /// Interaction logic for BacklogWindow.xaml
    /// </summary>
    public partial class BacklogWindow : CustomWindow
    {
        public BacklogWindow()
        {
            InitializeComponent();
            DataContext = new BacklogViewModel();
            //var DemoDataCreator = new DemoDataCreator();
            //DemoDataCreator.CreateTestCompany();
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var taskWindowInfo = new TaskInfoWindow();
            var task = (sender as dynamic).DataContext as Task;
            taskWindowInfo.DataContext = new TaskInfoViewModel(task);
            taskWindowInfo.Show();
        }
    }
}
