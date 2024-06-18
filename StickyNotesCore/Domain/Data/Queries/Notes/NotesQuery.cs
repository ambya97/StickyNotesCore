using StickyNotesCore.Domain.Data.Queries.Shared;
using StickyNotesCore.Domain.Models;

namespace StickyNotesCore.Domain.Data.Queries.Notes
{
    public class NotesQuery : SortedQuery<Note>
    {
        public string? Text { get; init; }
    }
}
