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
    /// Interaction logic for BackLogDataGrid.xaml
    /// </summary>
    public partial class BackLogDataGrid : UserControl
    {
        public BackLogDataGrid()
        {
            InitializeComponent();
            this.DataContext = new TasksViewModel();
        }
    }
}
