using System;
using System.Collections.Generic;
using System.Text;
using TMPS_LAB3.Interfaces;
using TMPS_LAB3.Types;

namespace TMPS_LAB3.Map
{
    public class Crush : IProtection
    {
        public string ProtectionType { get; set; }
        public AsigType Type { get; set; }

        public Crush(string protectionType, AsigType type)
        {
            ProtectionType = protectionType;
            Type = type;
        }

        public void Apply()
        {
            Console.WriteLine($"Protectia pentru {Type} cu tipul {ProtectionType} \n");
        }

        public object Clone()
        {
            var copy = new Crush(ProtectionType, Type)
            {
                ProtectionType = ProtectionType,
                Type = Type
            };

            return copy;
        }
    }
}
