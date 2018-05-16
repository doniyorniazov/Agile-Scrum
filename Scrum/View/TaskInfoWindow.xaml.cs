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

namespace Scrum.View
{
    /// <summary>
    /// Interaction logic for TaskInfoWindow.xaml
    /// </summary>
    public partial class TaskInfoWindow : CustomWindow
    {
        public TaskInfoWindow()
        {
            InitializeComponent();
        }

        //private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        //{
        //    // ... Create a List of objects.
        //    //ObservableCollection<Test1> users = new ObservableCollection<Test1>();
        //    //users.Add(new Test1 { Id = "NIYDON", Korgar = "Niyozov Doniyor", Vaqt = "2.5", Malumot = "Ҳалли масъалаи рақами 29 аз китоби Златополский" });
        //    //users.Add(new Test1 { Id = "NIYDON", Korgar = "Niyozov Doniyor", Vaqt = "4", Malumot = "Ҳалли масъалаи рақами 60 аз китоби Златополский" });
        //    //users.Add(new Test1 { Id = "NIYDON", Korgar = "Niyozov Doniyor", Vaqt = "6", Malumot = "Ҳалли масъалаи рақами 70 аз китоби Златополский" });
        //    //users.Add(new Test1 { Id = "NIYDON", Korgar = "Niyozov Doniyor", Vaqt = "2", Malumot = "Ҳалли масъалаи рақами 64 аз китоби Златополский" });

        //    //// ... Assign ItemsSource of DataGrid.
        //    //var grid = sender as DataGrid;
        //    //grid.ItemsSource = users;
        //}
    }
}
