using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using NTCUSTWebAPI.Model;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Web.Http;
using Swashbuckle.Examples;

namespace NTCUSTWebAPI.Controllers
{
    [RoutePrefix("Item")]
    public class ItemController : ApiController
    {
        //private readonly string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Demo;Integrated Security=true";
        private readonly string ConnectionString = "Data Source={dataSource};Initial Catalog={dbName};User ID={ID};Password={PW}";

        [Route("")]
        public IEnumerable<ItemModel> Get()
        {
            IEnumerable<ItemModel> Items;
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                Items = conn.Query<ItemModel>("select * from Items");
                conn.Close();
            }
            return Items;
        }

        [Route("{ID}")]
        public ItemModel Get(string ID)
        {
            ItemModel Item;
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                Item = conn.QueryFirst<ItemModel>("select * from Items where ID = @ID", new { ID = ID });
                conn.Close();
            }
            return Item;
        }

        [Route("")]
        [SwaggerRequestExample(typeof(ItemModel), typeof(ItemModelExample))]
        public IHttpActionResult Post([FromBody] ItemModel Item)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                conn.Execute(
                    "insert into Items(ID,Name,Unit,Category,Price,Description,Barcode,SafetyStock,StopDate,Str1,Str2,Str3,Str4,Int1,Int2,Mon1,Mon2) "+
                    "values(@ID,@Name,@Unit,@Category,@Price,@Description,@Barcode,@SafetyStock,@StopDate,@Str1,@Str2,@Str3,@Str4,@Int1,@Int2,@Mon1,@Mon2)", 
                    Item);
                conn.Close();
            }
            return Ok();
        }

        [Route("{ID}")]
        public IHttpActionResult Delete(string ID)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var Item = this.Get(ID);
                if (Item != null && Item.ID == ID) {
                    conn.Open();
                    conn.Execute("delete from Items where ID = @ID", new { ID = ID });
                    conn.Close();
                }                
            }
            return Ok();

        }

        [Route("{ID}")]
        public IHttpActionResult Put(string ID, [FromBody] ItemModel Item)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@ID", Item.ID, DbType.String, ParameterDirection.Input, 16);
                parameter.Add("@Name", Item.Name, DbType.String, ParameterDirection.Input, 40);
                parameter.Add("@Unit", Item.Unit, DbType.String, ParameterDirection.Input, 4);
                parameter.Add("@Category", Item.Category, DbType.String, ParameterDirection.Input, 12);
                parameter.Add("@Price", Item.Price, DbType.Currency, ParameterDirection.Input);
                parameter.Add("@Description", Item.Description, DbType.String, ParameterDirection.Input, 600);
                parameter.Add("@Barcode", Item.Barcode, DbType.String, ParameterDirection.Input, 20);
                parameter.Add("@SafetyStock", Item.SafetyStock, DbType.Decimal, ParameterDirection.Input,0 , 12, 4);
                parameter.Add("@StopDate", Item.StopDate, DbType.Date, ParameterDirection.Input);
                parameter.Add("@Str1", Item.Str1, DbType.String, ParameterDirection.Input, 255);
                parameter.Add("@Str2", Item.Str2, DbType.String, ParameterDirection.Input, 255);
                parameter.Add("@Str3", Item.Str3, DbType.String, ParameterDirection.Input, 255);
                parameter.Add("@Str4", Item.Str4, DbType.String, ParameterDirection.Input, 255);
                parameter.Add("@Int1", Item.Int1, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@Int2", Item.Int2, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@Mon1", Item.Mon1, DbType.Currency, ParameterDirection.Input);
                parameter.Add("@Mon2", Item.Mon2, DbType.Currency, ParameterDirection.Input);
                parameter.Add("@0", ID, DbType.String, ParameterDirection.Input, 16);
                conn.Execute(
                    "update Items set "+
                      "ID=@ID,Name=@Name,Unit=@Unit,Category=@Category,Price=@Price,Description=@Description,Barcode=@Barcode,SafetyStock=@SafetyStock,StopDate=@StopDate, "+
                      "Str1=@Str1,Str2=@Str2,Str3=@Str3,Str4=@Str4,Int1=@Int1,Int2=@Int2,Mon1=@Mon1,Mon2=@Mon2 " +
                    "where ID = @0"
                    , parameter);
                conn.Close();
            }
            return Ok();
        }
    }
}