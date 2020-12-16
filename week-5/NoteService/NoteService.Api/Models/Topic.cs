using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteService.Api.Models {
    public class Topic {
        public string Name { get; set; }
        public ICollection<Note> Notes { get; set; } = new HashSet<Note>();

        public Topic() {
            Notes.Add(new(new Author() { Id = 1, Name = "Matt" }) { Id = 1, Date = DateTime.Now, Message = "I hate math" });
        }

        public void AddNote(Note note) {
            Notes.Add(note);
        }
    }
}
