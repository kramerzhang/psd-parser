﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ntreev.Library.PsdParser.Decoders
{
    class DecoderUnknownOSType : Properties
    {
        private readonly string value;

        public DecoderUnknownOSType(string value)
        {
            this.value = value;
            this.Add("Value", this.value);
        }
    }
}
