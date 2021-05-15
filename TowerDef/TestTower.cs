using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDef
{
    class TestTower
    {
        Weapon.Weapon weapon = new Weapon.Arrow();
        public TestTower()
        {
            weapon.fire(new Weapon.Target());
        }
    }
}
