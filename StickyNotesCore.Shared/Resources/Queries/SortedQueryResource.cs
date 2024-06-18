using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyNotesCore.Shared.Resources.Queries
{
    public record SortedQueryResource : PagedQueryResource
    {
        /// <summary>
        /// The field name to sort records. The field name must be part of the matching model.
        /// </summary>
        public string? OrderBy { get; init; }

        /// <summary>
        /// The sort order for results. It can be 1 (Ascending) or 2 (Descending).
        /// </summary>
        [Required(ErrorMessage = "The sort order is required.")]
        public SortOrderResource SortOrder { get; init; }
    }
}
