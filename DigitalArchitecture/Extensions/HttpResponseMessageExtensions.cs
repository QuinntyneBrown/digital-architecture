﻿using DigitalArchitecture.Common;
using System.Net.Http;
using System.Threading.Tasks;

namespace DigitalArchitecture.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public async static Task<HttpResponseMessage> EnsureSuccessStatusCodeWithFullError(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                throw new FailedRequestException(response.RequestMessage.RequestUri, content, response.StatusCode, $"Response status code does not indicate success {response.RequestMessage.RequestUri} {content} {response.StatusCode}");
            }
            return response;
        }
    }
}