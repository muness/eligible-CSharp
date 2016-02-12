using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace EligibleService.Exceptions
{
    /// <summary>
    /// Eligible Exception class to handle exceptions from 400 to 500. 
    /// If content has standard Eligible structure(refer Rest doc) then we will throw all those details using this EligibleApiException class.
    /// </summary>
    [Serializable]
    public class EligibleException : Exception
    {
        public dynamic EligibleError { get; set; }

        public EligibleException() : base() { }

        public EligibleException(string message)
            : base(message)
        { }

        public EligibleException(string message, object response)
            : base(message)
        {
           this.EligibleError = response;
        }

        public EligibleException(string message, Exception inner)
            : base(message, inner)
        { }

        protected EligibleException(SerializationInfo info, StreamingContext context)
            : base(info, context) 
        { }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            base.GetObjectData(info, context);
        }
    }
}
