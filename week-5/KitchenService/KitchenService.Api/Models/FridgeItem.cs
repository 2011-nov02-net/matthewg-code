using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenService.Api.Models {
    public class FridgeItem {

        [BindNever]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double WeightOz { get; set; }

        public DateTimeOffset? Expiration { get; set; }

        public bool IsExpired => Expiration <= DateTime.UtcNow;
    }
}
