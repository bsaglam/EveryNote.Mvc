using EveryNote.DataAccessLayer.EntityFramework;
using EveryNote.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryNote.BussinessLayer
{
    public class NoteManager
    {
        Repository<Notes> repo = new Repository<Notes>();

        public List<Notes> GetAllNotes()
        {
            return repo.List();
        }
    }
}
