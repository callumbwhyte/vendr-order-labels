using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Composing;
using Vendr.Contrib.OrderLabels.Generators;

namespace Vendr.Contrib.OrderLabels.Composing
{
    public class LabelGeneratorCollection : BuilderCollectionBase<ILabelGenerator>
    {
        public LabelGeneratorCollection(IEnumerable<ILabelGenerator> items)
            : base(items)
        {

        }

        public ILabelGenerator GetByAlias(string alias)
        {
            return this.FirstOrDefault(x => x.Alias == alias);
        }
    }
}