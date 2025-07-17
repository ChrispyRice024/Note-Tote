using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note_Tote.Classes
{
    public class NoteCell
    {
        public string NoteName { get; private set; }
        public string NoteDesc { get; private set; }
        public int CellId { get; private set; }
        public string NoteId { get; private set; }
        public NoteCell() { }

        public NoteCell(string name, string desc, string id, int cellId)
        {
            CellId = cellId;
            NoteId = id;
            NoteName = name;
            NoteDesc = desc;
        }
    }
}
