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
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using Scrum.ViewModels;

namespace Scrum.View
{
    /// <summary>
    /// Interaction logic for SprintWindow.xaml
    /// </summary>
    public partial class SprintWindow : CustomWindow
    {
        public SprintWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var backlog = new BacklogWindow();
            backlog.ShowDialog();
        }
    }
}
