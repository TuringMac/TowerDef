using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//using System.Drawing.Imaging;
using OpenTK.Graphics.OpenGL;
using OpenTK.Platform.Windows;
using System.Drawing.Imaging;

namespace TowerDef
{
    public partial class Game : Form
    {
        //private bool loaded = false;
        public const float GL_SCENE_WIDTH = 15.0f;
        public const float GL_SCENE_HEIGHT = 15.0f;

        private Cursor cursor;
        private Tower SelectedTower;
        private Map lvl1;  //карта для сражения
        private bool isTowerSelected = false;  //сообщает выбрана ли для установки башня
        private TowerType SelectedTowerType; //сообщает тип выбранной башни
        
        private static int money = 6; //капитал для покупки башен
        public static int lives = 10;
        private static int wavenum = 1;
        private const int winwave = 10;
        public static int Lives { get { return lives; } set { lives = value; } }
        public static int Money { get { return money; } set { money = value; } }
        public static int WaveNum { get { return wavenum; } set { wavenum = value; } }

        public Game()
        {
            InitializeComponent();
            //AnT.InitializeContexts();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //RenderTimer.Start(); //запуск таймера отрисовки сцены
            //lvl1.WaveTimer.Start(); //ждет релиза
        }

        private void Game_Load(object sender, EventArgs e)
        {
            //----------------------------------------------------------------------------
            GL.ClearColor(Color.Black);
            SetupViewport();
            //GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);

            Map.texture[0] = Game.LoadTexture(Properties.Resources.grass_tile_64x64); //tile of grass
            Map.texture[1] = Game.LoadTexture(Properties.Resources.Crystal);
            Map.texture[2] = Game.LoadTexture(Properties.Resources.tree_tex);
            Map.texture[3] = Game.LoadTexture(Properties.Resources.Pavement);
            Map.texture[4] = Game.LoadTexture(Properties.Resources.Hatchery);

            Tower.texture[0] = Game.LoadTexture(Properties.Resources.ArrowTower);
            Tower.texture[1] = Game.LoadTexture(Properties.Resources.SplashTower);
            Tower.texture[2] = Game.LoadTexture(Properties.Resources.PoisonTower);
            Tower.texture[3] = Game.LoadTexture(Properties.Resources.IceTower);

            Mob.texture[0] = Game.LoadTexture(Properties.Resources.Roach);
            Mob.texture[1] = Game.LoadTexture(Properties.Resources.Zerg);
            Mob.texture[2] = Game.LoadTexture(Properties.Resources.Ghost);
            GL.Disable(EnableCap.Texture2D);
            lvl1 = new Map(); //выделяется память для крты уровня
            //loaded = true;
            RenderTimer.Start(); //запуск таймера отрисовки сцены
            
        }
        private void SetupViewport()
        {
            int w = glControl.Width;
            int h = glControl.Height;
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            if (w <= h)
                GL.Ortho(0, GL_SCENE_WIDTH, 0, GL_SCENE_HEIGHT * (double)h / (double)w, -1, 1); // Верхний левый угол имеет кооординаты(0, 0)
            else
                GL.Ortho(0.0, GL_SCENE_WIDTH * (float)w / (float)h, 0.0, GL_SCENE_HEIGHT, -1, 1);
            GL.Viewport(0, 0, w, h); // Использовать всю поверхность GLControl под рисование
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // функия Draw 
        private void Draw()
        {
            List<Mob> temp = new List<Mob>(Unit.mobs);
            List<Tower> tow = new List<Tower>(Unit.towers);
            lblMoney.Text = money.ToString();
            

            lvl1.draw();
            /*
            foreach (Mob mob in Unit.mobs)
            {
                mob.draw();
            }
            */
            foreach (Mob mob in temp)
            {
                mob.draw();
            }
            //foreach (Tower tower in Unit.towers)
            //{
            //    tower.draw();
            //}
            foreach (Tower tower in tow)
            {
                tower.draw();
            }
            if (isTowerSelected) cursor.draw(lvl1);
        }

        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            // очищаем буфер цвета 
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            Draw(); //регулярная отрисовка сцены

            GL.Flush(); // дожидаемся завершения визуализации кадра

            glControl.Invalidate(); // обновляем изображение в элементе glControl
            glControl.SwapBuffers();
            lblLives.Text = Lives.ToString();
            lblMoney.Text = Money.ToString();
            lblWave.Text = WaveNum.ToString();
            win();
            over();
        }

