﻿namespace MultiTenatArchitecture.Services
{
    public interface ICurrentTenantService
    {
        string? TenantId { get; set; }
        public Task<bool> SetTenant(string tenant);
    }
}
