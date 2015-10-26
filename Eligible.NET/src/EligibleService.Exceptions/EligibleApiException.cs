using EligibleService.Model;
using EligibleService.Model.Claim;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace EligibleService.Exceptions
{
    /// <summary>
    /// Eligible Exception calss to handle exceptions from 400 to 500. 
    /// If content has standard Eligible structure(refere Rest doc) then we will throw all those details using this EligibleApiException class.
    /// </summary>
    [Serializable]
    public class EligibleException : Exception
    {
        
        public dynamic EligibleError { get; set; }
        public EligibleException() : base()
        {}
        public EligibleException(String message)
            : base(message)
        { }
        public EligibleException(object response)
            : base()
        {
           this.EligibleError = response;
        }

        public EligibleException(string message, Exception inner)
            : base(message, inner)
        { }

        protected EligibleException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {}

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
