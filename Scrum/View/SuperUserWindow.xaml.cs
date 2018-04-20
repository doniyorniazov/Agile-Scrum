using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
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
using MaterialDesignThemes.Wpf;
using Scrum.Model;
using Scrum.SQL;
using Scrum.View.Controls;
using Scrum.ViewModels;

namespace Scrum.View
{
    /// <summary>
    /// Interaction logic for SuperUserWindow.xaml
    /// </summary>
    public partial class SuperUserWindow : Window
    {
        private EntityContext Context;
        public SuperUserWindow()
        {
            InitializeComponent();
            Context = new EntityContext();
            var viewModel = new SuperUserViewModel();
            DataContext = viewModel;

            //var mouseUp = Observable.FromEventPattern<
            //        MouseButtonEventHandler,
            //        MouseButtonEventArgs>
            //    (h => MouseLeftButtonUp += h, h => MouseLeftButtonUp -= h);

            //var doubleClick = mouseUp.SelectMany(
            //    e => mouseUp.Take(1).Timeout(
            //        TimeSpan.FromMilliseconds(500),
            //        Observable.Empty<EventPattern<MouseButtonEventArgs>>()));

            //doubleClick.Select(_ => this.uiUsers.SelectedItem)
            //    .Where(x => x != null)
            //    .Subscribe(x => ((viewModel)).MyCommand.Execute(null));
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount >= 2)
            {

            }
        }

        private void Add_CompanyClik(object sender, RoutedEventArgs e)
        {
            var a = new NewCompanyControl();
            a.ShowDialog();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
