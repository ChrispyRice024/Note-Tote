using Note_Tote.DB;
using Swan;
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
    /// Interaction logic for NoteCell.xaml
    /// </summary>
    public partial class NoteCell : UserControl
    {
        public Action ReloadCallBack {  get; set; }

        public string NoteName { get; private set; }
        public string NoteDesc { get; private set; }
        public int CellId { get; private set; }
        public DateTime? StartDate { get; private set; }
        public DateTime? DueDate { get; private set; }
        public string NoteId { get; private set; }

        public NoteCell(string name, string desc, string id, int cellId, string startDate, string dueDate, Action callback)
        {
            InitializeComponent();
            ReloadCallBack = callback;

            CellId = cellId;
            NoteId = id;
            NoteName = name;
            NoteDesc = desc;

            DateTime due;
            if (DateTime.TryParse(dueDate, out due))
                DueDate = due;
            else
                StartDate = null;

            DateTime start;
            if (DateTime.TryParse(startDate, out start))
                StartDate = start;
            else
                StartDate = null;

            NoteNameTxt.Text = NoteName;
            NoteDescTxt.Text = NoteDesc;
            StartDateTxt.Text = StartDate?.ToString("d") ?? "-";
            DueDateTxt.Text = DueDate?.ToString("d") ?? "-";
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            SQLServer.DeleteRow(NoteId);

            if(ReloadCallBack != null)
                ReloadCallBack();
        }
    }
}
