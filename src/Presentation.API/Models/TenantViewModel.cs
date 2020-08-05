using System;

namespace Presentation.API.Models
{
    public class TenantViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}