using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacement.Core.Interfaces
{
    public interface IResult
    {
        string message { get; set; }

        string message_Id { get; set; }

        bool succeeded { get; set; }
    }

    public interface IResult<out T> : IResult
    {
        T data { get; }
    }
}
