using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteService.Api.Models {
    public class Subject {
        public string Name { get; set; }
        public ICollection<Topic> Topics { get; set; } = new HashSet<Topic>();

        public Subject() {
            Topics.Add(new() { Name = "Derivation" });
            Topics.Add(new() { Name = "Integration" });
        }

        public void AddTopic(Topic topic) {
            Topics.Add(topic);
        }

        public ICollection<Note> GetNotes() {
            ICollection<Note> notes = new HashSet<Note>();
            foreach (var topic in Topics) {
                notes = notes.Concat(topic.Notes).ToHashSet();
            }
            return notes;
        }

        public ICollection<Author> GetAuthors() {
            var authors = new HashSet<Author>();
            foreach (var topic in Topics) {
                foreach (var note in topic.Notes) {
                    if (!authors.Contains(note.Author)) {
                        authors.Add(note.Author);
                    }
                }
            }
            return authors;
        }
    }
}
