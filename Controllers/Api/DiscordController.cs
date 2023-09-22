using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WarOfRightsWeb.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DiscordController : ControllerBase
    {
        private ILogger<DiscordController> _logger;

        public DiscordController(ILogger<DiscordController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Interactions()
        {
            var request = HttpContext.Request;

            var sb = new StringBuilder();
            sb.AppendLine($"Method: {request.Method}");
            sb.AppendLine($"Scheme: {request.Scheme}");
            sb.AppendLine($"Host: {request.Host}");
            sb.AppendLine($"Path: {request.Path}");
            sb.AppendLine($"QueryString: {request.QueryString}");

            // Inspecting headers
            sb.AppendLine("Headers:");
            foreach (var header in request.Headers)
            {
                sb.AppendLine($"{header.Key}: {header.Value}");
            }

            // Read the body content
            request.EnableBuffering(); // This allows us to rewind the stream after reading
            using (var reader = new StreamReader(request.Body, Encoding.UTF8, leaveOpen: true))
            {
                var bodyContent = await reader.ReadToEndAsync();
                sb.AppendLine($"Body: {bodyContent}");
                request.Body.Position = 0; // Rewind the stream for subsequent middleware/handlers
            }

            _logger.LogInformation(sb.ToString());

            return Ok();
        }
    }
}
