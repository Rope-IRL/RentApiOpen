using RestFulAPI.Middleware;

namespace RestFulAPI.Helpers
{
    public static class AddDataIfDbEmpty
    {
        public static IApplicationBuilder UseAddData(this IApplicationBuilder app)
        {
            return app.UseMiddleware<AddDataMiddleware>();
        }
    }
}
