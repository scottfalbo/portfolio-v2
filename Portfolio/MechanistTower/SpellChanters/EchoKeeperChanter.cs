using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Portfolio.MechanistTower.Configurations;
using Portfolio.MechanistTower.Entities;
using Portfolio.MechanistTower.Manipulators;

namespace Portfolio.MechanistTower.SpellChanters
{
    public class EchoKeeperChanter : IEchoKeeperChanter
    {
        private readonly IConfigurationSigils _configurationSigils;
        private readonly IEchoShaper _echoShaper;

        public EchoKeeperChanter(
            IConfigurationSigils configurationSigils,
            IEchoShaper echoShaper)
        {
            _configurationSigils = configurationSigils;
            _echoShaper = echoShaper;
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

        public async Task InscribeEcho(IFormFile file, FleshRite fleshRite)
        {
            var echoFileName = _echoShaper.AugmentRunicNaming(file.FileName);
            var reshapedEcho = _echoShaper.ShapeEcho(file, 1920);
            var contentType = file.ContentType;

            var echo = await InscribeEcho(reshapedEcho, echoFileName, contentType);

            var faintFileName = $"thumb_{echoFileName}";
            var faintReshapedEcho = _echoShaper.ShapeEcho(file, 177);

            var faintEcho = await InscribeEcho(faintReshapedEcho, faintFileName, contentType);

            fleshRite.ImageUrl = echo.Uri.ToString();
            fleshRite.ThumbnailUrl = faintEcho.Uri.ToString();
            fleshRite.FileName = echoFileName;
            fleshRite.ThumbnailFileName = faintFileName;
        }

        private async Task<BlobClient> InscribeEcho(Stream stream, string fileName, string contentType)
        {
            var blobContainerClient = new BlobContainerClient(
                _configurationSigils.AzureStorageConnectionString,
                _configurationSigils.AzureStorageContainerName);

            if (blobContainerClient == null)
            {
                await blobContainerClient.CreateIfNotExistsAsync();
            }

            var blob = blobContainerClient.GetBlobClient(fileName);

            var options = new BlobUploadOptions()
            {
                HttpHeaders = new BlobHttpHeaders()
                {
                    ContentType = contentType
                }
            };

            await blob.UploadAsync(stream, options);
            return blob;
        }
    }
}