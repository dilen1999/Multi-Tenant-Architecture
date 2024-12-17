using MultiTenatArchitecture.Services;

namespace MultiTenatArchitecture.Middleware
{
    public class TenantResolver
    {
        private readonly RequestDelegate _next;
        public TenantResolver(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ICurrentTenantService currentTenantService)
        {
            context.Request.Headers.TryGetValue("tenant", out var tenantFromHeader); // Tenant Id from incoming request header
            if (string.IsNullOrEmpty(tenantFromHeader) == false)
            {
                await currentTenantService.SetTenant(tenantFromHeader);
            }

            await _next(context);
            //var tenantId = context.Request.Headers["TenantId"].ToString();
            //if (string.IsNullOrEmpty(tenantId))
            //{
            //    throw new Exception("TenantId is missing from the request.");
            //}

            //// Set TenantId in the service
            //currentTenantService.TenantId = tenantId;

            //await _next(context);
        }
    }
}
