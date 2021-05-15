using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Drawing;
using System.Timers;

using System.IO;
using OpenTK.Graphics.OpenGL;

namespace TowerDef
{
    class Map
    {
        public Map()
        {
            WayPoints = new List<Point>();
            WayPoints.Add(new Point(2, 14));
            WayPoints.Add(new Point(2, 9));
            WayPoints.Add(new Point(7, 9));
            WayPoints.Add(new Point(7, 5));
            WayPoints.Add(new Point(3, 5));
            WayPoints.Add(new Point(3, 1));
            WayPoints.Add(new Point(12, 1));
            WayPoints.Add(new Point(12, 11));
            WayPoints.Add(new Point(11, 11));

            waves.Add(new int[] { 1, 1, 1, 1, 1, 1 });
            waves.Add(new int[] { 1, 1, 1, 1, 1, 2 });
            waves.Add(new int[] { 1, 2, 1, 1, 2, 1 });
            waves.Add(new int[] { 1, 1, 2, 2, 2, 2 });
            waves.Add(new int[] { 2, 1, 3, 3, 2, 2 });
            waves.Add(new int[] { 1, 1, 1, 1, 1, 1 });
            waves.Add(new int[] { 2, 2, 2, 3, 3, 3 });
            waves.Add(new int[] { 3, 1, 2, 2, 3, 3 });
            waves.Add(new int[] { 1, 1, 1, 1, 1, 1 });
            waves.Add(new int[] { 2, 1, 1, 1, 2, 2, 2, 1, 3, 3 });//10
            waves.Add(new int[] { 1, 1, 1, 1, 1, 1 });
            waves.Add(new int[] { 1, 1, 1, 1, 1, 2 });
            waves.Add(new int[] { 1, 2, 1, 1, 2, 1 });
            waves.Add(new int[] { 1, 1, 1, 1, 1, 1, 1, 1 });
            waves.Add(new int[] { 1, 1, 1, 1, 1, 1, 1, 1 });
            waves.Add(new int[] { 1, 1, 1, 1, 1, 1, 1, 1 });
            waves.Add(new int[] { 1, 1, 1, 1, 1, 1, 1, 1 });
            waves.Add(new int[] { 1, 1, 1, 1, 1, 1, 1, 1 });
            waves.Add(new int[] { 1, 1, 1, 1, 1, 1, 1, 1 });
            waves.Add(new int[] { 1, 1, 1, 1, 1, 1, 1, 1 });//20

            WaveTimer = new Timer();
            WaveTimer.Elapsed += new ElapsedEventHandler(WaveTimerTick);
            WaveTimer.Interval = 30000;
            WaveTimer.Start();

            MobTimer = new Timer();
            MobTimer.Elapsed += new ElapsedEventHandler(MobTimerTick);
            MobTimer.Interval = 3000;
            MobTimer.Start();
        }
        public Timer WaveTimer;
        private Timer MobTimer;
        //public List<Mob> mobs = new List<Mob>(); //массив для мобов, которые сейчас на карте
        //private Zerg zerg;
        //private static int wavenum = 1;
        private static int mobnum = 0;
        List<int[]> waves = new List<int[]>();
        public static int[] texture = new int[12];
        public int[,] map = new int[(int)Game.GL_SCENE_HEIGHT,(int)Game.GL_SCENE_WIDTH]{
                                            {0,0,3,0,0,0,0,0,0,0,0,1,0,0,0},
                                            {0,0,2,0,0,0,0,1,0,0,0,0,1,0,0},
                                            {0,0,2,0,0,1,1,1,0,0,1,1,1,0,0},
                                            {0,0,2,0,0,0,0,0,0,0,0,4,2,0,0},
                                            {0,0,2,0,0,0,0,0,0,0,0,0,2,0,0},
                                            {0,0,2,2,2,2,2,2,0,0,0,0,2,0,0},
                                            {0,0,0,0,0,0,0,2,0,0,1,0,2,0,0},
                                            {0,0,0,1,1,1,1,2,1,0,1,1,2,1,1},
                                            {0,0,0,0,1,1,1,2,1,1,1,1,2,1,1},
                                            {0,0,0,2,2,2,2,2,1,1,1,1,2,1,1},
                                            {0,0,0,2,0,1,1,1,1,1,0,0,2,0,0},
                                            {0,0,0,2,1,0,1,1,1,0,0,0,2,0,0},
                                            {0,0,0,2,0,1,0,1,1,0,0,0,2,0,0},
                                            {0,0,0,2,2,2,2,2,2,2,2,2,2,0,0},
                                            {0,0,0,0,0,0,1,1,0,0,0,0,0,0,0},
                                            };

        // 0 - трава, на которой можно строить
        // 1 - блок, в котором нельзя расположить башню
        // 2 - тропа для Монстров
        // 3 - Спавн - точка появления Монстров
        // 4 - Кристал - цель Монстров
        // 5 - ж
        //public int[] Wave = new int[] {1,1,1,1,1,1,1,1}; //список мобов в волне
        public List<Point> WayPoints;

