using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CRM.HelperLogic
{
    /// <summary>
    /// Provides HTTP calls sending and receiving information from a HTTP server
    /// </summary>
    public class WebRequests
    {
        /// <summary>
        /// Posts a web requests to an URL and return the raw http web response
        /// </summary>
        /// <param name="url">The URL to post to</param>
        /// <param name="content">The content to post</param>
        /// <param name="sendType">The format to serialize the content into</param>
        /// <param name="returnType">The expected type of content to be returned from the server</param>
        /// <returns></returns>
        public static async Task<HttpWebResponse> PostAsync(string url, object content = null,
            KnownContentSerializers sendType = KnownContentSerializers.Json,
            KnownContentSerializers returnType = KnownContentSerializers.Json)
        {
            // create the web request
            var request = WebRequest.CreateHttp(url);
            request.Method = HttpMethod.Post.ToString();

            request.Accept = returnType.ToMimeString();
            request.ContentType = sendType.ToMimeString();

            if (content == null)
            {
                request.ContentLength = 0;
            }
            else
            {
                var contentString = string.Empty;

                if (sendType == KnownContentSerializers.Json)
                    contentString = JsonConvert.SerializeObject(content);
                else if (sendType == KnownContentSerializers.Xml)
                {
                    var xmlSerializer = new XmlSerializer(content.GetType());

                    using (var stringWriter = new StringWriter())
                    {
                        xmlSerializer.Serialize(stringWriter, content);
                        contentString = stringWriter.ToString();
                    }
                }
                else
                {
                    // TODO: Throw error
                }

                using (var requestStream = await request.GetRequestStreamAsync())
                using (var streamWriter = new StreamWriter(requestStream))
                    await streamWriter.WriteAsync(contentString);
                
            }

            return await request.GetResponseAsync() as HttpWebResponse; 
        }

        /// <summary>
        /// Posts a web requests to an URL and return a response of the expected data type
        /// </summary>
        /// <param name="url">The URL to post to</param>
        /// <param name="content">The content to post</param>
        /// <param name="sendType">The format to serialize the content into</param>
        /// <param name="returnType">The expected type of content to be returned from the server</param>
        /// <returns></returns>
        public static async Task<WebRequestResult<TResponse>> PostAsync<TResponse>(string url, object content = null,
            KnownContentSerializers sendType = KnownContentSerializers.Json,
            KnownContentSerializers returnType = KnownContentSerializers.Json)

        {
            //standart post call
            var serverResponse = await PostAsync(url, content, sendType, returnType);

            var result = serverResponse.CreateWebRequstResult<TResponse>();

            if (result.StatusCode != HttpStatusCode.OK)
            {
                // TODO: locolize string
                result.ErrorMessage = $"Server returned unsuccessfull status code. {serverResponse.StatusCode} {serverResponse.StatusDescription}";
                return result; 
            }


            if (string.IsNullOrWhiteSpace(result.RawServerResponse))
                return result;


            try
            {
                if (!serverResponse.ContentType.ToLower().Contains(KnownContentSerializers.Json.ToMimeString().ToLower()))
                {
                    result.ErrorMessage = $"Uknown return type. Expected {returnType.ToMimeString()}, received {serverResponse.ContentType.ToLower()}";
                    return result;
                }

                if (returnType == KnownContentSerializers.Json)
                {
                    result.ServerResponse = JsonConvert.DeserializeObject<TResponse>(result.RawServerResponse);  
                }

                else if (returnType == KnownContentSerializers.Xml)
                {
                    var xmlSerializer = new XmlSerializer(typeof(TResponse));

                    using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(result.RawServerResponse)))
                    {
                        result.ServerResponse = (TResponse)xmlSerializer.Deserialize(memoryStream);
                    }
                }
                else
                {
                    result.ErrorMessage = "Uknown return type";
                    return result;
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = $"Failed to deserialize server response. Error {ex.Message}";
                return result;
            }
            return result;

        }

    }
}
 