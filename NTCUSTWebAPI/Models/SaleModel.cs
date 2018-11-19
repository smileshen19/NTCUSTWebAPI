using Dapper.Contrib.Extensions;
using Swashbuckle.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTCUSTWebAPI.Model
{
    [Dapper.Contrib.Extensions.Table("Sales")]
    public class SaleModel
    {
        [ExplicitKey]
        public string No { get; set; }
        public DateTime? TradeDate { get; set; }
        public string CustomerID { get; set; }
        public decimal? TaxRate { get; set; }
        public string TaxID { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? TotalTax { get; set; }
        public string Memo { get; set; }
        public string Str1 { get; set; }
        public string Str2 { get; set; }
        public string Str3 { get; set; }
        public string Str4 { get; set; }
        public int? Int1 { get; set; }
        public int? Int2 { get; set; }
        public decimal? Mon1 { get; set; }
        public decimal? Mon2 { get; set; }
        public IEnumerable<SaleDetailModel> SaleDetails;
    }

    [Dapper.Contrib.Extensions.Table("SaleDetails")]
    public class SaleDetailModel
    {
        [ExplicitKey]
        public string No { get; set; }
        [ExplicitKey]
        public int Seq { get; set; }
        public string ItemID { get; set; }
        public string ItemName { get; set; }
        public string Unit { get; set; }
        public decimal? Qty { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Price { get; set; }
        public decimal? Amount { get; set; }
        public bool? IsFree { get; set; }
        public string Memo { get; set; }
        public string Str1 { get; set; }
        public string Str2 { get; set; }
        public string Str3 { get; set; }
        public string Str4 { get; set; }
        public int? Int1 { get; set; }
        public int? Int2 { get; set; }
        public decimal? Mon1 { get; set; }
        public decimal? Mon2 { get; set; }
    }


    public class SaleModelExample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new SaleModel
            {
                No = "20181107001",
                TradeDate = DateTime.Parse("2018-11-07"),
                CustomerID = "C01",
                TaxRate = 0.05m,
                TaxID = "",
                ZipCode = "200",
                City = "台北市",
                District = "西區",
                Address = "大明路100號",
                TotalAmount = 100,
                TotalTax = 15,
                Memo = "",
                Str1 = "",
                Str2 = "",
                Str3 = "",
                Str4 = "",
                Int1 = 0,
                Int2 = 0,
                Mon1 = 0,
                Mon2 = 0,
                SaleDetails = new SaleDetailModel[]
                {
                    new SaleDetailModel
                    {
                        No = "20181107001",
                        Seq = 1,
                        ItemID = "I01",
                        ItemName = "I01商品",
                        Unit = "個",
                        Qty = 1,
                        SalePrice = 100,
                        Discount = 0,
                        Price = 100,
                        Amount = 100,
                        IsFree = false,
                        Memo = "",
                        Str1 = "",
                        Str2 = "",
                        Str3 = "",
                        Str4 = "",
                        Int1 = 0,
                        Int2 = 0,
                        Mon1 = 0,
                        Mon2 = 0
                    }
                }
            };
        }
    }
}
