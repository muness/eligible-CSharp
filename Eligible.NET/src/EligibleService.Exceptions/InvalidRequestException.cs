using EligibleService.Common;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace EligibleService.Exceptions
{
    [Serializable]
    public class InvalidRequestException : Exception
    {
        public EligibleError EligibleError { get; set; }

        public InvalidRequestException() : base()
        {}
        public InvalidRequestException(string message) : base(message)
        {
            EligibleError = new EligibleError();
            EligibleError.Content = message;
            
        }

        public InvalidRequestException(string message, Exception innerException)
            : base(message, innerException)
        {
            EligibleError = new EligibleError();
            EligibleError.Content = message;

        }
        public InvalidRequestException(string message, IRestResponse response, Exception inner)
            : base(message, inner)
        {
            EligibleError = CommonErrorBuilder.BuildError(response);
        }

        protected InvalidRequestException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
            this.EligibleError = (EligibleError)info.GetValue("EligibleError", typeof(EligibleError));
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            info.AddValue("ResourceName", this.EligibleError);
            base.GetObjectData(info, context);
        }
    }

    
}
