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
    /// Interaction logic for NewNote.xaml
    /// </summary>
    public partial class NewNote : Window
    {
        private Action UIReload;

        private Note TempNote = new Note();

        public NewNote()
        {
            InitializeComponent();
        }
        public NewNote(DateTime dateTime, Action callback)
        {
            InitializeComponent();
            UIReload = callback;
            StartDatePicker.SelectedDate = dateTime;

            this.Closed += (s, e) =>
            {
                UIReload();
            };
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (NoteName.Text == "")
                return;
            if (NoteDesc.Text == "")
                return;
            DB.SQLServer.CreateRow(TempNote);
            ReloadModal();
        }

        private void ReloadModal()
        {
            double left = this.Left;
            double top = this.Top;
            var newModal = new NewNote();
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
