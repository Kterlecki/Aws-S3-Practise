// Install-Package AWSSDK.S3


using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using System.IO;

// Replace the following variables with your own AWS credentials and S3 bucket information
string accessKey = "YOUR_ACCESS_KEY";
string secretKey = "YOUR_SECRET_KEY";
string bucketName = "YOUR_BUCKET_NAME";
string regionName = "YOUR_REGION_NAME";
string filePath = "PATH_TO_YOUR_FILE";
string keyName = "KEY_NAME_FOR_YOUR_FILE_IN_S3_BUCKET";

// Create an instance of the AmazonS3Client class
AmazonS3Client s3Client = new AmazonS3Client(accessKey, secretKey, RegionEndpoint.GetBySystemName(regionName));

// Upload a file to the S3 bucket
PutObjectRequest putRequest = new PutObjectRequest
{
    BucketName = bucketName,
    Key = keyName,
    FilePath = filePath
};
PutObjectResponse putResponse = s3Client.PutObject(putRequest);

// Download a file from the S3 bucket
GetObjectRequest getRequest = new GetObjectRequest
{
    BucketName = bucketName,
    Key = keyName
};
GetObjectResponse getResponse = s3Client.GetObject(getRequest);
using (Stream responseStream = getResponse.ResponseStream)
{
    using (StreamReader reader = new StreamReader(responseStream))
    {
        string content = reader.ReadToEnd();
        // Do something with the file content
        //responseStream.CopyTo(fileStream);
    }
}
