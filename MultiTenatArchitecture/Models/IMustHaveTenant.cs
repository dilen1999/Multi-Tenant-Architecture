﻿namespace MultiTenatArchitecture.Models
{
    public interface IMustHaveTenant
    {
        public string TenantId { get; set; }
    }
}
