using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyNotesCore.Shared.Resources.Notes
{
    public record NoteResource
    {
        public Guid Id { get; init; }
       // public DateTime CreatedOn { get; init; }
       // public DateTime? ModifiedOn { get; init; }
       public string Text { get; init; } = null!;
    }
}
