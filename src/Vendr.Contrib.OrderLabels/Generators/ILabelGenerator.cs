using System.Collections.Generic;
using Vendr.Contrib.OrderLabels.Models;
using Vendr.Core.Models;

namespace Vendr.Contrib.OrderLabels.Generators
{
    public interface ILabelGenerator
    {
        string Name { get; }

        string Alias { get; }

        IEnumerable<LabelFile> Generate(IEnumerable<OrderReadOnly> orders);
    }
}