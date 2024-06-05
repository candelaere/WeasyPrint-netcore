﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Gtb.WeasyPrint
{
    public interface ITraceWriter
    {
        void Info(string message);

        void Verbose(string message);
    }
}
