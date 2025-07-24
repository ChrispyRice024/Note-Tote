using Note_Tote.Classes;
using Note_Tote.DB;
using Note_Tote.Windows;
using Swan;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
        public Note CurrentNote { get; private set; }

        private NoteDetails DetailsWindow;
        private NoteForm UpdateForm;

        public NoteCell(Note note, Action callback)
        {
            InitializeComponent();

            ReloadCallBack = callback;
            CurrentNote = new Note();

            CurrentNote.Id = note.Id;

            //Setting Note Data
            CurrentNote.NoteDesc = note.NoteDesc;
            CurrentNote.NoteName = note.NoteName;
            CurrentNote.StartDate = note.StartDate;
            CurrentNote.DueDate = note.DueDate;

            //Setting Text Elements
            NoteNameTxt.Text = CurrentNote.NoteName;
            NoteDescTxt.Text = CurrentNote.NoteDesc;

            if (CurrentNote.StartDate == DateTime.MinValue)
            {
                StartDateTxt.Text = "----";
            }
            else
            {
                StartDateTxt.Text = CurrentNote.StartDate?.ToString("d") ?? "-";
            }
            if (CurrentNote.DueDate == DateTime.MinValue)
            {
                DueDateTxt.Text = "----";
            }
            else
            {
                DueDateTxt.Text = CurrentNote.DueDate?.ToString("d") ?? "-";
            }

            
            
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            SQLServer.DeleteRow(CurrentNote.Id);

            if(ReloadCallBack != null)
            {
                Debug.WriteLine("before reload callback");
                ReloadCallBack();
            }
            else
            {
                Debug.WriteLine("there is no reload callback");
            }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            bool isUpdate = true;
            UpdateForm = new NoteForm(CurrentNote, ReloadCallBack, isUpdate);
            UpdateForm.ShowDialog();
        }

        private void NoteCell_Click(object sender, RoutedEventArgs e)
        {
            DetailsWindow = new NoteDetails(CurrentNote, ReloadCallBack);

            DetailsWindow.Show();
        }
    }
}
