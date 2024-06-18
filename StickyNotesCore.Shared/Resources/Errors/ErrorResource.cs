using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyNotesCore.Shared.Resources.Errors
{
    public record ErrorResource
    {
        public bool Success => false;
        public string Message { get; private set; }

        public ErrorResource(string? message)
        {
            Message = message ?? "An error happened when calling the API. Please, try again later.";
        }
    }
}
