using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Timers;

using OpenTK.Graphics.OpenGL;

namespace TowerDef
{
    class Roach : Mob
    {
        public Roach(List<Point> points, int wave) //передаю список вейпоинтов и номер волны
            : base(MobType.Roach, wave)
        {
            this.points = points;
            x = points[0].X;
            y = points[0].Y;
            //NextPointIndex = 1;
            //StepTimer.Interval = 10.0 / _Speed;
            StepTimer.Start();
        }
        public override void draw()
        {
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, Mob.texture[0]);

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
    }
}
