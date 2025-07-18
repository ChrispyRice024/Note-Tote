using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
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
        public double WindowWidth;
        public NoteGrid()
        {
            InitializeComponent();
            
            ListOfNotes = PopulateList();
            System.Timers.Timer timer = new System.Timers.Timer(1000);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(DataTimer);
            timer.Enabled = true;

            this.Loaded += (s, e) =>
            {
                Debug.WriteLine("First WindowWidth: " + WindowWidth);
                InitializeGrid();
                Debug.WriteLine("Second WindowWidth: " + WindowWidth);
            };
        }
        private void DataTimer(object s, ElapsedEventArgs a)
        {
            Dispatcher.Invoke(() =>
            {
                Debug.WriteLine("This.Width = " + this.Width);
            });
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
            double cellWidth = 200.0;
            //double cellHeight = 150.0;

            
            grid.Children.Clear();
            grid.Columns = (int)Math.Floor((double)width / cellWidth);
            //Debug.WriteLine("width" + grid.ActualWidth);
            Debug.WriteLine("Width: " + this.Width);
            Debug.WriteLine("CellWidth: " + cellWidth);
            Debug.WriteLine("the numbers " + (int)Math.Floor((double)this.Width / cellWidth));
            
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
