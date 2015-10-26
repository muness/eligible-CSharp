using EligibleService.Common;
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
    public class JsonDeserializationException : Exception
    {
        public EligibleError EligibleError { get; set; }

        public JsonDeserializationException() : base()
        {}

        public JsonDeserializationException(String message) : base(message)
        {}
        public JsonDeserializationException(string message, Exception innerException)
            : base(message, innerException)
        {
            EligibleError = new EligibleError();
            EligibleError.Content = message;
        }

        protected JsonDeserializationException(SerializationInfo info, StreamingContext context) 
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
