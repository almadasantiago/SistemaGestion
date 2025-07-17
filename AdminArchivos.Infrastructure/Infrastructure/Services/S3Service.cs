using Amazon.S3; 
using Amazon.S3.Model;
using Amazon;
using Microsoft.Extensions.Options;
using AdminArchivos.Infrastructure.Infrastructure.Options;

namespace AdminArchivos.Infrastructure.Infrastructure.Services
{
    public class S3Service : IS3Service
    {
        private readonly IAmazonS3 _s3Client;
        private readonly AwsOptions _options;

        public S3Service(IOptions<AwsOptions> options)
        {
            _options = options.Value;
            _s3Client = new AmazonS3Client(
                _options.AccessKey,
                _options.SecretKey,
                RegionEndpoint.GetBySystemName(_options.Region)
            );
        }

        public async Task SubirArchivoAsync(string key, Stream contenido)
        {
            var request = new PutObjectRequest
            {
                BucketName = _options.BucketName,
                Key = key,
                InputStream = contenido
            };
            await _s3Client.PutObjectAsync(request);
        }

        public async Task<Stream> DescargarArchivoAsync(string key)
        {
            var response = await _s3Client.GetObjectAsync(_options.BucketName, key);
            var memoryStream = new MemoryStream();
            await response.ResponseStream.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            return memoryStream;
        }

        public async Task EliminarArchivoAsync(string key)
        {
            var request = new DeleteObjectRequest
            {
                BucketName = _options.BucketName,
                Key = key
            };
            await _s3Client.DeleteObjectAsync(request);
        }

        public async Task<List<string>> ListarArchivosAsync(string prefix = "")
        {
            var request = new ListObjectsV2Request
            {
                BucketName = _options.BucketName,
                Prefix = prefix
            };
            var response = await _s3Client.ListObjectsV2Async(request);
            var archivos = new List<string>();
            foreach (var obj in response.S3Objects)
            {
                archivos.Add(obj.Key);
            }
            return archivos;
        }
    }
}
