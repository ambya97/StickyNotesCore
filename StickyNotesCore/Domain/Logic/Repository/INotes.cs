using StickyNotesCore.Domain.Models;

namespace StickyNotesCore.Domain.Logic.Repository
{
    public interface INotes
    {
        Task<Note> InsertUpdateNotes(Note note);
        Task<List<Note>> GetAllNotes();
        Task<Note> GetDetailById(Guid id);
        Task DeleteNote(Guid id);
        Task<Note> UpdateNotes(Note note);

    }
}
