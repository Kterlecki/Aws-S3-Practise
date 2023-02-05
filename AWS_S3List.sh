#!/bin/bash
set -eu
S3BucketList()
{
    region=$1
    access_key=$2
    secret_key=$3
    bucket_name=$4

    export AWS_DEFAULT_REGION=$region
    export AWS_ACCESS_KEY_ID=$access_key
    export AWS_SECRET_ACCESS_KEY=$secret_key

    result=$(aws s3 ls $bucket_name)

    if [ $? -ne 0 ]; then
        echo "Error: AWS credentials are invalid or not authorized to access the bucket."
        return 1
    fi

    echo $result
    return 0
}

result=$(S3BucketList "us-west-2" "ACCESS_KEY" "SECRET_KEY" "BUCKET_NAME")
echo "Result: $result"

if [ $? -ne 0 ]; then
    echo "Error: Failed to list the contents of the S3 bucket."
    exit 1
else
    echo "Success: Listed the contents of the S3 bucket."
    exit 0
fi