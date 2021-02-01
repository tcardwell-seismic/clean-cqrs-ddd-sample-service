using System;
using System.IO;
using System.Threading.Tasks;

namespace Seismic.Clean.Application.Common.Interfaces
{
    public interface IBlobStorageService
    {
        Task UploadFile(FileInfo fileStream, Guid blobId);
        Task<FileInfo> DownloadFile(Guid blobId);
    }
}