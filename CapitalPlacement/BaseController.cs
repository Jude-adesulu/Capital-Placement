using CapitalPlacement.Core.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace CapitalPlacement
{
        [ApiController]
        public abstract class BaseController<T> : ControllerBase
        {
            /// <summary>
            /// 
            /// </summary>
            /// <typeparam name="RT"></typeparam>
            /// <param name="data"></param>
            /// <param name="success"></param>
            /// <param name="message"></param>
            /// <param name="message_id"></param>
            /// <returns></returns>
            [NonAction]
            [ApiExplorerSettings(IgnoreApi = true)]
            public ActionResult ApiResponse<RT>(RT data = default(RT), bool success = false, string message = "", string message_id = "")
            {
                Result<RT> response = new Result<RT>
                {
                    message = message,
                    data = data,
                    succeeded = success,
                    message_Id = message_id
                };

                if (!response.succeeded)
                    return BadRequest(response);

                return Ok(response);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="success"></param>
            /// <param name="message"></param>
            /// <param name="message_id"></param>
            /// <returns></returns>
            [NonAction]
            [ApiExplorerSettings(IgnoreApi = true)]
            public ActionResult ApiResponse(bool success = false, string message = "", string message_id = "")
            {
                Result response = new Result
                {
                    message = message,
                    succeeded = success,
                    message_Id = message_id
                };

                if (!response.succeeded)
                    return BadRequest(response);

                return Ok(response);
            }
        }
}
