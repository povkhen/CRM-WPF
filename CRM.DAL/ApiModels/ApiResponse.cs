namespace CRM.DAL
{
    /// <summary>
    /// The response for all Web API calls made
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResponse<T>
    {
        #region Constructor



        #endregion

        #region Pubkic Properties

        /// <summary>
        /// Indicates if the API call was successfull
        /// </summary>
        public bool Successfull => ErrorMessage == null;


        /// <summary>
        /// The error message for a failed API call
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// The API response object
        /// </summary>
        public T Response { get; set; }

        #endregion

    }
}
