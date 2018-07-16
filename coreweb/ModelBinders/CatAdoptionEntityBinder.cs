using coreweb.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
namespace coreweb.ModelBinders
{
    public class CatAdoptionEntityBinder : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            // Read Cat from Body
            var memoryStream = new MemoryStream();
            var body = bindingContext.HttpContext.Request.Body;
            var reader = new StreamReader(body, Encoding.UTF8);
            var text = reader.ReadToEnd();
            var cat = JsonConvert.DeserializeObject<Cat>(text);

            // Read Adoption Request from query or route
            var adoptionRequest = new AdoptionRequest();
            var properties = typeof(AdoptionRequest).GetProperties();
            foreach (var property in properties)
            {
                var valueProvider = bindingContext.ValueProvider.GetValue(property.Name);
                if (valueProvider != null)
                {
                    property.SetValue(adoptionRequest, valueProvider.FirstValue);
                }
            }

            // Merge
            var model = new CatAdoptionRequest()
            {
                Cat = cat,
                AdoptionRequest = adoptionRequest
            };

            bindingContext.Result = ModelBindingResult.Success(model);
            return;
        }
    }
}
