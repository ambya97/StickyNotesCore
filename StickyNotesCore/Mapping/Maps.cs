using AutoMapper;
using StickyNotesCore.Domain.Commands.Notes;
using StickyNotesCore.Domain.Data.Queries.Notes;
using StickyNotesCore.Domain.Data.Queries.Shared;
using StickyNotesCore.Domain.Models;
using StickyNotesCore.Shared.Resources.Notes;
using StickyNotesCore.Shared.Resources.Queries;

namespace StickyNotesCore.Mapping
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<Note, NoteResource>();

            CreateMap<CreateNoteResource, CreateNoteCommand>();
            CreateMap<PatchNoteResource, PatchNoteCommand>();

            CreateMap<NotesQueryResource, NotesQuery>();
            CreateMap<QueryResult<Note>, QueryResultResource<NoteResource>>();
        }
    }
}
