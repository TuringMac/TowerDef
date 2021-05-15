using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenTK.Graphics.OpenGL;
using OpenTK.Platform.Windows;

namespace TowerDef
{
    class TowerArrow : Tower
    {
        public TowerArrow(int x, int y)
            : base(TowerType.Arrow, x, y)
        {
            UpgradeCost = (_Level + 1) * COST_ARROW_TOWER;
            FindTimer.Start();
        }
        public override void upgrade(ref int money)
        {
            if (money >= UpgradeCost && _Level < 10)
            {
                money -= UpgradeCost;
                _Level++;
                UpgradeCost = (_Level + 1) * COST_ARROW_TOWER;
                FindTimer.Interval = 3000 / _Speed;
            }
        }
        public override void draw()
        {
            /*
            GL.Begin(BeginMode.Quads);
            GL.Color4(0.0, 0.0, 0.5, 0.5);
            
            GL.Vertex2(0.0 + x, 1.0 + y);
            GL.Vertex2(1.0 + x, 1.0 + y);
            GL.Vertex2(1.0 + x, 0.0 + y);
            GL.Vertex2(0.0 + x, 0.0 + y);

            GL.End();
            */
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texture[0]);
            GL.Begin(BeginMode.Quads);
            GL.Color4(1.0, 1.0, 1.0, 1.0);
            GL.TexCoord2(0, 1); GL.Vertex2(0.0 + x, 0.0 + y);  //4
            GL.TexCoord2(1, 1); GL.Vertex2(1.0 + x, 0.0 + y);  //3
            GL.TexCoord2(1, 0); GL.Vertex2(1.0 + x, 1.0 + y);  //2
            GL.TexCoord2(0, 0); GL.Vertex2(0.0 + x, 1.0 + y);  //1

            GL.End();
            GL.Disable(EnableCap.Texture2D);
            /*
            GL.Begin(BeginMode.TriangleFan);
            GL.Color4(0.0, 0.0, 0.5, 1.0);
            for (int angle = 0; angle < 360; angle += 360/12)
            {
                GL.Vertex2(x + 0.5 + Math.Sin((double)angle/180*Math.PI) * 0.5, y + 0.5 + Math.Cos((double)angle/180*Math.PI) * 0.5);
            }
            GL.End();
            */
            //GL.Color3(1.0, 1.0, 1.0);
            //GL.RasterPos2(0.41 + x, 0.37 + y);
            //BitmapCharacter(Glut.GLUT_BITMAP_8_BY_13, 'A');
            
            base.draw();
        }
        protected override Mob fire()
        {
            Mob mob = base.fire();
            if(mob!=null)
                bullets.Add(new Arrow(mob, this));
            return mob;
        }
    }
}
