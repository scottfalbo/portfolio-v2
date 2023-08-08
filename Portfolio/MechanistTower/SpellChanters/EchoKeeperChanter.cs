using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Azure.Cosmos.Linq;
using Portfolio.MechanistTower.Configurations;

namespace Portfolio.MechanistTower.SpellChanters
{
    public class EchoKeeperChanter : IEchoKeeperChanter
    {
        private readonly IConfigurationSigils _configurationSigils;

        public EchoKeeperChanter(IConfigurationSigils configurationSigils)
        {
            _configurationSigils = configurationSigils;
        }

        public async Task BanishEcho(string fileName)
        {
            var blobContainerClient = new BlobContainerClient(
                _configurationSigils.AzureStorageConnectionString,
                _configurationSigils.AzureStorageContainerName);

            var blob = blobContainerClient.GetBlobClient(fileName);

            await blob.DeleteIfExistsAsync(
                snapshotsOption: DeleteSnapshotsOption.IncludeSnapshots,
                conditions: null,
                cancellationToken: default);
        }

        public async Task<BlobClient> InscribeEcho(IFormFile file)
        {
            var blobContainerClient = new BlobContainerClient(
                _configurationSigils.AzureStorageConnectionString,
                _configurationSigils.AzureStorageContainerName);

            if (blobContainerClient.IsNull())
            {
                await blobContainerClient.CreateIfNotExistsAsync();
            }

            var blob = blobContainerClient.GetBlobClient(file.FileName);

            var options = new BlobUploadOptions()
            {
                HttpHeaders = new BlobHttpHeaders()
                {
                    ContentType = file.ContentType
                }
            };

            await blob.UploadAsync(file.OpenReadStream(), options);
            return blob;
        }
    }
}