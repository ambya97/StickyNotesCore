﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyNotesCore.Shared.Resources.Queries
{
    public record PagedQueryResource
    {
        /// <summary>
        /// The current page to return results, starting with page 1.
        /// </summary>
        [Required(ErrorMessage = "The page is required.")]
        public int Page { get; init; }

        /// <summary>
        /// The number of items to return per page.
        /// </summary>
        [Required(ErrorMessage = "The number of items per page is required.")]
        public int ItemsPerPage { get; init; }
    }
}
