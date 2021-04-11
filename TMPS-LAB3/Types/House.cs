using System;
using System.Collections.Generic;
using System.Text;
using TMPS_LAB3.Interfaces;
using TMPS_LAB3.Types;

namespace TMPS_LAB3.Enemies
{
    public class House : IType
    {
        public int Id { get; set; }
        public string Owner { get; set; }
        public AsigType Type { get; set; }

        public House(int id, string owner, AsigType type)
        {
            Id = id;
            Owner = owner;
            Type = type;
        }

        public void Create()
        {
            Console.WriteLine($"Asigurarea pentru {Type} cu proprietarul {Owner} a fost creata cu succes!");
        }

        public object Clone()
        {
            var copy = new House(Id, Owner, Type)
            {
                Id = Id,
                Owner = Owner,
                Type = Type
            };

            return copy;
        }
    }
}
