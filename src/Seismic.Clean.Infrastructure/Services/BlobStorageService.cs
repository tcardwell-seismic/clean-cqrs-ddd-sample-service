using System;
using System.IO;
using System.Threading.Tasks;
using Seismic.Clean.Application.Common.Interfaces;

namespace Seismic.Clean.Infrastructure.Services
{
    /// <summary>
    /// Not implemented, only showcasing what the class would look like
    /// </summary>
    public class BlobStorageService : IBlobStorageService
    {
        public Task<FileInfo> DownloadFile(Guid blobId)
        {
            // TODO Likely use the BSS library here
            throw new NotImplementedException();
        }

        public Task UploadFile(FileInfo fileStream, Guid blobId)
        {
            // TODO Likely use the BSS library here
            throw new NotImplementedException();
        }
    }
}