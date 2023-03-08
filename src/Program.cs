
string accessKey = "YOUR_ACCESS_KEY";
string secretKey = "YOUR_SECRET_KEY";
string bucketName = "YOUR_BUCKET_NAME";
string filePath = "PATH_TO_YOUR_FILE";
string keyName = "KEY_NAME_FOR_YOUR_FILE_IN_S3_BUCKET";


var s3Service = new S3Service(secretKey, accessKey, bucketName);
s3Service.CountNumberOfObjectsInBucket();
s3Service.UploadToBucket(keyName, filePath);
s3Service.DownloadFileFromBucket(keyName);