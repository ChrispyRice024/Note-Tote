using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Note_Tote.Classes;
using Note_Tote.DB;

namespace Note_Tote.Controls
{
    /// <summary>
    /// Interaction logic for NoteGrid.xaml
    /// </summary>
    public partial class NoteGrid : UserControl
    {
        private List<Note> ListOfNotes;
        public NoteGrid()
        {
            InitializeComponent();
            ListOfNotes = PopulateList();
            InitializeGrid();
        }

        private List<Note> PopulateList()
        {
            var db = SQLServer.ReadDb();
            if (db == null)
                return null;
            else
                return db.ToList<Note>();
        }

        public void InitializeGrid()
        {
            UniformGrid grid = NotesUGrid;
            ListOfNotes = PopulateList();

            int cellNum = 0;
            double width = grid.ActualWidth;
            double cellWidth = 150.0;

            grid.Children.Clear();
            grid.Columns = (int)(width / cellWidth);
            
            foreach(Note note in ListOfNotes)
            {
                cellNum++;

                var cell = new NoteCell(
                    callback: InitializeGrid,
                    name: note.NoteName,
                    desc: note.NoteDesc,
                    id: note.Id,
                    cellId: cellNum,
                    startDate: note.StartDate.ToString(),
                    dueDate: note.DueDate.ToString());

                NotesUGrid.Children.Add(cell);
            }
        }
    }
}
