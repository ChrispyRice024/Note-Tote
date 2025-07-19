using Note_Tote.Classes;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for NoteForm.xaml
    /// </summary>
    public partial class NoteForm : Window
    {
        private Action UIReload;

        private Note TempNote = new Note();
        private bool IsUpdate = false;

        public NoteForm()
        {
            InitializeComponent();
        }
        public NoteForm(DateTime dateTime, Action callback)
        {
            InitializeComponent();
            UIReload = callback;
            StartDatePicker.SelectedDate = dateTime;

            this.Closed += (s, e) =>
            {
                UIReload();
            };
        }

        public NoteForm(Note note, Action callback, bool isUpdate)
        {
            InitializeComponent();
            TempNote.Id = note.Id;

            TempNote.NoteName = note.NoteName;
            NoteName.Text = note.NoteName;

            TempNote.NoteDesc = note.NoteDesc;
            NoteDesc.Text = note.NoteDesc;

            TempNote.StartDate = note.StartDate;
            StartDatePicker.SelectedDate = note.StartDate;

            TempNote.DueDate = note.DueDate;
            DueDatePicker.SelectedDate = note.DueDate;

            UIReload = callback;

            IsUpdate = isUpdate;

            this.Closed += (s, e) =>
            {
                UIReload();
            };
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            //TODO: add error feedback to each nested if()

            if (IsUpdate)
            {
                Debug.WriteLine("Beginning of IsUpdate");
                if (NoteName.Text == "")
                    return;
                if (NoteDesc.Text == "")
                    return;
                DB.SQLServer.UpdateRow(TempNote);
                Debug.WriteLine("Ending of IsUpdate");
                this.Close();
            }
            else
            {
                if (NoteName.Text == "")
                    return;
                if (NoteDesc.Text == "")
                    return;
                DB.SQLServer.CreateRow(TempNote);
                ReloadModal();
            }
        }

        private void ReloadModal()
        {
            double left = this.Left;
            double top = this.Top;
            var newModal = new NoteForm();
            newModal.Left = left;
            newModal.Top = top;
            newModal.Show();
            this.Close();
        }
        private void NoteName_TextChanged(object sender, TextChangedEventArgs e)
        {
            TempNote.NoteName = NoteName.Text;
        }

        private void NoteDesc_TextChanged(object sender, TextChangedEventArgs e)
        {
            TempNote.NoteDesc = NoteDesc.Text;
        }
        private void StartDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            TempNote.StartDate = StartDatePicker.SelectedDate;
        }

        private void DueDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            TempNote.DueDate = DueDatePicker.SelectedDate;
        }
    }
}
