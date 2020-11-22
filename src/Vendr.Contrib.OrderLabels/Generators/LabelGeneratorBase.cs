using System.Collections.Generic;
using Umbraco.Core;
using Vendr.Contrib.OrderLabels.Models;
using Vendr.Core.Models;

namespace Vendr.Contrib.OrderLabels.Generators
{
    public abstract class LabelGeneratorBase : ILabelGenerator
    {
        public abstract string Name { get; }

        public virtual string Alias => Name.ToSafeAlias();

        public abstract IEnumerable<LabelFile> Generate(IEnumerable<OrderReadOnly> orders);
    }
}