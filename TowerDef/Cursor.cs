using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenTK.Graphics.OpenGL;

namespace TowerDef
{
    class Cursor
    {
        private int posx = 0; //координата для отрисовки
        private int posy = 0; //координата для отрисовки
        public int i { get; set; } //координата для массива
        public int j { get; set; } //координата для массива
        public bool isAllow = false;
        private bool isVisible = false;

        public Cursor()
        {
            i = 0;
            j = 0;
            posx = 0;
            posy = 0;
        }
        public void move(int x, int y)
        {
            isVisible = true;
            this.i = (int)Game.GL_SCENE_HEIGHT - y -1;
            this.j = x;
            posx = x;
            posy = y;
        }
        public void draw(Map level)
        {
            if (isVisible)
            {
                GL.Begin(BeginMode.Quads);
                switch (level.map[i, j]) //занята ли клетка
                {
                    case 0: isAllow = true; break;
                    default: isAllow = false; break;
                }
                if (isAllow)
                    for (int index = 0; index < Tower.towers.Count; index++) //проверка нет ли башни
                    {
                        if ((int)Tower.towers[index].x == posx && (int)Tower.towers[index].y == posy)
                        {
                            isAllow = false;
                            break;
                        }
                    }
                if (isAllow) GL.Color4(0.0, 1.0, 0.0, 0.5);
                else GL.Color4(1.0, 0.0, 0.0, 0.5);

                GL.Vertex2(0.0 + posx, 1.0 + posy);
                GL.Vertex2(1.0 + posx, 1.0 + posy);
                GL.Vertex2(1.0 + posx, 0.0 + posy);
                GL.Vertex2(0.0 + posx, 0.0 + posy);

                GL.End();
            }
        }
    }
}
