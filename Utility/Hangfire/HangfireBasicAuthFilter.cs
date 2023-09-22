using System;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WarOfRightsWeb.Models;
using Hangfire.Dashboard;

namespace WarOfRightsWeb.Utility.Hangfire
{
    public class HangfireBasicAuthFilter : IDashboardAuthorizationFilter
    {
        public const string AuthenticationScheme = "Basic";


        private static LoginModel _userConfig;


        public bool Authorize(DashboardContext context)
        {
            var httpContext = context.GetHttpContext();
            var logger = httpContext.RequestServices
                .GetRequiredService<ILogger<HangfireBasicAuthFilter>>();
            var userConfiguration = GetUserConfig(httpContext);
            var header = httpContext.Request.Headers["Authorization"];

            if (string.IsNullOrWhiteSpace(header))
            {
                logger.LogDebug("Request is missing Authorization header value.");
                SetChallengeResponse(httpContext);
                return false;
            }

            var authValues = AuthenticationHeaderValue.Parse(header);
            if (authValues.Parameter is null)
            {
                logger.LogWarning("Request header authentication could not be parsed: {Header}", header);
                SetChallengeResponse(httpContext);
                return false;
            }

            if (!AuthenticationScheme.Equals(authValues.Scheme, StringComparison.InvariantCultureIgnoreCase))
            {
                logger.LogWarning("Request authentication scheme differs: {AuthenticationsScheme}", authValues.Scheme);
                SetChallengeResponse(httpContext);
                return false;
            }

            var parameterBytes = Convert.FromBase64String(authValues.Parameter);
            var parameter = System.Text.Encoding.UTF8.GetString(parameterBytes);
            var parts = parameter.Split(':');
            if (parts.Length != 2)
            {
                logger.LogWarning("Request basic Authorization header contains invalid amount of parts: {AuthValuesParameter}.", parameter);
                SetChallengeResponse(httpContext);
                return false;
            }

            var username = parts[0];
            var password = parts[1];

            if (string.IsNullOrEmpty(username))
            {
                logger.LogDebug("Authentication does not provide a user value.");
                SetChallengeResponse(httpContext);
                return false;
            }

            if (!username.Equals(userConfiguration.UserName))
            {
                logger.LogDebug("Provided username is not supported: '{Username}'", username);
                SetChallengeResponse(httpContext);
                return false;
            }

            if (string.IsNullOrEmpty(password))
            {
                logger.LogDebug("Authentication does not provide a password value.");
                SetChallengeResponse(httpContext);
                return false;
            }

            if (!password.Equals(userConfiguration.Password))
            {
                logger.LogDebug("Provided password for the user is incorrect.");
                SetChallengeResponse(httpContext);
                return false;
            }

            // Hangfire requests for stats in dashboard are done in an interval
            // of a few seconds and will pollute the log if this is enabled
            // logger.LogDebug("User authorized successfully.");

            return true;
        }

        private static void SetChallengeResponse(HttpContext httpContext)
        {
            httpContext.Response.StatusCode = 401;
            httpContext.Response.Headers.Append("WWW-Authenticate", "Basic realm=\"Hangfire Administrator Dashboard\"");
            httpContext.Response.WriteAsync("Authentication is required.");
        }

        private static LoginModel GetUserConfig(HttpContext httpContext)
        {
            if (_userConfig == null)
            {
                var config = httpContext.RequestServices.GetRequiredService<IConfiguration>();
                _userConfig = config.GetSection("SiteUser").Get<LoginModel>();
            }

            return _userConfig;
        }
    }
}
