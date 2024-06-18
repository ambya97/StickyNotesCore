using MediatR;
using StickyNotesCore.Domain.Commands.Notes;
using StickyNotesCore.Domain.Logic.Repository;
using StickyNotesCore.Domain.Models;
using StickyNotesCore.Shared.Responses;

namespace StickyNotesCore.Commands.Notes
{
    public class PatchNoteCommandHandler : IRequestHandler<PatchNoteCommand, StatusResponse<Note>>
    {
        private readonly INotes _notes;
        private readonly ILogger<CreateNoteCommandHandler> _logger;
        public PatchNoteCommandHandler(INotes notes, ILogger<CreateNoteCommandHandler> logger)
        {
            _notes = notes;
            _logger = logger;
        }

        public async Task<StatusResponse<Note>> Handle(PatchNoteCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var note = await _notes.GetDetailById(request.Id);
            if (note == null)
            {
                return new StatusResponse<Note>($"The note with ID {request.Id} was not found.", Status.NotFound);
            }
            var notedetails = _notes.UpdateNotes(new Note { Id = request.Id, Text = request.Text });
            _logger.LogInformation("Patched note ID {0}", note.Id);
            return new StatusResponse<Note>(note, Status.Patched);
        }
    }
}
