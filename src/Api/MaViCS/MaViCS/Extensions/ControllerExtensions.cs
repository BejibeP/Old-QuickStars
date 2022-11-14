using Microsoft.AspNetCore.Mvc;
using QuickStars.MaViCS.Business;

namespace QuickStars.MaViCS.Extensions
{
    public static class ControllerExtensions
    {
        public static ActionResult FromResult<T>(this ControllerBase controller, ServiceResult<T> result)
        {
            switch (result.Type)
            {
                case ResultType.Ok:
                    return controller.Ok(result.GetValue());
                case ResultType.Created:
                    return controller.Ok(result.GetValue());
                case ResultType.NoContent:
                    return controller.NoContent();
                case ResultType.BadRequest:
                    return controller.BadRequest(result.Messages);
                case ResultType.Unauthorized:
                    return controller.Unauthorized(result.Messages);
                case ResultType.Forbidden:
                    return controller.Forbid();
                case ResultType.NotFound:
                    return controller.NotFound(result.Messages);
                case ResultType.ServerError:
                    return controller.BadRequest(result.Messages);
                default:
                    throw new Exception("An unhandled result has occurred as a result of a service call.");
            }
        }

        public static object? GetValue<T>(this ServiceResult<T> result)
        {
            if (result.Value is null)
                return result.Messages;

            return result.Value;
        }

    }
}
