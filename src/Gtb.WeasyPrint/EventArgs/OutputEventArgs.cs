using System;
using System.Collections.Generic;
using System.Text;

namespace Gtb.WeasyPrint
{
    public class OutputEventArgs : EventArgs
    {
        public string Data { get; set; }

        public OutputEventArgs()
        {

        }

        public OutputEventArgs(string data)
        {
            this.Data = data;
        }
    }
}
