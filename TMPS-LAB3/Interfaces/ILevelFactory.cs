using System;
using System.Collections.Generic;
using System.Text;
using TMPS_LAB3.Types;

namespace TMPS_LAB3.Interfaces
{
    interface ILevelFactory
    {
        IProtection CreateProtection(string protectionType, AsigType type);
        IType CreateAsigurationType(string owner, int id, AsigType type);
    }
}
