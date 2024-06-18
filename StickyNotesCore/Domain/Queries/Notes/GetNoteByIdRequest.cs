using MediatR;
using StickyNotesCore.Domain.Models;
using StickyNotesCore.Shared.Responses;

namespace StickyNotesCore.Domain.Queries.Notes
{
    public record GetNoteByIdRequest : IRequest<StatusResponse<Note>>
    {
        public Guid Id { get; init; }
    }
}
