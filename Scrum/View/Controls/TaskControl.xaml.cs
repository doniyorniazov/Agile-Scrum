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
using MaterialDesignThemes.Wpf;
using Scrum.ViewModels;
using Task = Scrum.Model.Task;

namespace Scrum.View.Controls
{
    /// <summary>
    /// Interaction logic for TaskControl.xaml
    /// </summary>
    public partial class TaskControl : UserControl
    {
        public Model.Task Task { get; set; }

        public TaskControl()
        {
            InitializeComponent();
        }

        private void OpenTask_Click(object sender, RoutedEventArgs e)
        {
            var taskWindowInfo = new TaskInfoWindow();
            var task = (sender as dynamic).DataContext as Task;
            taskWindowInfo.DataContext = new TaskInfoViewModel(task);
            taskWindowInfo.Show();
        }
    }
}
