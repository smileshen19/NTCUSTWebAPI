using Dapper.Contrib.Extensions;
using Swashbuckle.Examples;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NTCUSTWebAPI.Model
{
    [Dapper.Contrib.Extensions.Table("Customers")]
    public class CustomerModel
    {
        [ExplicitKey]
        public string ID { get; set; }
        public string Name { get; set; }
        public string TaxID { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string CellPhone { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string EMail { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
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

    public class CustomerModelExample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new CustomerModel
            {
                ID = "C01",
                Name = "C01公司",
                TaxID = "",
                ContactName = "王大明",
                ContactTitle = "總經理",
                CellPhone = "",
                Tel = "01-23456789",
                Fax = "",
                EMail = "dami@c01.com",
                ZipCode = "200",
                City = "台北市",
                District = "西區",
                Address = "大明路100號",
                Memo = "老板人很好",
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
