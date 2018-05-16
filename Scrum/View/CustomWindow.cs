using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using MahApps.Metro.Controls;

namespace Scrum.View
{
    public class CustomWindow : MetroWindow
    {
        public CustomWindow()
        {
            this.Initialized += CustomWindow_Initialized;

        }

        private void CustomWindow_Initialized(object sender, EventArgs e)
        {
            var saveButton = new Button() { Content = "", FontFamily = new FontFamily("Segoe MDL2 Assets") };
            saveButton.SetBinding(ButtonBase.CommandProperty, new Binding("SaveCommand"));
            RightWindowCommands = new WindowCommands();
            RightWindowCommands.Items.Add(saveButton);
        }
    }
}
