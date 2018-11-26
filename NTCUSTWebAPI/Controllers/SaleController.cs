using System;
using System.Collections.Generic;
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
    [RoutePrefix("Sale")]
    public class SaleController : ApiController
    {
        //private readonly string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Demo;Integrated Security=true";
        private readonly string ConnectionString = "Data Source=smileshen19.database.windows.net;Initial Catalog=testDB1;User ID=smileshen19;Password=P@ssw0rd";
        [Route("{No}")]
        public SaleModel Get(string No)
        {
            SaleModel Sale;
            using (var conn = new SqlConnection(ConnectionString))
            {
                 Sale =
                    conn.Query<SaleModel>("select * from Sales where No = @No", new { No = No })
                    .FirstOrDefault<SaleModel>();

                if (Sale != null)
                {
                    Sale.SaleDetails =
                        conn.Query<SaleDetailModel>("select * from SaleDetails where No = @No", new { No = No });
                }
            }
            return Sale;
        }

        [Route("")]
        [SwaggerRequestExample(typeof(SaleModel), typeof(SaleModelExample))]
        public IHttpActionResult Post([FromBody] SaleModel Sale)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlTransaction Transaction = conn.BeginTransaction();
                try
                {
                    conn.Insert<SaleModel>(Sale, Transaction);
                    conn.Insert<IEnumerable<SaleDetailModel>>(Sale.SaleDetails, Transaction);
                    Transaction.Commit();
                }
                catch (Exception e)
                {
                    Transaction.Rollback();
                    return BadRequest(e.Message);
                }
            }
            return Ok();
        }

        [Route("{No}")]
        public IHttpActionResult Delete(string No)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlTransaction Transaction = conn.BeginTransaction();
                try
                {
                    var Sale = this.Get(No);
                    if (Sale != null && Sale.No == No) {
                        conn.Delete<SaleModel>(Sale, Transaction);
                        conn.Execute("delete from SaleDetails where No = @No", new { No = Sale.No }, Transaction);
                        Transaction.Commit();
                    }
                }
                catch (Exception e)
                {
                    Transaction.Rollback();
                    return BadRequest(e.Message);
                }
            }
            return Ok();
        }

        [Route("")]
        public IHttpActionResult Put([FromBody] SaleModel Sale)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlTransaction Transaction = conn.BeginTransaction();
                try
                {
                    conn.Update<SaleModel>(Sale, Transaction);
                    conn.Execute("delete from SaleDetails where No = @No", new { No = Sale.No }, Transaction);
                    conn.Insert<IEnumerable<SaleDetailModel>>(Sale.SaleDetails, Transaction);
                    Transaction.Commit();
                }
                catch(Exception e)
                {
                    Transaction.Rollback();
                    return BadRequest(e.Message);
                }
            }
            return Ok();
        }
    }
}