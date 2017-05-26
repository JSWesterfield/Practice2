using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sabio.Fundamentals.Models.Requests
{
    public class FeatureUpdateRequest : FeatureAddRequest
    {
        [Required]

        public int Id { get; set; }

    }
}