using StickyNotesCore.Shared.Resources.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyNotesCore.Shared.Resources.Notes
{
    public record NotesQueryResource : SortedQueryResource
    {
        public string? Text { get; init; }
    }
}
