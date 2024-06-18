using MediatR;
using StickyNotesCore.Domain.Commands.Notes;
using StickyNotesCore.Domain.Logic.Repository;
using StickyNotesCore.Shared.Responses;

namespace StickyNotesCore.Commands.Notes
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, StatusResponse>
    {
        private readonly INotes _notes;
        private readonly ILogger<CreateNoteCommandHandler> _logger;
        public DeleteNoteCommandHandler(INotes notes, ILogger<CreateNoteCommandHandler> logger)
        {
            _notes = notes;
            _logger = logger;
        }

        public async Task<StatusResponse> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var note = await _notes.GetDetailById(request.Id);
            if (note == null)
            {
                return new StatusResponse($"The note with ID {request.Id} was not found.", Status.NotFound);
            }
            await _notes.DeleteNote(request.Id);
            _logger.LogInformation("Deleted note ID: {Id}.", note.Id);
            return new StatusResponse(Status.Deleted);
        }
    }
}
