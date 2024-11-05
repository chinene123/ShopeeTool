using System;
using System.Collections.Generic;
using System.IO;
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

namespace Shopee
{
    /// <summary>
    /// Interaction logic for RenameDialogWindow.xaml
    /// </summary>
    public partial class RenameDialogWindow : Window
    {
        public string NewName { get; private set; }

        public RenameDialogWindow(string currentPath)
        {
            InitializeComponent();
            NameTextBox.Text = System.IO.Path.GetFileName(currentPath);
        }

        private void OnOkClick(object sender, RoutedEventArgs e)
        {
            NewName = NameTextBox.Text;
            DialogResult = !string.IsNullOrEmpty(NewName);
        }
    }
}
