using System.Net;

namespace CRM.HelperLogic
{
    /// <summary>
    /// A web response from a call to get generic object data from a HTTP server
    /// </summary>
    public class WebRequestResult
    {
        /// <summary>
        /// if the call is successfull
        /// </summary>
        public bool Successfull => ErrorMessage == null;

        /// <summary>
        /// if something failed, this is a error message
        /// </summary>
        public string  ErrorMessage { get; set; }

        /// <summary>
        /// Status code
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// The status description
        /// </summary>
        public string StatusDescription { get; set; }

        /// <summary>
        /// The type of content return by the server
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// All the response headers
        /// </summary>
        public WebHeaderCollection Headers { get; set; }

        /// <summary>
        /// Any cookies
        /// </summary>
        public CookieCollection Cookies { get; set; }

        /// <summary>
        /// The raw server response body
        /// </summary>
        public string RawServerResponse { get; set; }

        /// <summary>
        /// The actual server response as an object
        /// </summary>
        public object ServerResponse { get; set; }
    }


    /// <summary>
    /// A web response from a call to get specific data from a HTTP server
    /// </summary>
    /// <typeparam name="T">The type of data to deserialize the raw body into</typeparam>
    public class WebRequestResult<T> : WebRequestResult
    {
        /// <summary>
        /// Casts the underlying object to specified type
        /// </summary>
        public new T ServerResponse { get; set; }
    }
}
