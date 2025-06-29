﻿using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Web;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreWithSecrets.FilesProvider.AzureStorageAccess;

public class AzureStorageProvider
{
    private string _blobConnectionString = "https://sarufer7.blob.core.windows.net/test?sp=r&st=2025-06-18T11:07:27Z&se=2025-06-18T11:09:27Z&spr=https&sv=2024-11-04&sr=c&sig=JLS7wLGXxvFConsaEGWd4UeD%2BpfC2o9fYcMhH%2FAwnD8%3D";
    private string _blobKey = "sp=r&st=2025-06-18T11:07:27Z&se=2025-06-18T11:09:27Z&spr=https&sv=2024-11-04&sr=c&sig=JLS7wLGXxvFConsaEGWd4UeD%2BpfC2o9fYcMhH%2FAwnD8%3D";

    private readonly TokenAcquisitionTokenCredential _tokenAcquisitionTokenCredential;
    private readonly IConfiguration _configuration;

    public AzureStorageProvider(TokenAcquisitionTokenCredential tokenAcquisitionTokenCredential,
        IConfiguration configuration)
    {
        _tokenAcquisitionTokenCredential = tokenAcquisitionTokenCredential;
        _configuration = configuration;
    }

    [AuthorizeForScopes(Scopes = new string[] { "https://storage.azure.com/user_impersonation" })]
    public async Task<string> AddNewFile(BlobFileUpload blobFileUpload, IFormFile file)
    {
        try
        {
            return await PersistFileToAzureStorage(blobFileUpload, file);
        }
        catch (Exception e)
        {
            throw new ApplicationException($"Exception {e}");
        }
    }

    [AuthorizeForScopes(Scopes = new string[] { "https://storage.azure.com/user_impersonation" })]
    public async Task<Azure.Response<BlobDownloadInfo>> DownloadFile(string fileName)
    {


        var storage = _configuration.GetValue<string>("AzureStorage:StorageAndContainerName");
        var fileFullName = $"{storage}{fileName}";
        var blobUri = new Uri(fileFullName);
        var blobClient = new BlobClient(blobUri, _tokenAcquisitionTokenCredential);

        var blobClient2 = new BlobClient("https://sarufer7.blob.core.windows.net/test?sp=r&st=2025-06-18T11:07:27Z&se=2025-06-18T11:09:27Z&spr=https&sv=2024-11-04&sr=c&sig=JLS7wLGXxvFConsaEGWd4UeD%2BpfC2o9fYcMhH%2FAwnD8%3D", "test", "arbitrary-file.txt");

        return await blobClient.DownloadAsync();
    }

    private async Task<string> PersistFileToAzureStorage(
        BlobFileUpload blobFileUpload,
        IFormFile formFile,
        CancellationToken cancellationToken = default)
    {
        var storage = _configuration.GetValue<string>("AzureStorage:StorageAndContainerName");
        var fileFullName = $"{storage}{blobFileUpload.Name}";
        var blobUri = new Uri(fileFullName);

        var blobUploadOptions = new BlobUploadOptions
        {
            Metadata = new Dictionary<string, string>
            {
                { "uploadedBy", blobFileUpload.UploadedBy },
                { "description", blobFileUpload.Description }
            }
        };

        var blobClient = new BlobClient(blobUri, _tokenAcquisitionTokenCredential);

        var inputStream = formFile.OpenReadStream();
        await blobClient.UploadAsync(inputStream, blobUploadOptions, cancellationToken);

        return $"{blobFileUpload.Name} successfully saved to Azure Storage Container";
    }
}
