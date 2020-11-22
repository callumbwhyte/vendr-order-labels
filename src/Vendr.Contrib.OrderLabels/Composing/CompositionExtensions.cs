using Umbraco.Core.Composing;

namespace Vendr.Contrib.OrderLabels.Composing
{
    public static class CompositionExtensions
    {
        public static LabelGeneratorCollectionBuilder LabelGenerators(this Composition composition)
        {
            return composition.WithCollectionBuilder<LabelGeneratorCollectionBuilder>();
        }
    }
}