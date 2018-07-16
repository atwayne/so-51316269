using coreweb.Models;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace coreweb.Controllers
{
    [Route("api/cats")]
    public class CatController : Controller
    {
        private static readonly List<Cat> Cats = new List<Cat>();

        [HttpPost()]
        public bool Post([CustomizeValidator]CatAdoptionRequest adoptionRequest)
        {
            return ModelState.IsValid;
        }

        [HttpGet()]
        public List<Cat> Get()
        {
            return Cats;
        }
    }
}
