using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace TowerDef.Weapon
{
    class Weapon
    {
        public bool isReady = true;
        Timer FireTimer = new Timer();
        public TowerDef.Weapon.Damage Damage = new TowerDef.Weapon.Damage();
        public double range = 2.0;

        public Weapon()
        {
        }

        public void fire(Target target)
        {
            target.hit(this);
        }
    }
}
