namespace CRM.HelperLogic
{
    /// <summary>
    /// Extension methods for <see cref="KnownContentSerializers"/>
    /// </summary>
    public static class KnownContentSerializersExtensions
    {
        /// <summary>
        /// Takes a known serializer type and returns the Mime type  associated  with it
        /// </summary>
        /// <param name="serializers">The serializer</param>
        /// <returns></returns>
        public static string ToMimeString(this KnownContentSerializers serializers)
        {
            switch (serializers)
            {
                case KnownContentSerializers.Json:
                    return "application/json";
                case KnownContentSerializers.Xml:
                    return "application/xml";


                default:
                    return "application/octet-stream";
            }
        }
    }
}
