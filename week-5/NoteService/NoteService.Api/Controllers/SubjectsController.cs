using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteService.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteService.Api.Controllers {
    [Route("api/subjects")]
    [ApiController]
    public class SubjectsController : ControllerBase {
        private readonly ICollection<Subject> _subjects;

        public SubjectsController() {
            _subjects = new HashSet<Subject>() { new Subject() { Name = "Calculus" } };
        }

        [HttpGet]
        public IActionResult Get() {
            return Ok(_subjects);
        }

        [HttpGet("{subjectName}")]
        public IActionResult GetSubjectByName(string subjectName) {
            if (_subjects.FirstOrDefault(x => x.Name == subjectName) is Subject subject) {
                return Ok(subject);
            }
            return NotFound();
        }

        [HttpGet("{subjectName}/notes")]
        public IActionResult GetNotes(string subjectName) {
            if (_subjects.FirstOrDefault(x => x.Name == subjectName) is Subject subject) {
                return Ok(subject.GetNotes());
            }
            return NotFound();
        }

        [HttpGet("{subjectName}/notes/{id}")]
        public IActionResult GetNotesById(string subjectName, int id) {
            if (_subjects.FirstOrDefault(x => x.Name == subjectName) is Subject subject) {
                if (subject.GetNotes().FirstOrDefault(x => x.Id == id) is Note note) {
                    return Ok(note);
                }
            }
            return NotFound();
        }

        [HttpGet("{subjectName}/topics")]
        public IActionResult GetTopics(string subjectName) {
            if (_subjects.FirstOrDefault(x => x.Name == subjectName) is Subject subject) {
                return Ok(subject.Topics);
            }
            return NotFound();
        }

        [HttpGet("{subjectName}/topics/{topicName}")]
        public IActionResult GetTopicsByName(string subjectName, string topicName) {
            if (_subjects.FirstOrDefault(x => x.Name == subjectName) is Subject subject) {
                if (subject.Topics.FirstOrDefault(x => x.Name == topicName) is Topic topic) {
                    return Ok(topic);
                }
            }
            return NotFound();
        }

        [HttpGet("{subjectName}/topics/{topicName}/notes")]
        public IActionResult GetNotesByTopic(string subjectName, string topicName) {
            if (_subjects.FirstOrDefault(x => x.Name == subjectName) is Subject subject) {
                if (subject.Topics.FirstOrDefault(x => x.Name == topicName) is Topic topic) {
                    return Ok(topic.Notes);
                }
            }
            return NotFound();
        }

        [HttpGet("{subjectName}/topics/{topicName}/notes/{id}")]
        public IActionResult GetNotesByTopicById(string subjectName, string topicName, int id) {
            if (_subjects.FirstOrDefault(x => x.Name == subjectName) is Subject subject) {
                if (subject.Topics.FirstOrDefault(x => x.Name == topicName) is Topic topic) {
                    if (topic.Notes.FirstOrDefault(x => x.Id == id) is Note note) {
                        return Ok(note);
                    }
                }
            }
            return NotFound();
        }
    }
}
