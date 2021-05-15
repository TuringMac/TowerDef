using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDef
{
    abstract class Unit
    {
        protected readonly int HEALTH;
        protected readonly int SPEED;
        protected readonly int DAMAGE;
        protected readonly double RADIUS;
        private int Level;
        public int _Level { get { return Level; } protected set { _Health = HEALTH + (int)(HEALTH * value * 0.2); _Speed = SPEED + SPEED * value * 0.1; _Radius = RADIUS + RADIUS * value * 0.1; _Damage = DAMAGE + (int)(DAMAGE * value * 0.2); Level = value; } }
        public int _Health { get; protected set; }
        public double _Speed { get; protected set; }
        public int _Damage { get; protected set; }
        public double _Radius { get; protected set; }
        public TowerType Type;

        //public UnitType _type;
        public static List<Mob> mobs = new List<Mob>(); //массив для мобов, которые сейчас на карте
        public static List<Tower> towers = new List<Tower>(); //массив башен (для отрисовки)
        
        //public enum MobType { Zerg, Ghost, Roach, Prisoner };
        //public enum TowerType { Arrow, Splash, Poison, Ice, AntiAir, Ultimate }
        
        public double x { protected set; get; }
        public double y { protected set; get; }
        public abstract void draw();

        protected Unit(MobType type)
        {
            switch(type)
            {
                case MobType.Zerg: SPEED = 1; HEALTH = 20; break;
                case MobType.Roach: SPEED = 4; HEALTH = 20; break;
                case MobType.Ghost: SPEED = 3; HEALTH = 30; break;
            }
        }
        protected Unit(TowerType type)
        {
            Type = type;
            switch (type)
            {
                case TowerType.Arrow: SPEED = 10; DAMAGE = 4; RADIUS = 1.5; break;
                case TowerType.Poison: SPEED = 1; DAMAGE = 10; RADIUS = 2.5; break;
                case TowerType.Ice: SPEED = 4; DAMAGE = 1; RADIUS = 1.5; break;
            }
            //HEALTH = 1;
        }

    }
}
