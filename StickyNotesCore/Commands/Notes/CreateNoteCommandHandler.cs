using MediatR;
using StickyNotesCore.Domain.Commands.Notes;
using StickyNotesCore.Domain.Logic.Repository;
using StickyNotesCore.Domain.Models;
using StickyNotesCore.Shared.Responses;

namespace StickyNotesCore.Commands.Notes
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, StatusResponse<Note>>
    {
        private readonly INotes _notes;
        private readonly ILogger<CreateNoteCommandHandler> _logger;
        public CreateNoteCommandHandler(INotes notes, ILogger<CreateNoteCommandHandler> logger)
        {
            _notes = notes;
            _logger = logger;
        }

        public async Task<StatusResponse<Note>> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var note = await _notes.InsertUpdateNotes(new Note
            {
                Id = null,
                Text = request.Text,
            });
            _logger.LogInformation("Added note ID {0}", note.Id);
            return new StatusResponse<Note>(note, Status.Created);
        }

       


    }
}
