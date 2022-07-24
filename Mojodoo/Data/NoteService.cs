using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace Mojodoo.Data
{
    public class NoteService : INoteService
    {
        private readonly DataContext _context;
        private readonly NavigationManager _navigationManager;

        public NoteService(DataContext context, NavigationManager navigationManager )
        {
           _context = context;
           _navigationManager = navigationManager;
           _context.Database.EnsureCreated();
        }

        public List<Note> Notes { get; set; } = new List<Note>();

        public async Task CreateNote(Note note)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("todolist");

        }

        public async Task DeleteNote(int id)
        {
            var dbNote = await _context.Notes.FindAsync(id);
            if (dbNote == null)
                throw new Exception("No note here.");

            _context.Notes.Remove(dbNote);
            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("todolist");
        }

        public async Task<Note> GetSingleNote(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note == null)
                throw new Exception("No note here.");
            return note;
        }

        public async Task LoadNotes()
        {
            Notes = await _context.Notes.ToListAsync();
        }


        public Task SearchNotes(string searchText) // cant get this to work
        {
            var notes = _context.Notes.Where(n => n.Todo.Contains(searchText));
            return notes.ToListAsync();
        }

        public async Task UpdateNote(Note note, int id)
        {
            var dbNote = await _context.Notes.FindAsync(id);
            if(dbNote == null)
                throw new Exception("No note here.");

            dbNote.Todo = note.Todo;
            dbNote.CreatedDate = note.CreatedDate;

            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("todolist");

        }

      
    }
}
