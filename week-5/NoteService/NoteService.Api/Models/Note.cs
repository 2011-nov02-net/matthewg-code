using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteService.Api.Models {
    public class Note {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Author Author { get; set; }
        public string Message { get; set; }

        public Note(Author author) {
            Author = author;
            Author.Notes.Add(this);
        }
    }
}
