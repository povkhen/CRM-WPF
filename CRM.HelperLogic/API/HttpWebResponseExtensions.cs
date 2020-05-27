using System.IO;
using System.Net;

namespace CRM.HelperLogic
{
    /// <summary>
    /// Extension method for <see cref="HttpWebResponse"/>
    /// </summary>
    public static class HttpWebResponseExtensions
    {
        /// <summary>
        /// Return a <see cref="WebRequestResult{T}"/> pre-populated with the <see cref="HttpWebResponse"/> information
        /// </summary>
        /// <typeparam name="TResponse">The type of response to create</typeparam>
        /// <param name="serverResponse">The server response </param>
        /// <returns></returns>
        public static WebRequestResult<TResponse> CreateWebRequstResult<TResponse>(this HttpWebResponse serverResponse)
        {
            var result =  new WebRequestResult<TResponse>
            {
                ContentType = serverResponse.ContentType,
                Headers = serverResponse.Headers,
                Cookies = serverResponse.Cookies,
                StatusCode = serverResponse.StatusCode,
                StatusDescription = serverResponse.StatusDescription,

            };


            if (result.StatusCode == HttpStatusCode.OK)
            {
                using (var responseStream = serverResponse.GetResponseStream())
                using (var streanReader = new StreamReader(responseStream))
                    result.RawServerResponse = streanReader.ReadToEnd();
            }

            return result;
        }
    }
}
