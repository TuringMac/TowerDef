using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenTK.Graphics.OpenGL;
using OpenTK.Platform.Windows;

namespace TowerDef
{
    class TowerIce : Tower
    {
        public TowerIce(int x, int y)
            : base(TowerType.Ice, x, y)
        {
            UpgradeCost = (_Level + 1) * COST_ICE_TOWER;
            FindTimer.Start();

        }
        public override void upgrade(ref int money)
        {
            if (money >= UpgradeCost && _Level < 10)
            {
                money -= UpgradeCost;
                _Level++;
                UpgradeCost = (_Level + 1) * COST_ICE_TOWER;
                FindTimer.Interval = 3000 / _Speed;
            }
        }
        public override void draw()
        {
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texture[3]);
            GL.Begin(BeginMode.Quads);
            GL.Color4(1.0, 1.0, 1.0, 1.0);
            GL.TexCoord2(0, 1); GL.Vertex2(0.0 + x, 0.0 + y);  //4
            GL.TexCoord2(1, 1); GL.Vertex2(1.0 + x, 0.0 + y);  //3
            GL.TexCoord2(1, 0); GL.Vertex2(1.0 + x, 1.0 + y);  //2
            GL.TexCoord2(0, 0); GL.Vertex2(0.0 + x, 1.0 + y);  //1

            GL.End();
            GL.Disable(EnableCap.Texture2D);
            
            base.draw();
        }
        protected override Mob fire()
        {
            Mob mob = base.fire();
            if (mob != null)
                bullets.Add(new Snowball(mob, this));
            return mob;
        }

    }
}
