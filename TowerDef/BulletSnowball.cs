using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenTK.Graphics.OpenGL;

namespace TowerDef
{
    class Snowball : Bullet
    {
        public Snowball(Mob target, Tower parent)
            : base(target, parent)
        {

        }
        public override void StepTimerTick(object source, System.Timers.ElapsedEventArgs e)
        {
            move();
            if (Math.Abs(x - _target.x) <= 0.05 || Math.Abs(y - _target.y) <= 0.05)
            {
                StepTimer.Stop();
                _target.slow(_parent);
                _target.hit(_parent);
                base.hit();
            }
        }
        public override void draw()
        {
            /* //старая рисовка
            GL.Begin(BeginMode.Quads);
            Gl.glColor3d(0.0, 0.0, 1.0);
            
            GL.Vertex2(0.0 + x + 0.25, 0.5 + y + 0.25);
            GL.Vertex2(0.5 + x + 0.25, 0.5 + y + 0.25);
            GL.Vertex2(0.5 + x + 0.25, 0.0 + y + 0.25);
            GL.Vertex2(0.0 + x + 0.25, 0.0 + y + 0.25);

            GL.End();
            */
            GL.Begin(BeginMode.TriangleFan);
            GL.Color4(0.8422, 0.8422, 0.8422, 1.0);
            double radius = 0.25;
            for (int angle = 0; angle < 360; angle += 360/12) //шаг 10 похоже на снежок
            {
                GL.Vertex2(x + 0.5 + Math.Sin((double)angle / 180 * Math.PI) * radius, y + 0.5 + Math.Cos((double)angle / 180 * Math.PI) * radius);
            }
            GL.End();
        }
    }
}
