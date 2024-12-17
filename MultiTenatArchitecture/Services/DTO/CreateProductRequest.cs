namespace MultiTenatArchitecture.Services.DTO
{
    public class CreateProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string TenantId { get; set; }
    }
}
