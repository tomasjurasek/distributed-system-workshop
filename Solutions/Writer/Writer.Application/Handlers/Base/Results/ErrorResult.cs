using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Writer.Application.Handlers.Base
{
    public record ErrorResult
    {
        public IReadOnlyList<string> Errors { get; init; }
    }
}
