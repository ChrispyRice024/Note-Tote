using Note_Tote.Classes;
using Note_Tote.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

namespace Note_Tote.Windows
{
    /// <summary>
    /// Interaction logic for NoteDetails.xaml
    /// </summary>
    public partial class NoteDetails : Window
    {
        private Note SelectedNote;

        private NoteForm UpdateNoteForm;
        private Action UIReload;
        public NoteDetails(Note selectedNote, Action callback)
        {
            InitializeComponent();

            UIReload = callback;
            SelectedNote = selectedNote;

            NoteNameTxt.Text = SelectedNote.NoteName;
            NoteDescTxt.Text = SelectedNote.NoteDesc;
            if(SelectedNote.StartDate == DateTime.MinValue)
            {
                StartDateTxt.Text = "-";
            }
            else
            {
                StartDateTxt.Text = SelectedNote.StartDate?.ToString("MM-dd-yy");
            }
            if (SelectedNote.DueDate == DateTime.MinValue)
            {
                DueDateTxt.Text = "-";
            }
            else
            {
                DueDateTxt.Text = SelectedNote.DueDate?.ToString("MM-dd-yy");
            }

            this.Closed += (s, e) =>
            {
                UIReload();
            };
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            SQLServer.DeleteRow(SelectedNote.Id);

            //if (ReloadNote != null)
            //{
                Debug.WriteLine("before reload callback");
                //ReloadNote();
            //}
            //else
            //{
            //    Debug.WriteLine("there is no reload callback");
            //}
        }
        bool isUpdate = false;
        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            bool isUpdate = true;
            UpdateNoteForm = new NoteForm(SelectedNote, UIReload, isUpdate);

            this.Close();
            UpdateNoteForm.ShowDialog();
        }
    }
}
