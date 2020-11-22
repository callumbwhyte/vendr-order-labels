using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Umbraco.Core.Logging;
using Umbraco.Web.Mvc;
using Umbraco.Web.WebApi;
using Vendr.Contrib.OrderLabels.Composing;
using Vendr.Contrib.OrderLabels.Extensions;
using Vendr.Contrib.OrderLabels.Models.Response;
using Vendr.Core;
using Vendr.Core.Api;
using Vendr.Core.Models;

namespace Vendr.Contrib.OrderLabels.Web.Controllers.Api
{
    [PluginController(Constants.System.ProductAlias)]
    public class LabelController : UmbracoAuthorizedApiController
    {
        private readonly IVendrApi _vendr;
        private readonly LabelGeneratorCollection _labelGenerators;

        public LabelController(IVendrApi vendr, LabelGeneratorCollection labelGenerators)
        {
            _vendr = vendr;
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

        [HttpGet]
        public IHttpActionResult GetLabel(string alias, Guid orderId)
        {
            using (var uow = _vendr.Uow.Create())
            {
                var order = _vendr.GetOrder(orderId);

                if (order == null)
                {
                    return BadRequest("Failed to find order");
                }

                return GenerateLabels(alias, new[] { order });
            }
        }

        [HttpGet]
        public IHttpActionResult GetLabels(string alias, Guid[] orderIds)
        {
            using (var uow = _vendr.Uow.Create())
            {
                var orders = _vendr.GetOrders(orderIds);

                if (orders.Any() == false)
                {
                    return BadRequest("Failed to find any orders");
                }

                return GenerateLabels(alias, orders);
            }
        }

        private IHttpActionResult GenerateLabels(string alias, IEnumerable<OrderReadOnly> orders)
        {
            var generator = _labelGenerators.GetByAlias(alias);

            if (generator == null)
            {
                var err = $"Label generator {alias} was not found";

                Logger.Error<LabelController>(err);

                return BadRequest(err);
            }

            try
            {
                var files = generator.Generate(orders);

                var file = files.FirstOrDefault();

                var response = Request.CreateFileResponse(file.Name, file.Content);

                return ResponseMessage(response);
            }
            catch (Exception ex)
            {
                var err = "Failed to generate labels";

                Logger.Error<LabelController>(ex, err);

                return BadRequest(err);
            }
        }
    }
}