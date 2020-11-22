using System;

namespace Vendr.Contrib.OrderLabels.Models
{
    public class LabelFile
    {
        public string Name { get; set; }

        public byte[] Content { get; set; }
    }
}