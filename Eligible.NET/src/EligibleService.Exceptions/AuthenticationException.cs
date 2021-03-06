﻿using EligibleService.Common;
using RestSharp;
using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace EligibleService.Exceptions
{
    [Serializable]
    public class AuthenticationException : Exception
    {
        public EligibleError EligibleError { get; set; }

        public AuthenticationException() : base() { }

        public AuthenticationException(string message) : base(message) { }

        public AuthenticationException(string message, Exception exception) : base(message, exception) { }

        public AuthenticationException(string message, IRestResponse response, Exception inner)
            : base(message, inner)
        {
            EligibleError = CommonErrorBuilder.BuildError(response);
        }

        protected AuthenticationException(SerializationInfo info, StreamingContext context) 
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
