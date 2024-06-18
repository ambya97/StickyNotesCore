using MediatR;
using StickyNotesCore.Domain.Data.Queries.Notes;
using StickyNotesCore.Domain.Data.Queries.Shared;
using StickyNotesCore.Domain.Models;

namespace StickyNotesCore.Domain.Queries.Notes
{
    public class ListNotesRequest : IRequest<List<Note>>
    {
       // public NotesQuery Query { get; init; } = null!;
    }
}
