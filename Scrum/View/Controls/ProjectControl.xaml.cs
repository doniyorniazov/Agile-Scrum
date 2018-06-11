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
using Scrum.Model;
using Scrum.ViewModels;

namespace Scrum.View.Controls
{
    /// <summary>
    /// Interaction logic for ProjectControl.xaml
    /// </summary>
    public partial class ProjectControl : UserControl
    {
        public Project Project { get; set; }
        public ProjectControl()
        {
            InitializeComponent();
            Project = DataContext as Project;
        }

        private void Project_Loaded(object sender, RoutedEventArgs e)
        {
            var project = (sender as dynamic).DataContext as Project;
            var sprints = project.Sprints;
            uiSprints.ItemsSource = sprints;
        }

        private void btnSprint_Clicked(object sender, RoutedEventArgs e)
        {
            var sprint = (sender as dynamic).DataContext as Sprint;
            var sprintWindow = new SprintWindow() { DataContext = new SprintViewModel(sprint) };
            sprintWindow.ShowDialog();
        }
    }
}
