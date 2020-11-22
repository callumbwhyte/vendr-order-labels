using System.Linq;
using System.Web.Http;
using Umbraco.Web.Mvc;
using Umbraco.Web.WebApi;
using Vendr.Contrib.OrderLabels.Composing;
using Vendr.Contrib.OrderLabels.Models.Response;
using Vendr.Core;

namespace Vendr.Contrib.OrderLabels.Web.Controllers.Api
{
    [PluginController(Constants.System.ProductAlias)]
    public class LabelController : UmbracoAuthorizedApiController
    {
        private readonly LabelGeneratorCollection _labelGenerators;

        public LabelController(LabelGeneratorCollection labelGenerators)
        {
            _labelGenerators = labelGenerators;
        }

        [HttpGet]
        public IHttpActionResult GetGenerators()
        {
            var generators = _labelGenerators
                .Select(x => new LabelGeneratorResponse
                {
                    Name = x.Name,
                    Alias = x.Alias
                });

            return Ok(generators);
        }
    }
}