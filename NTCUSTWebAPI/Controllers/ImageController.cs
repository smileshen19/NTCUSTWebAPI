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
        private string StorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=shermanshenstoragetest1;AccountKey=aJbfIb4RPiua8PxAdIFhihgmL8/nMOWl1TcPgt/6teHRUbYCdhF/RoQN46qibadljFohOMZ7fBBElXh4URdqdA==;EndpointSuffix=core.windows.net";
        private string BaseImageUrl = "https://shermanshenstoragetest1.blob.core.windows.net/blob1/";

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
                CloudBlobContainer BlobContainer = BlobClient.GetContainerReference("blob1");
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
