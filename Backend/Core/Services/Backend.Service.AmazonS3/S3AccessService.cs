using Amazon.S3;
using Amazon.S3.Model;
using Backend.Service.AmazonS3.Interfaces;
using Backend.Service.AmazonS3.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Service.AmazonS3
{
    internal class S3AccessService : IS3AccessService
    {
        private readonly S3Settings _s3Settings;
        private readonly Amazon.RegionEndpoint region;

        public S3AccessService(S3Settings s3Settings)
        {
            this._s3Settings = s3Settings;
            region = Amazon.RegionEndpoint.EUCentral1;
        }

        public async Task<Stream> GetFromS3(S3FileRequest request)
        {
            using var client = !string.IsNullOrEmpty(_s3Settings.AccesKey) ?
                new AmazonS3Client(_s3Settings.AccesKey, _s3Settings.SecretAccessKey, region)
                : new AmazonS3Client(region);
            var objRequest = new GetObjectRequest
            {
                BucketName = _s3Settings.BucketName,
                Key = request.FileName
            };

            var triedTimes = 0;

            while (triedTimes <= _s3Settings.MaxRetryTimes)
            {
                try
                {
                    triedTimes++;

                    // actual data fetch (this can take awhile for larger files)
                    var s3Response = await client.GetObjectAsync(objRequest);

                    // do NOT use "using (var resp = ...)" because the using block disposes everything once done
                    //     meaning that the stream would already be closed once it has been returned outside
                    return s3Response.ResponseStream;
                }
                catch (Exception)
                {
                    if (triedTimes < _s3Settings.MaxRetryTimes)
                    {
                        Thread.Sleep(_s3Settings.MilisecondsBeforeRetry);
                        continue;
                    }

                    break;
                }
            }

            return null;
        }

        public async Task WriteStringToS3(S3FileRequest request, string data)
        {
            // if there is nothing to write: abort mission
            if (request == null || string.IsNullOrWhiteSpace(data))
                return;

            await WriteToS3(new PutObjectRequest
            {
                BucketName = _s3Settings.BucketName,
                Key = request.FileName,
                ContentBody = data
            });
        }

        public async Task WriteStreamToS3(S3FileRequest request, Stream data)
        {
            // if there is nothing to write: abort mission
            if (request == null || data == null)
                return;

            await WriteToS3(new PutObjectRequest
            {
                BucketName = _s3Settings.BucketName,
                Key = request.FileName,
                InputStream = data
            });
        }

        public Task<string> GetPresignedUrlAsync(S3FileRequest request)
        {
            using var client = !string.IsNullOrEmpty(_s3Settings.AccesKey) ?
                new AmazonS3Client(_s3Settings.AccesKey, _s3Settings.SecretAccessKey, region)
                : new AmazonS3Client(region);
            var preSignedUrlRequest = new GetPreSignedUrlRequest()
            {
                BucketName = _s3Settings.BucketName,
                Key = request.FileName,
                Expires = GetExpirationDate(),
            };

            var triedTimes = 0;

            while (triedTimes <= _s3Settings.MaxRetryTimes)
            {
                try
                {
                    triedTimes++;

                    return Task.FromResult(client.GetPreSignedURL(preSignedUrlRequest));
                }
                catch (Exception e)
                {
                    if (triedTimes < _s3Settings.MaxRetryTimes)
                    {
                        Thread.Sleep(_s3Settings.MilisecondsBeforeRetry);
                        continue;
                    }

                    break;
                }
            }

            return Task.FromResult(string.Empty);
        }

        public bool CheckIfPresignedUrlIsExpired(string url)
        {
            var regex = new Regex("-Expires=(\\d+)");
            var unixExpieryTimestamp = regex.Match(url).Groups[1].Value;

            var expiryDateOffset = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(unixExpieryTimestamp));

            var expiryDate = expiryDateOffset.UtcDateTime;

            return DateTime.Compare(expiryDate, DateTime.UtcNow) < 0; // t1 is earlier than t2
        }

        /// <summary>
        /// Gets default presigned url expiration date
        /// </summary>
        /// <returns></returns>
        private DateTime GetExpirationDate()
        {
            // set culture
            var enCulture = new CultureInfo("en-US");
            var oldCulture = Thread.CurrentThread.CurrentCulture;

            Thread.CurrentThread.CurrentCulture = enCulture;

            var dt = DateTime.Now.AddDays(7); // get date
            Thread.CurrentThread.CurrentCulture = oldCulture; // return culture

            return dt; // return date
        }

        /// <summary>
        /// Writes the given request object to S3 bucket
        /// </summary>
        private async Task WriteToS3(PutObjectRequest objRequest)
        {
            if (objRequest == null)
                return;

            using (var client = !string.IsNullOrEmpty(_s3Settings.AccesKey) ?
                new AmazonS3Client(_s3Settings.AccesKey, _s3Settings.SecretAccessKey, region)
                : new AmazonS3Client(region))
            {
                var triedTimes = 0;

                while (triedTimes <= _s3Settings.MaxRetryTimes)
                {
                    try
                    {
                        triedTimes++;
                        await client.PutObjectAsync(objRequest);
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (triedTimes < _s3Settings.MaxRetryTimes)
                        {
                            Thread.Sleep(_s3Settings.MilisecondsBeforeRetry);
                            continue;
                        }

                        var expectedErrors = new List<string> { "InvalidAccessKeyId", "InvalidSecurity" };

                        if (ex is AmazonS3Exception exception && expectedErrors.Contains(exception.ErrorCode))
                            throw new Exception($"Unable to write to bucket: {_s3Settings.BucketName}. Check the provided AWS Credentials.");

                        throw new Exception($"Unable to write to bucket: {_s3Settings.BucketName}. Error occurred: " + ex.Message);
                    }
                }
            }
        }

        public async Task<string> RenewPresignedUrl(string url, string filename)
        {
            // get fresh presigned url for display
            if (
                !string.IsNullOrWhiteSpace(url) &&
                CheckIfPresignedUrlIsExpired(url))
            {
                return await GetPresignedUrlAsync(new S3FileRequest(filename));
            }

            return url;
        }
    }
}