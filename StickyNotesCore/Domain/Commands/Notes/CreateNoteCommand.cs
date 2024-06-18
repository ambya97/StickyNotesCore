using MediatR;
using StickyNotesCore.Domain.Models;
using StickyNotesCore.Shared.Responses;

namespace StickyNotesCore.Domain.Commands.Notes
{
    public class CreateNoteCommand : IRequest<StatusResponse<Note>>
    {
        public string Text { get; set; } = null!;
    }
}
