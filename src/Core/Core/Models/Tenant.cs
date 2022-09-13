﻿using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Tenant: LongEntityBase
    {
        public string TenantName { get; set; }

        [StringLength(8)]
        [Display(Name = "Cvr")]
        public string PublicId { get; set; } 

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Aktiv")]
        public bool IsActive { get; set; }

        [Display(Name = "Master Tenant")]
        public bool IsDefaultTenant { get; set; }

    }
}
