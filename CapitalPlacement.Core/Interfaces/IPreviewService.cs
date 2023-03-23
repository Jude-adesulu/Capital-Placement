using CapitalPlacement.Core.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacement.Core.Interfaces
{
    public interface IPreviewService
    {
        Task<IResult<PreviewResponseModal>> GetPreview(string title);
    }
}
