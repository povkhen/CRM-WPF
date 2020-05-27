namespace CRM.HelperLogic
{
 
    public class HostedFrameworkConstruction : FrameworkConstruction
    {
        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public HostedFrameworkConstruction() : base(createServiceCollection: false)
        {

        }

        #endregion
    }
}
