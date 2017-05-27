using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Stark.Fundamentals.Models.Requests
{
    public class FeaturesUpdateRequest : FeaturesAddRequest
    {
        [Required]

        public int Id { get; set; }

    }
}