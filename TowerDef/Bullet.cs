using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace TowerDef
{
    abstract class Bullet
    {
        protected Tower _parent;
        protected Mob _target;
        protected Timer StepTimer;
        protected double x;
        protected double y;
        public Bullet(Mob target, Tower parent)
        {
            _parent = parent;
            _target = target;
            x = _parent.x;
            y = _parent.y;
            StepTimer = new Timer();
            StepTimer.Elapsed += new ElapsedEventHandler(StepTimerTick);
            StepTimer.Interval = 15;
            StepTimer.Start();
        }
        protected void move()
        {
            double dx = (_target.x - _parent.x);
            double dy = (_target.y - _parent.y);
            double R = (float)Math.Sqrt(dx * dx + dy * dy);
            this.x += dx / R * 0.1f;
            this.y += dy / R * 0.1f;
        }
        public abstract void draw();
        public virtual void hit()
        {
            _parent.BulletHit(this);
        }
        public abstract void StepTimerTick(object source, ElapsedEventArgs e);
    }
}
