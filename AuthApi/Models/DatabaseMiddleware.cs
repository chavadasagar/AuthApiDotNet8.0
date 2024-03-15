using Microsoft.EntityFrameworkCore.Storage;

namespace AuthApi.Models
{
    public class DatabaseMiddleware
    {
        private readonly RequestDelegate _next;

        public DatabaseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Check if the header "Tenant-Database" is present in the request
            if (context.Request.Headers.ContainsKey("Tenant-Database"))
            {
                string tenantDatabase = context.Request.Headers["Tenant-Database"];

                // Here you can implement your logic to set the database object based on the tenantDatabase value
                // For example, you might have a service that resolves the database object based on the tenantDatabase value

                // For demonstration purposes, let's assume you have a DatabaseProvider service that provides the appropriate database object
                var databaseProvider = (IDatabaseProvider)context.RequestServices.GetService(typeof(IDatabaseProvider));
                //var database = databaseProvider.GetDatabase(tenantDatabase);

                // Set the database object in the request context for later use
                //context.Items["Database"] = database;
            }

            // Call the next middleware in the pipeline
            await _next(context);
        }
    }
}
