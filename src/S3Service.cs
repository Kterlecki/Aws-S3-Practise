
using Amazon.S3;
using Amazon.S3.Model;

public class S3Service
{
    private readonly string _secretKey;
    private readonly string _accessKey;
    private readonly string _bucketName;

    public S3Service(string secretKey, string accessKey, string bucketName)
    {
        _secretKey = secretKey;
        _accessKey = accessKey;
        _bucketName = bucketName;
    }



    public async void CountNumberOfObjectsInBucket()
    {
        AmazonS3Client s3Client = new AmazonS3Client(_accessKey, _secretKey, Amazon.RegionEndpoint.USEast1);

        ListObjectsV2Request request = new ListObjectsV2Request
        {
            BucketName = _bucketName,
            Prefix = "",
            Delimiter = "/"
        };

        var response = await s3Client.ListObjectsV2Async(request);

        foreach (string prefix in response.CommonPrefixes)
        {
            Console.WriteLine("Folder: {0}", prefix);
        }

    }


    public async void UploadToBucket(string keyName, string path)
    {
        AmazonS3Client s3Client = new AmazonS3Client(_accessKey, _secretKey, Amazon.RegionEndpoint.USEast1);

        PutObjectRequest putRequest = new PutObjectRequest
        {
            BucketName = _bucketName,
            Key = keyName,
            FilePath = path
        };

        var putResponse = await s3Client.PutObjectAsync(putRequest);
    }

    public async void DownloadFileFromBucket(string keyName)
    {
        AmazonS3Client s3Client = new AmazonS3Client(_accessKey, _secretKey, Amazon.RegionEndpoint.USEast1);

        GetObjectRequest getRequest = new GetObjectRequest
        {
            BucketName = _bucketName,
            Key = keyName
        };

        GetObjectResponse getResponse = await s3Client.GetObjectAsync(getRequest);
        using (Stream responseStream = getResponse.ResponseStream)
        {
            using (FileStream filesStream = File.Create("./"))
            {
                responseStream.CopyTo(filesStream);
            }
        }
    }

}