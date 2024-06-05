using System;
using System.Collections.Generic;
using System.Text;

namespace Gtb.WeasyPrint
{
    [Serializable]
    public class WeasyPrintException : Exception
    {

        public WeasyPrintException() { }
        public WeasyPrintException(string message) : base(message) { }
        public WeasyPrintException(string message, Exception inner) : base(message, inner) { }
        protected WeasyPrintException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
