using MediatR;
using StickyNotesCore.Domain.Logic.Repository;
using StickyNotesCore.Domain.Models;
using StickyNotesCore.Domain.Queries.Notes;
using StickyNotesCore.Shared.Responses;

namespace StickyNotesCore.Queries.Notes
{
    public class GetNoteByIdRequestHandler : IRequestHandler<GetNoteByIdRequest, StatusResponse<Note>>
    {
        private readonly INotes _notes;
        public GetNoteByIdRequestHandler(INotes notes)
        {
            _notes = notes;
        }
        public async Task<StatusResponse<Note>> Handle(GetNoteByIdRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var note=await _notes.GetDetailById(request.Id);
            if(note == null)
            {
                return new StatusResponse<Note>($"The note with ID {request.Id} was not found.", Status.NotFound);
            }
            return new StatusResponse<Note>(note, Status.Completed);
       }
    }
}
