using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebHook;

namespace WebHook;

[ApiController]
[Route("")]
public class WebhookController : Controller
{
        const string VerfifyToken = "vinicius123!2";

        [HttpGet("webhook")]
        public ActionResult<string> SetupWebHook([FromQuery(Name = "hub.mode")] string hubMode,
                                                 [FromQuery(Name = "hub.challenge")] int hubChallenge,
                                                 [FromQuery(Name = "hub.verify_token")] string hubVerifyToken)
        {
            Console.WriteLine("█ WebHook with get executed. ");
            Console.WriteLine($"█ Parameters: hub_mode={hubMode}  hub_challenge={hubChallenge}  hub_verify_token={hubVerifyToken}");
            if (!hubVerifyToken.Equals(VerfifyToken))
            {
                return Forbid("VerifyToken doesn't match");
            }
            return Ok(hubChallenge);
        }

        [HttpPost("webhook")]
        public ActionResult ReceiveNotification([FromBody] string data)
        {
            Console.WriteLine("█ WebHook with Post executed. ");
            Console.WriteLine(data);
            return Ok();
        }

        public IActionResult Index()
        {
            return View();
        }
}
