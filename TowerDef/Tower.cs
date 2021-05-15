using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using OpenTK.Graphics.OpenGL;


namespace TowerDef
{
    abstract class Tower : Unit
    {
        public const int COST_ARROW_TOWER = 2;
        public const int COST_SPLASH_TOWER = 4;
        public const int COST_POISON_TOWER = 6;
        public const int COST_ICE_TOWER = 4;
        public const int COST_AIR_TOWER = 4;
        public const int COST_ULTIMATE_TOWER = 20;

        public static int[] texture = new int[6];

        //public enum Type { ArrowTower, SplashTower, PoisonTower, IceTower, AirTower, UltimateTower };
        
        protected Timer FindTimer;
        protected List<Bullet> bullets;
        public int _Kills = 0;
        public int UpgradeCost = 0;

        protected void FindTimerTick(object source, ElapsedEventArgs e)
        {
            fire();
        }

        public Tower(TowerType type, int x, int y):base(type)
        {
            this.x = x;
            this.y = y;
            _Level = 1;
            bullets = new List<Bullet>();
            FindTimer = new Timer();
            FindTimer.Elapsed += new ElapsedEventHandler(FindTimerTick);
            FindTimer.Interval = 3000 / _Speed;
            //upgrade();
        }
        public override void draw()
        {
            GL.Begin(BeginMode.LineStrip);
            GL.Color4(0.7422, 0.7422, 0.7422, 1.0);
            for (int angle = 0; angle <= 360; angle += 360 / 36) //шаг 10 похоже на снежок
            {
                GL.Vertex2(x + 0.5 + Math.Sin((double)angle / 180 * Math.PI) * _Radius, y + 0.5 + Math.Cos((double)angle / 180 * Math.PI) * _Radius);
            }
            GL.End();
            List<Bullet> tmp = new List<Bullet>(bullets);
            foreach (Bullet bullet in tmp) //отрисовка пуль выпущенных башней
            {
                bullet.draw();
            }
        }
        public bool isNear(Mob target) //определяет находится ли моб в области поражения
        {
            double dx = target.x - x;
            double dy = target.y - y;
            double r = Math.Sqrt(dx * dx + dy * dy);
            if (r < _Radius)
                return true;
            else return false;
        }
        public void BulletHit(Bullet bullet)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (bullets[i].Equals(bullet)) { bullets.RemoveAt(i); return; }
            }
        }
        public abstract void upgrade(ref int money);
        protected virtual Mob fire()
        {
            List<Mob> temp = new List<Mob>(mobs);
            foreach (Mob mob in temp)
            {
                if (isNear(mob))
                {
                    return mob;
                }
            }
            return null;
        }
    }
}
