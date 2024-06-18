using MediatR;
using StickyNotesCore.Domain.Models;
using StickyNotesCore.Shared.Responses;

namespace StickyNotesCore.Domain.Commands.Notes
{
    public class PatchNoteCommand : IRequest<StatusResponse<Note>>
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = null!;
    }
}
