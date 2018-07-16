using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreweb.Models
{
    public class AdoptionRequest
    {
        public string From { get; set; }
        public string Days { get; set; }
    }
}
