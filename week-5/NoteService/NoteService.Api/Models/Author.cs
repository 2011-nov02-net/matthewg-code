using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NoteService.Api.Models {
    public class Author {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Note> Notes { get; set; }

        public Author() {
            Notes = new HashSet<Note>();
        }
    }
}
