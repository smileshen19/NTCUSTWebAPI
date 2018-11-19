using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace NTCUSTWebAPI.Controllers
{
    [RoutePrefix("Image")]
    public class ImageController : ApiController
    {
        private string StorageConnectionString = "DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}";
        private string BaseImageUrl = "https://{0}.blob.core.windows.net/00000000/";

        [Route("")]
        public async Task<IHttpActionResult> Post()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                return StatusCode(HttpStatusCode.UnsupportedMediaType);
            }

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(StorageConnectionString);
            CloudBlobClient BlobClient = storageAccount.CreateCloudBlobClient();
            try
            {
                CloudBlobContainer BlobContainer = BlobClient.GetContainerReference("00000000");
                BlobContainer.CreateIfNotExists();
                BlobContainer.SetPermissions(
                    new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
                AzureBlobMultipartFormDataStreamProvider Provider = new AzureBlobMultipartFormDataStreamProvider();
                string FileName = Guid.NewGuid().ToString();
                CloudBlockBlob Bolb = BlobContainer.GetBlockBlobReference(FileName);
                Provider.Bolb = Bolb;
                await Request.Content.ReadAsMultipartAsync(Provider);
                return Ok(BaseImageUrl+FileName);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }

    public class AzureBlobMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        /// <summary>
        /// 
        /// </summary>
        public CloudBlockBlob Bolb { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public AzureBlobMultipartFormDataStreamProvider() : base("azure") { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public override Stream GetStream(HttpContent parent, HttpContentHeaders headers)
        {
            if (headers.ContentType != null)
            {
                Bolb.Properties.ContentType = headers.ContentType.MediaType;
            }
            return Bolb.OpenWrite();
        }
    }
}
