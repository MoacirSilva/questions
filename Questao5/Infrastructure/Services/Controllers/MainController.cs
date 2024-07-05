using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Questao5.Infrastructure.Cross;

namespace Questao5.Infrastructure.Services.Controllers
{
    public class MainController : ControllerBase
    {
        protected readonly List<Notify> _notifications;
        protected readonly ILogger _logger;

        public MainController(ILogger<MainController> logger,
                              List<Notify> notifications)
        {
            _notifications = notifications;
            _logger = logger;
        }

        [NonAction]
        public bool IsValid()
        {
            return !_notifications.Any();
        }

        [NonAction]
        void LoggerException(Exception ex)
        {
            var err = new Log();
            err.StackTrace = ex.StackTrace;
            err.Message = ex.Message;
            err.Exception = ex.InnerException?.ToString();
            _logger.LogError(JsonConvert.SerializeObject(err));
        }

        [NonAction]
        protected async Task<IActionResult> ExecControllerAsync<T>
                            (Func<Task<T>> func)
        {
            try
            {
                return Response(await func());
            }
            catch (Exception ex)
            {
                LoggerException(ex);
                AddError(ex);
                return Response(null);
            }
        }

        [NonAction]
        protected new IActionResult Response(object result = null)
        {
            if (IsValid())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                data = result,
                errors = _notifications
            });
        }

        [NonAction]
        protected void AddError(Exception except)
        {
            _notifications.Add(new Notify { Message = except.Message });
        }

        [NonAction]

        protected void AddError(Notify erro)
        {
            _notifications.Add(erro);
        }
    }
}
