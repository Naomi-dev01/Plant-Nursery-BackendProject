using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantNursery.DataImporter
{
    internal class JasonProduct
    {
        public class Root
        {
            public AllProducts AllProducts { get; set; }
        }

        public class AllProducts
        {
            public List<JsonProduct> Flowers { get; set; }
            public List<JsonProduct> Trees { get; set; }
            public List<JsonProduct> MoreStuff { get; set; }
            public List<JsonProduct> Bouquets { get; set; }
            public List<JsonProduct> GardenDesign { get; set; }
        }

        public class JsonProduct
        {
            public string Name { get; set; }
            public string GrowingConditions { get; set; }
            public string Colors { get; set; }
            public string Height { get; set; }
            public string Care { get; set; }
            public string MainUses { get; set; }
            public string SpecialFeatures { get; set; }
            public string Description { get; set; }
            public string Image { get; set; }
            public int Stock { get; set; }
            //public decimal Cost { get; set; }
            public decimal Price { get; internal set; }
        }
    }
}
