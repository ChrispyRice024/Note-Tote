using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note_Tote.Classes
{
    public class Note
    {
        public string Id = Guid.NewGuid().ToString();
        public string NoteName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string NoteDesc { get; set; }

        public Note() { }
        /// <summary>
        /// Basic Note Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="start"></param>
        /// <param name="due"></param>
        /// <param name="desc"></param>
        public Note(string name, DateTime? start, DateTime? due, string desc)
        {
            NoteName = name;
            StartDate = start;
            DueDate = due;
            NoteDesc = desc;
        }
    }
}
