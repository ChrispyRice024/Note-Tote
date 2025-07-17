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

namespace Note_Tote.Controls
{
    /// <summary>
    /// Interaction logic for MenuBar.xaml
    /// </summary>
    public partial class MenuBar : UserControl
    {
        private MainWindow _mainWindow;
     
        public MenuBar()
        {
            InitializeComponent();
            _mainWindow = (MainWindow)Application.Current.MainWindow;
        }

        private void NewNote_Click(object sender, RoutedEventArgs e)
        {

            //TODO: open new note window
            _mainWindow.OpenNewNoteWindow();
            //TODO: maybe have a validation(check that the
            //newest note is the same as the note that was just made)

            //TODO: after window is closed, reset the main window
        }

        private void SaveNote_Click(object sender, RoutedEventArgs e)
        {
            //probably not needed since the note will be made in a new window
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            //TODO: window.close(or whatever)
        }
    }
}
