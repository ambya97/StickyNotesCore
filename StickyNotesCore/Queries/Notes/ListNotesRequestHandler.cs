using MediatR;
using StickyNotesCore.Domain.Data.Queries.Shared;
using StickyNotesCore.Domain.Logic.Repository;
using StickyNotesCore.Domain.Models;
using StickyNotesCore.Domain.Queries.Notes;

namespace StickyNotesCore.Queries.Notes
{
    public class ListNotesRequestHandler : IRequestHandler<ListNotesRequest, List<Note>>
    {
        private readonly INotes _notes;
        public ListNotesRequestHandler(INotes notes)
        {
            _notes = notes;
        }

        public async Task<List<Note>> Handle(ListNotesRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _notes.GetAllNotes();
        }
    }
}