        private void glControl_MouseClick(object sender, MouseEventArgs e)
        {
            int i = 0;
            int j = 0;
            trans(e.X, e.Y, ref i, ref j); //преобразую координаты Компонента в координаты сцены
            if (isTowerSelected && cursor.isAllow) //если была выбрана башня и курсор позволяет её сюда установить
            {
                switch (SelectedTowerType)
                {
                    case TowerType.Arrow: if (buy(TowerType.Arrow)) SelectedTower = new TowerArrow(j, i); break; //покупка и установка башни
                    //case TowerType.Splash: 
                    case TowerType.Poison: if (buy(TowerType.Poison)) SelectedTower = new TowerPoison(j, i); break; //покупка и установка башни
                    case TowerType.Ice: if (buy(TowerType.Ice)) SelectedTower = new TowerIce(j, i); break; //покупка и установка башни
                    //case Tower.Type.AntiAir:
                    //case Tower.Type.Ultimate:
                }
                Unit.towers.Add(SelectedTower);
                isTowerSelected = false;
                cursor = null;
                info(SelectedTower);
            }
            else
            {
                SelectedTower = null;
                for (int index = 0; index < Tower.towers.Count; index++)
                {
                    if ((int)Tower.towers[index].x == j && (int)Tower.towers[index].y == i)
                    {
                        SelectedTower = Tower.towers[index];
                        break;
                    }
                }
                info(SelectedTower);
            }
        }
        //----------------------------Click on Icon with tower----------------------------------------------------------------------------------
        private void ArrowTowerIco_Click(object sender, EventArgs e)
        {
            if (money >= Tower.COST_ARROW_TOWER)
            {
                SelectedTowerType = TowerType.Arrow;
                isTowerSelected = true;
                cursor = new Cursor();
            }
            else
            {
                //сообщение о нехватке средств
            }
        }
        private void SplashTowerIco_Click(object sender, EventArgs e)
        {
            if (money >= Tower.COST_SPLASH_TOWER) //хватает ли денег на покупку
            {
                SelectedTowerType = TowerType.Splash;
                isTowerSelected = true; //башня выбрана, можно выбирать место для её установки
            }
            else
            {
                //сообщение о нехватке средств
            }
        }
        private void PoisonTowerIco_Click(object sender, EventArgs e)
        {
            if (money >= Tower.COST_ICE_TOWER)
            {
                SelectedTowerType = TowerType.Poison;
                isTowerSelected = true;
                cursor = new Cursor();
            }
            else
            {
                //сообщение о нехватке средств
            }
        }
        private void IceTowerIco_Click(object sender, EventArgs e)
        {
            if (money >= Tower.COST_ICE_TOWER)
            {
                SelectedTowerType = TowerType.Ice;
                isTowerSelected = true;
                cursor = new Cursor();
            }
            else
            {
                //сообщение о нехватке средств
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------------

        private void glControl_MouseMove(object sender, MouseEventArgs e)
        {
            label4.Text = "X: " + e.X.ToString(); //тестовый параметр: координаты внутри Компонента
            label5.Text = "Y:" + e.Y.ToString(); //тестовый параметр: координаты внутри Компонента
            label1.Text = "X: " + ((int)(e.X * GL_SCENE_WIDTH / glControl.Width)).ToString(); //координаты Компонента преобразованы в координаты Сцены
            label2.Text = "Y: " + ((int)((glControl.Height - e.Y) * GL_SCENE_HEIGHT / glControl.Height)).ToString(); //координаты Компонента преобразованы в координаты Сцены

            int i = 0;
            int j = 0;
            if (isTowerSelected) //перемещение курсора, если выбрана башня
            {
                trans(e.X, e.Y, ref i, ref j);
                cursor.move(j, i);
            }
        }

        private bool buy(TowerType type) //определяет возможность покупки и покупает при наличии таковой
        {
            switch (type)
            {
                case TowerType.Arrow:
                    if (money >= Tower.COST_ARROW_TOWER)
                    {
                        money -= Tower.COST_ARROW_TOWER;
                        break;
                    }
                    else
                        return false;
                case TowerType.Splash:
                    if (money >= Tower.COST_SPLASH_TOWER)
                    {
                        money -= Tower.COST_SPLASH_TOWER;
                        break;
                    }
                    else
                        return false;
                case TowerType.Poison:
                    if (money >= Tower.COST_POISON_TOWER)
                    {
                        money -= Tower.COST_POISON_TOWER;
                        break;
                    }
                    else
                        return false;
                case TowerType.Ice:
                    if (money >= Tower.COST_ICE_TOWER)
                    {
                        money -= Tower.COST_ICE_TOWER;
                        break;
                    }
                    else
                        return false;
                case TowerType.AntiAir: money -= Tower.COST_AIR_TOWER; break;
                case TowerType.Ultimate: money -= Tower.COST_ULTIMATE_TOWER; break;
            }
            //lblMoney.Text = money.ToString();
            return true;
        }
        public void trans(int x, int y, ref int iindex, ref int jindex)
        {
            jindex = (int)(x * GL_SCENE_WIDTH / glControl.Width);
            iindex = (int)((glControl.Height - y) * GL_SCENE_HEIGHT / glControl.Height);
            
            if (iindex >= Game.GL_SCENE_HEIGHT) iindex = (int)Game.GL_SCENE_HEIGHT -1;
            if (iindex < 0) iindex = 0;
            if (jindex >= Game.GL_SCENE_WIDTH) jindex = (int)Game.GL_SCENE_WIDTH - 1;
            if (jindex < 0) jindex = 0;
        }

        private void glControl_Resize(object sender, EventArgs e)
        {
            SetupViewport();
            glControl.Invalidate();
        }
        public static int LoadTexture(Bitmap bmp)
        {
            bmp.MakeTransparent(Color.Magenta);
            int id = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, id);

            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            GL.TexImage2D(
                OpenTK.Graphics.OpenGL.TextureTarget.Texture2D,   // texture_target,
                0,                                                // level,
                OpenTK.Graphics.OpenGL.PixelInternalFormat.Rgba,  // internal_format
                data.Width, data.Height,                          // width, height, 
                0,                                                // border,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra,          // pixel_format
                OpenTK.Graphics.OpenGL.PixelType.UnsignedByte,    // pixel_type
                data.Scan0                                        // pixels
                );
            bmp.UnlockBits(data);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            return id;
        }
        private void info(Tower tower)
        {
            if (tower != null)
            {
                lblLevel.Text = tower._Level.ToString();
                lblKills.Text = tower._Kills.ToString();
                lblRadius.Text = tower._Radius.ToString()+" клеток"; //String.Format("{5,14}", tower._Radius.ToString());
                lblDamage.Text = tower._Damage.ToString();
                lblSpeed.Text = String.Format("{0:0.##}(в сек)", 3 / tower._Speed); //(3 / tower._Speed).ToString() + "(в сек)";
                btnUpgrade.Text = "Улучшить за " + tower.UpgradeCost.ToString() + " монет";
                gbxInfo.Show();
            }
            else
            {
                gbxInfo.Hide();
                lblLevel.Text = "-1";
                lblRadius.Text = "-1";
                lblDamage.Text = "-1";
                lblSpeed.Text = "-1";
            }
        }

        private void btnUpgrade_Click(object sender, EventArgs e)
        {
            SelectedTower.upgrade(ref money);
            info(SelectedTower);
        }
        public void over()
        {
            if (Game.Lives <= 0)
            {
                RenderTimer.Stop();
                Unit.towers.Clear();
                Unit.mobs.Clear();
                new Finish(2).Show();
            }
            
        }
        public void win()
        {
            if (Game.WaveNum >= winwave)
            {
                RenderTimer.Stop();
                Unit.towers.Clear();
                Unit.mobs.Clear();
                new Finish(1).Show();
            }
            
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (gbxDebugPos.Visible) gbxDebugPos.Visible = false;
            else gbxDebugPos.Visible = true;
        }
        
    }//end of class
}
