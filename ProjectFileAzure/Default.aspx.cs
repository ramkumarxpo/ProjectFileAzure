using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Azure.Storage;
using Azure.Storage.Blobs;

namespace ProjectFileAzure
{
    public partial class _Default : Page
    {
        string strConnection = "DefaultEndpointsProtocol=https;AccountName=myfilestorageforazure;AccountKey=f7ozTnjsfL5nN91Xam7f6GZ4OI1WOI9EE4yOisEGJM2YamZU0z+NbjbdVrHRIRTeF8c4euLA3ETVNOdDCCqw3g==;EndpointSuffix=core.windows.net";
        string strContainerName = "myfiledemo";
        BlobServiceClient blobService;
        BlobContainerClient containerClient;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    
                }
                catch (Exception)
                {
                    lblMsg.Text = "Error Occured ! Please try again later.";
                }
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if(fileUpload.HasFile)
                {
                    blobService = new BlobServiceClient(strConnection);
                    containerClient = blobService.GetBlobContainerClient(strContainerName);
                    BlobClient blobClient = containerClient.GetBlobClient(fileUpload.FileName);
                    blobClient.UploadAsync(fileUpload.PostedFile.InputStream, true);
                    lblMsg.Text = "File Uploaded Successfully!";
                }
                else lblMsg.Text = "Please upload some file.";
            }
            catch (Exception)
            {
                lblMsg.Text = "Error Occured ! Please try again later.";
            }
        }
    }
}