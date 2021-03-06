using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Stack.Fundamentals.Models.Requests
{
    public class FeaturesAddRequest
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public int LocationId { get; set; }

        [Required]
        public int UserId { get; set; }

    }
}