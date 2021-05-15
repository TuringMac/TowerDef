using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Drawing;

using OpenTK.Graphics.OpenGL;

namespace TowerDef
{
    abstract class Mob : Unit
    {
        protected Timer StepTimer;
        protected Timer SlowTimer;
        protected int NextPointIndex;
        protected List<Point> points;
        protected bool isSlow = false;
        protected double distance = 0.0;
        protected const double step = 0.05;
        
        public static int[] texture = new int[6]; //массив текстур для монстров
        public Mob(MobType type, int level):base(type)
        {
            _Level = level;
            x = 0;
            y = 0;
            NextPointIndex = 1;

            StepTimer = new Timer();
            StepTimer.Elapsed += new ElapsedEventHandler( StepTimerTick );
            StepTimer.Interval = 100.0 / _Speed;
        }
        public override void draw()
        {
            //----Status bar-----------
            GL.Begin(BeginMode.Quads);
            GL.Color4(0.0, 1.0, 0.0, 1.0);
            GL.Vertex2(0.0 + x, 0.05 + y);
            GL.Vertex2((double)_Health / (HEALTH + (int)(HEALTH * _Level * 0.2)) + x, 0.05 + y);
            GL.Vertex2((double)_Health / (HEALTH + (int)(HEALTH * _Level * 0.2)) + x, 0.0 + y);
            GL.Vertex2(0.0 + x, 0.0 + y);
            GL.End();
            
            GL.Begin(BeginMode.Quads);
            GL.Color4(1.0, 0.0, 0.0, 1.0);
            GL.Vertex2((double)_Health / (HEALTH + (int)(HEALTH * _Level * 0.2)) + x, 0.05 + y);
            GL.Vertex2(1.0 + x, 0.05 + y);
            GL.Vertex2(1.0 + x, 0.0 + y);
            GL.Vertex2((double)_Health / (HEALTH + (int)(HEALTH * _Level * 0.2)) + x, 0.0 + y);
            GL.End();
        }
        //public void move(float x, float y)
        //{
        //    this.x = x;
        //    this.y = y;
        //}
        public void StepTimerTick(object source, ElapsedEventArgs e) //каждый шаг монстра
        {
            if (Math.Abs(x - points[(int)NextPointIndex].X) < step)
            {
                x = points[(int)NextPointIndex].X;
            }
            if (Math.Abs(y - points[(int)NextPointIndex].Y) < step)
            {
                y = points[(int)NextPointIndex].Y;
            }
            if (x == points[(int)NextPointIndex].X && y == points[(int)NextPointIndex].Y)
            {
                if (NextPointIndex < points.Count) NextPointIndex++;
            }
            if (NextPointIndex == points.Count - 1) { StepTimer.Stop(); Game.Lives--; hit(null); return; } //если дошел до кристала

            if (x < points[(int)NextPointIndex].X) x += step;
            if (x > points[(int)NextPointIndex].X) x -= step;
            if (y < points[(int)NextPointIndex].Y) y += step;
            if (y > points[(int)NextPointIndex].Y) y -= step;

        }
        public void hit(Tower _parent) //монстр получил урон от башни
        {
            if (_parent == null)
            {
                StepTimer.Stop();
                for (int i = 0; i < Unit.mobs.Count; i++)
                {
                    if (Unit.mobs[i].Equals(this)) { StepTimer.Stop(); Unit.mobs.RemoveAt(i); return; }
                }
                return;
            }
            _Health -= _parent._Damage;
            if(_Health<=0)
            {
                for(int i = 0; i< Unit.mobs.Count; i++)
                {
                    if (Unit.mobs[i].Equals(this)) { StepTimer.Stop(); try { Unit.mobs.RemoveAt(i); } catch (Exception ex) { } _parent._Kills++; Game.Money += (_Level==1)?(1):(_Level / 2); return; }
                }
            }
        }
        public void slow(Tower _parent) //башня замедляет монстра
        {
            if(SlowTimer!=null)
            {
                SlowTimer.Stop();
                SlowTimer=null;
            }
            SlowTimer = new Timer();
            SlowTimer.Elapsed += new ElapsedEventHandler(SlowTimerTick);
            SlowTimer.Interval = _parent._Level * 300;
            isSlow = true;
            StepTimer.Interval = 100.0 / _Speed * (_parent._Level + 1);
            SlowTimer.Start();
        }
        public void SlowTimerTick(object source, ElapsedEventArgs e)
        {
            SlowTimer.Stop();
            isSlow = false;
            StepTimer.Interval = 100.0 / _Speed;
        }
    }
}
