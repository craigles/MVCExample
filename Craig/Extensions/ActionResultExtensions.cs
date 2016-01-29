using System.Web.Mvc;

namespace Craig.Extensions
{
    public static class ActionResultExtensions
    {
        public static ActionResult WithSuccess(this ActionResult actionResult, string message, ControllerBase controller)
        {
            controller.TempData["successMessage"] = message;
            return actionResult;
        }

        public static ActionResult WithError(this ActionResult actionResult, string message, ControllerBase controller)
        {
            controller.TempData["errorMessage"] = message;
            return actionResult;
        }
    }
}