using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDef.Weapon
{
    class Arrow : Weapon
    {
        public static int grade;
        public Arrow()
        {
            Damage.Value = 12.0;
            //Damage.spell.Add(Stun)
        }
    }
}
