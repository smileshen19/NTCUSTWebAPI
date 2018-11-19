using Dapper.Contrib.Extensions;
using Swashbuckle.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTCUSTWebAPI.Model
{
    [Dapper.Contrib.Extensions.Table("Items")]
    public class ItemModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public string Category { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }
        public string Barcode { get; set; }
        public decimal? SafetyStock { get; set; }
        public DateTime? StopDate { get; set; }
        public string Str1 { get; set; }
        public string Str2 { get; set; }
        public string Str3 { get; set; }
        public string Str4 { get; set; }
        public int? Int1 { get; set; }
        public int? Int2 { get; set; }
        public decimal? Mon1 { get; set; }
        public decimal? Mon2 { get; set; }
    }

    public class ItemModelExample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new ItemModel
            {
                ID = "I01",
                Name = "I01商品",
                Unit = "個",
                Category = "一般",
                Price = 100,
                Description = "尺寸10*10",
                Barcode = "",
                SafetyStock = 10,
                StopDate = null,
                Str1 = "",
                Str2 = "",
                Str3 = "",
                Str4 = "",
                Int1 = 0,
                Int2 = 0,
                Mon1 = 0,
                Mon2 = 0,
            };
        }
    }
}
