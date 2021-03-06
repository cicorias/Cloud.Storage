﻿using Cloud.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Storage.Azure.Blob
{
    public class Container : IContainer
    {
        internal Container(CloudBlobContainer blobContainer)
        {
            AzureBlobContainer = blobContainer;
        }

        public string Name { get { return AzureBlobContainer.Name; } }
        public Uri PrimaryUri { get { return AzureBlobContainer.StorageUri.PrimaryUri; } }
        public Uri SecondaryUri { get { return AzureBlobContainer.StorageUri.SecondaryUri; } }

        public List<BlobListItem> ListBlobs(string prefix = null)
        {
            return AzureBlobContainer.ListBlobs(prefix, true).Select(blobListItem => new BlobListItem(blobListItem)).ToList();
        }

        public IBlob GetBlob(string uri)
        {
            return new Blob(AzureBlobContainer.GetBlockBlobReference(uri));
        }

        private CloudBlobContainer AzureBlobContainer { get; set; }
    }
}
