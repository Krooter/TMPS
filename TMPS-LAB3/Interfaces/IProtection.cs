using System;
using System.Collections.Generic;
using System.Text;
using TMPS_LAB3.Types;

namespace TMPS_LAB3.Interfaces
{
    public interface IProtection : ICloneable
    {
        public string ProtectionType { get; set; }
        public AsigType Type { get; set; }
        public void Apply();
    }
}
