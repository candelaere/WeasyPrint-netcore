﻿using Gtb.WeasyPrint;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeasyPrintWrapper
{
    public class ConsoleTraceWriter : ITraceWriter
    {
        public void Info(string message)
        {
            Console.WriteLine(message);
        }

        public void Verbose(string message)
        {
            
        }
    }
}
