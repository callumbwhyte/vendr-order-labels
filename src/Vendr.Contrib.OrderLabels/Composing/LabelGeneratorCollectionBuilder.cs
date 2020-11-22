using Umbraco.Core.Composing;
using Vendr.Contrib.OrderLabels.Generators;

namespace Vendr.Contrib.OrderLabels.Composing
{
    public class LabelGeneratorCollectionBuilder : SetCollectionBuilderBase<LabelGeneratorCollectionBuilder, LabelGeneratorCollection, ILabelGenerator>
    {
        protected override LabelGeneratorCollectionBuilder This => this;
    }
}