        public void draw()
        {
            for (int i = (int)Game.GL_SCENE_HEIGHT-1, y = 0; i >= 0; i--, y++)
            {
                for (int j = 0, x = 0; j < (int)Game.GL_SCENE_WIDTH; j++, x++)
                {
                    switch (map[i, j])
                    {
                        case 0: GL.Enable(EnableCap.Texture2D);
                                GL.BindTexture(TextureTarget.Texture2D, texture[0]);//трава
                                GL.Begin(BeginMode.Quads); 
                                break;

                        case 1: GL.Enable(EnableCap.Texture2D);
                                GL.BindTexture(TextureTarget.Texture2D, texture[0]);//трава
                                GL.Begin(BeginMode.Quads);
                                GL.Color4(1.0, 1.0, 1.0, 1.0);
                                GL.TexCoord2(0, 1); GL.Vertex2(0.0 + x, 0.0 + y);  //4
                                GL.TexCoord2(1, 1); GL.Vertex2(1.0 + x, 0.0 + y);  //3
                                GL.TexCoord2(1, 0); GL.Vertex2(1.0 + x, 1.0 + y);  //2
                                GL.TexCoord2(0, 0); GL.Vertex2(0.0 + x, 1.0 + y);  //1

                                GL.End();
                                GL.BindTexture(TextureTarget.Texture2D, texture[2]);//дерево
                                GL.Begin(BeginMode.Quads); 
                                break;

                        case 2: GL.Enable(EnableCap.Texture2D);
                                GL.BindTexture(TextureTarget.Texture2D, texture[3]);//тропа
                                GL.Begin(BeginMode.Quads); 
                                break;

                        case 3: GL.Enable(EnableCap.Texture2D);
                                GL.BindTexture(TextureTarget.Texture2D, texture[3]);//тропа
                                GL.Begin(BeginMode.Quads);
                                GL.Color4(1.0, 1.0, 1.0, 1.0);
                                GL.TexCoord2(0, 1); GL.Vertex2(0.0 + x, 0.0 + y);  //4
                                GL.TexCoord2(1, 1); GL.Vertex2(1.0 + x, 0.0 + y);  //3
                                GL.TexCoord2(1, 0); GL.Vertex2(1.0 + x, 1.0 + y);  //2
                                GL.TexCoord2(0, 0); GL.Vertex2(0.0 + x, 1.0 + y);  //1

                                GL.End();
                                GL.BindTexture(TextureTarget.Texture2D, texture[4]);
                                GL.Begin(BeginMode.Quads); //спавн
                                break;

                        case 4: GL.Enable(EnableCap.Texture2D);
                                GL.BindTexture(TextureTarget.Texture2D, texture[3]);//тропа
                                GL.Begin(BeginMode.Quads);
                                GL.Color4(1.0, 1.0, 1.0, 1.0);
                                GL.TexCoord2(0, 1); GL.Vertex2(0.0 + x, 0.0 + y);  //4
                                GL.TexCoord2(1, 1); GL.Vertex2(1.0 + x, 0.0 + y);  //3
                                GL.TexCoord2(1, 0); GL.Vertex2(1.0 + x, 1.0 + y);  //2
                                GL.TexCoord2(0, 0); GL.Vertex2(0.0 + x, 1.0 + y);  //1

                                GL.End();
                                GL.BindTexture(TextureTarget.Texture2D, texture[1]);
                                GL.Begin(BeginMode.Quads); //кристал
                                break;

                        default: break;
                    } //end switch

                    GL.Color4(1.0, 1.0, 1.0, 1.0);
                    GL.TexCoord2(0, 1); GL.Vertex2(0.0 + x, 0.0 + y);  //4
                    GL.TexCoord2(1, 1); GL.Vertex2(1.0 + x, 0.0 + y);  //3
                    GL.TexCoord2(1, 0); GL.Vertex2(1.0 + x, 1.0 + y);  //2
                    GL.TexCoord2(0, 0); GL.Vertex2(0.0 + x, 1.0 + y);  //1

                    GL.End();
                    GL.Disable(EnableCap.Texture2D);
                } //end j
            } //end i
            //GL.Disable(EnableCap.Texture2D);
        } //end draw

        private void WaveTimerTick(object source, ElapsedEventArgs e)
        {
            Game.WaveNum++;
            MobTimer.Start();
        }
        private void MobTimerTick(object source, ElapsedEventArgs e)
        {
            if (mobnum < waves[Game.WaveNum - 1].Length)
            {
                switch (waves[Game.WaveNum - 1][mobnum])
                {
                    case 1: Unit.mobs.Add(new Zerg(WayPoints, Game.WaveNum)); break;
                    case 2: Unit.mobs.Add(new Roach(WayPoints, Game.WaveNum)); break;
                    case 3: Unit.mobs.Add(new Ghost(WayPoints, Game.WaveNum)); break;
                }
                mobnum++;
            }
            else
            {
                MobTimer.Stop();
                MobTimer.Interval = 3000 / Game.WaveNum;
                mobnum = 0;
            }
        }

    }//end of class

}
