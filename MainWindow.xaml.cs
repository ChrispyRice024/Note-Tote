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
using Note_Tote.Classes;
using Note_Tote.Controls;
using Note_Tote.DB;
using Note_Tote.Windows;

namespace Note_Tote
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public List<Note> NotesList { get; set; }
        private NewNote NewNoteWindow { get; set; }

        private SQLServer server;

        //private NoteGrid myNoteGrid = NoteGrid;
        public MainWindow()
        {
            InitializeComponent();
            MyNoteGrid.InitializeGrid();
            this.SizeChanged += (s, e) =>
            {
                MyNoteGrid.WindowWidth = this.Width;
                MyNoteGrid.InitializeGrid();
            };
            this.Loaded += (s, e) =>
            {
                MyNoteGrid.WindowWidth = this.Width;
            };
            server = new SQLServer();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void OpenNewNoteWindow()
        {
            DateTime now = DateTime.Now;
            NewNoteWindow = new NewNote(now, MyNoteGrid.InitializeGrid);
            NewNoteWindow.ShowDialog();
        }

    }
}
