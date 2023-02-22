using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoteApi.Models;
using NotesApi.Models;

namespace NotesProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly NotesContext _context;

        public NotesController(NotesContext context)
        {
            _context = context;
        }

        // GET api/notes
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var notes = await _context.Notes.ToListAsync();
                return Ok(notes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET api/notes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var note = await _context.Notes.FindAsync(id);

            if (note == null)
            {
                return NotFound();
            }

            return Ok(note);
        }

        // POST api/notes
        [HttpPost]
        public IActionResult CreateComment([FromBody] Note comment)
        {
            try
            {
                if (comment.ParentId != null && !_context.Notes.Any(c => c.Id == comment.ParentId))
                {
                    return BadRequest("Invalid parent comment ID.");
                }

                _context.Notes.Add(comment);
                _context.SaveChanges();

                return Ok(new { commentId = comment.Id });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            try
            {
                Note comment = _context.Notes.FirstOrDefault(c => c.Id == id);

                if (comment == null)
                {
                    return NotFound();
                }

                DeleteCommentAndChildren(comment.Id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        private void DeleteCommentAndChildren(int commentId)
        {
            Note comment = _context.Notes.FirstOrDefault(c => c.Id == commentId);

            if (comment == null)
            {
                return;
            }

            List<Note> childComments = _context.Notes.Where(c => c.ParentId == comment.Id).ToList();
            if (childComments.Count > 0)
            {
                foreach (Note childComment in childComments)
                {
                    DeleteCommentAndChildren(childComment.Id);
                }
            }

            _context.Notes.Remove(comment);
            _context.SaveChanges();
        }

    }
}
