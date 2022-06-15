using Bogus.DataSets;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Allegory.Module.PlugInRandomNames
{
    [Route("api/plug-in/random-name")]
    public class RandomNameController : AbpControllerBase
    {
        public RandomNameController()
        {
            //injection
        }

        [HttpGet]
        public async Task<List<string>> GetAsync()
        {
            List<string> names = new List<string>();
            var faker = new Name();

            for (int i = 0; i < 100; i++)
            {
                names.Add(faker.FirstName());
            }

            return await Task.FromResult(names);
        }
    }
}
