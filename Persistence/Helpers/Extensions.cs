
using Microsoft.AspNetCore.Http;

namespace Persistence.Helpers
{
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application error:", message);
            response.Headers.Add("Access-Control-Expose-Headers", "ApplicationError");
            response.Headers.Add("Access-Control-Allow_Origin","*");
        }
    }
}