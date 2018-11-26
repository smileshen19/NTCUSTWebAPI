﻿using System;
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
    [RoutePrefix("Customer")]
    public class CustomerController : ApiController
    {
        //private readonly string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Demo;Integrated Security=true";
        private readonly string ConnectionString = "Data Source=smileshen19.database.windows.net;Initial Catalog=testDB1;User ID=smileshen19;Password=P@ssw0rd";
        [Route("")]
        public IEnumerable<CustomerModel> Get()
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                return conn.GetAll<CustomerModel>();
            }
        }

        
        [Route("{ID}")]
        public CustomerModel Get(string ID)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                return conn.Get<CustomerModel>(ID);
            }
        }

        [Route("")]
        [SwaggerRequestExample(typeof(CustomerModel), typeof(CustomerModelExample))]
        public IHttpActionResult Post([FromBody] CustomerModel Customer)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Insert<CustomerModel>(Customer);
                return Ok();
            }
        }

        [Route("{ID}")]
        public IHttpActionResult Delete(string ID)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var Customer = this.Get(ID);
                if (Customer != null && Customer.ID == ID ) {
                    conn.Delete<CustomerModel>(Customer);
                }
                return Ok();
            }
        }

        [Route("")]
        public IHttpActionResult Put([FromBody] CustomerModel Customer)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Update<CustomerModel>(Customer);
                return Ok();
            }
        }
   }
}