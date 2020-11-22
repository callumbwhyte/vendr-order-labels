using Umbraco.Core;
using Umbraco.Core.Composing;
using Vendr.Contrib.OrderLabels.Composing;

namespace Vendr.Contrib.OrderLabels.Startup
{
    public class OrderLabelsComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Register<LabelGeneratorCollection>();
        }
    }
}