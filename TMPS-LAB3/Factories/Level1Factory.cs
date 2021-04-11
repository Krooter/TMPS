using System;
using System.Collections.Generic;
using System.Text;
using TMPS_LAB3.Enemies;
using TMPS_LAB3.Interfaces;
using TMPS_LAB3.Map;
using TMPS_LAB3.Types;

namespace TMPS_LAB3.Factories
{
    class Level1Factory : ILevelFactory
    {
        public IType CreateAsigurationType(string owner, int id, AsigType type)
        {
            return new House(id, owner, type);
        }

        public IProtection CreateProtection(string protectionType, AsigType type)
        {
            return new Robbery(protectionType, type);
        }
    }
}
