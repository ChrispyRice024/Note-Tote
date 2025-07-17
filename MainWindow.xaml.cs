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
        public MainWindow()
        {
            InitializeComponent();
            server = new SQLServer();
        }
        public void OpenNewNoteWindow()
        {
            DateTime now = DateTime.Now;
            NewNoteWindow = new NewNote(now, NotesGrid.InitializeGrid);
            NewNoteWindow.ShowDialog();
        }
    }
}
