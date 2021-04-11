using System;
using TMPS_LAB3.Interfaces;
using TMPS_LAB3.Types;

namespace TMPS_LAB3.Map
{
    public class Robbery : IProtection
    {
        public string ProtectionType { get; set; }
        public AsigType Type { get; set; }

        public Robbery(string protectionType, AsigType type)
        {
            ProtectionType = protectionType;
            Type = type;
        }

        public void Apply()
        {
            Console.WriteLine($"Protectia a fost aplicata pentru ,,{Type}'' cu tipul ,,{ProtectionType}'' \n");
        }
        public object Clone()
        {
            var copy = new Robbery(ProtectionType, Type)
            {
                ProtectionType = ProtectionType,
                Type = Type
            };

            return copy;
        }
    }
}
