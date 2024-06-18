using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyNotesCore.Shared.Resources.Queries
{
    public record QueryResultResource<TModel>
    {
        public List<TModel> Items { get; init; } = new List<TModel>();
        public int TotalItems { get; init; }
    }
}
