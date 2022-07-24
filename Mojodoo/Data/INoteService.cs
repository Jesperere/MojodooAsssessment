namespace Mojodoo.Data
{
    public interface INoteService
    {
        List<Note> Notes { get; set; }
        Task LoadNotes();
        Task<Note> GetSingleNote(int id);
        Task CreateNote(Note note);
        Task UpdateNote(Note note, int id);
        Task DeleteNote(int id);

        Task SearchNotes(string searchText); // cant get this to work

    }
}
