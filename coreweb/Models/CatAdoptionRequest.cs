using coreweb.ModelBinders;
using Microsoft.AspNetCore.Mvc;

namespace coreweb.Models
{
    [ModelBinder(BinderType = typeof(CatAdoptionEntityBinder))]
    public class CatAdoptionRequest
    {
        public Cat Cat { get; set; }
        public AdoptionRequest AdoptionRequest { get; set; }
    }
}
