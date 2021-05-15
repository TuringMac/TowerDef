using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDef.Weapon
{
    class Target
    {
        private double hitpoints = 100.0;
        public Target()
        {

        }
        public void hit(Weapon weapon)
        {
            hitpoints -= weapon.Damage.Value;
        }
    }
}
