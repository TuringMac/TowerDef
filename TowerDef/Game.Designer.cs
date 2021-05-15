namespace TowerDef
{
    partial class Game
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.RenderTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.UltimateTowerIco = new System.Windows.Forms.PictureBox();
            this.ArrowTowerIco = new System.Windows.Forms.PictureBox();
            this.AirTowerIco = new System.Windows.Forms.PictureBox();
            this.IceTowerIco = new System.Windows.Forms.PictureBox();
            this.PoisonTowerIco = new System.Windows.Forms.PictureBox();
            this.SplashTowerIco = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMoney = new System.Windows.Forms.Label();
            this.TipTower = new System.Windows.Forms.ToolTip(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.glControl = new OpenTK.GLControl();
            this.label6 = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblDamage = new System.Windows.Forms.Label();
            this.lblRadius = new System.Windows.Forms.Label();
            this.btnUpgrade = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblKills = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.gbxInfo = new System.Windows.Forms.GroupBox();
            this.lblLives = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.gbxDebugPos = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lblWave = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltimateTowerIco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrowTowerIco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AirTowerIco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IceTowerIco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PoisonTowerIco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplashTowerIco)).BeginInit();
            this.gbxInfo.SuspendLayout();
            this.gbxDebugPos.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(624, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 23);
            this.button1.TabIndex = 0;
            this.button1.TabStop = false;
            this.button1.Text = "Начать игру";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(625, 589);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.TabStop = false;
            this.button2.Text = "Выйти";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // RenderTimer
            // 
            this.RenderTimer.Interval = 15;
            this.RenderTimer.Tick += new System.EventHandler(this.RenderTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.UltimateTowerIco);
            this.groupBox1.Controls.Add(this.ArrowTowerIco);
            this.groupBox1.Controls.Add(this.AirTowerIco);
            this.groupBox1.Controls.Add(this.IceTowerIco);
            this.groupBox1.Controls.Add(this.PoisonTowerIco);
            this.groupBox1.Controls.Add(this.SplashTowerIco);
            this.groupBox1.Location = new System.Drawing.Point(625, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(237, 172);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Towers";
            // 
            // UltimateTowerIco
            // 
            this.UltimateTowerIco.Location = new System.Drawing.Point(160, 90);
            this.UltimateTowerIco.Name = "UltimateTowerIco";
            this.UltimateTowerIco.Size = new System.Drawing.Size(64, 64);
            this.UltimateTowerIco.TabIndex = 5;
            this.UltimateTowerIco.TabStop = false;
            // 
            // ArrowTowerIco
            // 
            this.ArrowTowerIco.Image = global::TowerDef.Properties.Resources.ArrowTower;
            this.ArrowTowerIco.Location = new System.Drawing.Point(10, 20);
            this.ArrowTowerIco.Name = "ArrowTowerIco";
            this.ArrowTowerIco.Size = new System.Drawing.Size(64, 64);
            this.ArrowTowerIco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ArrowTowerIco.TabIndex = 4;
            this.ArrowTowerIco.TabStop = false;
            this.TipTower.SetToolTip(this.ArrowTowerIco, "Стреломет\r\n----------------------\r\nАтака: Воздух + Земля\r\nЦена: 2");
            this.ArrowTowerIco.Click += new System.EventHandler(this.ArrowTowerIco_Click);
            // 
            // AirTowerIco
            // 
            this.AirTowerIco.Location = new System.Drawing.Point(85, 90);
            this.AirTowerIco.Name = "AirTowerIco";
            this.AirTowerIco.Size = new System.Drawing.Size(64, 64);
            this.AirTowerIco.TabIndex = 3;
            this.AirTowerIco.TabStop = false;
            // 
            // IceTowerIco
            // 
            this.IceTowerIco.Image = global::TowerDef.Properties.Resources.IceTower;
            this.IceTowerIco.Location = new System.Drawing.Point(10, 90);
            this.IceTowerIco.Name = "IceTowerIco";
            this.IceTowerIco.Size = new System.Drawing.Size(64, 64);
            this.IceTowerIco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.IceTowerIco.TabIndex = 2;
            this.IceTowerIco.TabStop = false;
            this.TipTower.SetToolTip(this.IceTowerIco, "Леденая Башня\r\n-----------------\r\nЦена: 4\r\nРадиус: 1.5\r\nЗамедляет монстров на вре" +
        "мя");
            this.IceTowerIco.Click += new System.EventHandler(this.IceTowerIco_Click);
            // 
            // PoisonTowerIco
            // 
            this.PoisonTowerIco.Image = global::TowerDef.Properties.Resources.PoisonTower;
            this.PoisonTowerIco.Location = new System.Drawing.Point(160, 20);
            this.PoisonTowerIco.Name = "PoisonTowerIco";
            this.PoisonTowerIco.Size = new System.Drawing.Size(64, 64);
            this.PoisonTowerIco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PoisonTowerIco.TabIndex = 1;
            this.PoisonTowerIco.TabStop = false;
            this.TipTower.SetToolTip(this.PoisonTowerIco, "Башня Зелий\r\n\r\nЦена: 6\r\nАтака\r\nРадиус\r\nУрон");
            this.PoisonTowerIco.Click += new System.EventHandler(this.PoisonTowerIco_Click);
            // 
            // SplashTowerIco
            // 
            this.SplashTowerIco.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.SplashTowerIco.Enabled = false;
            this.SplashTowerIco.Image = global::TowerDef.Properties.Resources.SplashTower;
            this.SplashTowerIco.Location = new System.Drawing.Point(85, 20);
            this.SplashTowerIco.Name = "SplashTowerIco";
            this.SplashTowerIco.Size = new System.Drawing.Size(64, 64);
            this.SplashTowerIco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SplashTowerIco.TabIndex = 0;
            this.SplashTowerIco.TabStop = false;
            this.TipTower.SetToolTip(this.SplashTowerIco, "Взрывная Башня\r\n----------------\r\nАтака: только Земля\r\nЦена: 4");
            this.SplashTowerIco.Visible = false;
            this.SplashTowerIco.Click += new System.EventHandler(this.SplashTowerIco_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(744, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Монет:";
            // 
            // lblMoney
            // 
            this.lblMoney.AutoSize = true;
            this.lblMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMoney.Location = new System.Drawing.Point(820, 17);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Size = new System.Drawing.Size(26, 24);
            this.lblMoney.TabIndex = 5;
            this.lblMoney.Text = "-1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "label5";
            // 
            // glControl
            // 
            this.glControl.BackColor = System.Drawing.Color.Black;
            this.glControl.Location = new System.Drawing.Point(12, 12);
            this.glControl.Name = "glControl";
            this.glControl.Size = new System.Drawing.Size(600, 600);
            this.glControl.TabIndex = 8;
            this.glControl.VSync = false;
            this.glControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseClick);
            this.glControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseMove);
            this.glControl.Resize += new System.EventHandler(this.glControl_Resize);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 626);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(209, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Created by Baranov Igor 2012 (TuringMac)";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(100, 110);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(16, 13);
            this.lblSpeed.TabIndex = 10;
            this.lblSpeed.Text = "-1";
            // 
            // lblDamage
            // 
            this.lblDamage.AutoSize = true;
            this.lblDamage.Location = new System.Drawing.Point(100, 90);
            this.lblDamage.Name = "lblDamage";
            this.lblDamage.Size = new System.Drawing.Size(16, 13);
            this.lblDamage.TabIndex = 9;
            this.lblDamage.Text = "-1";
            // 
            // lblRadius
            // 
            this.lblRadius.AutoSize = true;
            this.lblRadius.Location = new System.Drawing.Point(100, 70);
            this.lblRadius.Name = "lblRadius";
            this.lblRadius.Size = new System.Drawing.Size(16, 13);
            this.lblRadius.TabIndex = 8;
            this.lblRadius.Text = "-1";
            // 
            // btnUpgrade
            // 
            this.btnUpgrade.Location = new System.Drawing.Point(15, 130);
            this.btnUpgrade.Name = "btnUpgrade";
            this.btnUpgrade.Size = new System.Drawing.Size(209, 23);
            this.btnUpgrade.TabIndex = 5;
            this.btnUpgrade.Text = "-1";
            this.btnUpgrade.UseVisualStyleBackColor = true;
            this.btnUpgrade.Click += new System.EventHandler(this.btnUpgrade_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 110);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Скорость:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Урон:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Радиус:";
            // 
            // lblKills
            // 
            this.lblKills.AutoSize = true;
            this.lblKills.Location = new System.Drawing.Point(100, 50);
            this.lblKills.Name = "lblKills";
            this.lblKills.Size = new System.Drawing.Size(16, 13);
            this.lblKills.TabIndex = 7;
            this.lblKills.Text = "-1";
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(100, 30);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(16, 13);
            this.lblLevel.TabIndex = 6;
            this.lblLevel.Text = "-1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Убито:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Уровень:";
            // 
            // gbxInfo
            // 
            this.gbxInfo.Controls.Add(this.btnUpgrade);
            this.gbxInfo.Controls.Add(this.lblSpeed);
            this.gbxInfo.Controls.Add(this.label7);
            this.gbxInfo.Controls.Add(this.lblDamage);
            this.gbxInfo.Controls.Add(this.label11);
            this.gbxInfo.Controls.Add(this.lblLevel);
            this.gbxInfo.Controls.Add(this.lblRadius);
            this.gbxInfo.Controls.Add(this.label8);
            this.gbxInfo.Controls.Add(this.label10);
            this.gbxInfo.Controls.Add(this.lblKills);
            this.gbxInfo.Controls.Add(this.label9);
            this.gbxInfo.Location = new System.Drawing.Point(624, 290);
            this.gbxInfo.Name = "gbxInfo";
            this.gbxInfo.Size = new System.Drawing.Size(235, 172);
            this.gbxInfo.TabIndex = 11;
            this.gbxInfo.TabStop = false;
            this.gbxInfo.Text = "Информация";
            this.gbxInfo.Visible = false;
            // 
            // lblLives
            // 
            this.lblLives.AutoSize = true;
            this.lblLives.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLives.Location = new System.Drawing.Point(820, 50);
            this.lblLives.Name = "lblLives";
            this.lblLives.Size = new System.Drawing.Size(26, 24);
            this.lblLives.TabIndex = 12;
            this.lblLives.Text = "-1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(733, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 24);
            this.label12.TabIndex = 13;
            this.label12.Text = "Жизней:";
            // 
            // gbxDebugPos
            // 
            this.gbxDebugPos.Controls.Add(this.label4);
            this.gbxDebugPos.Controls.Add(this.label5);
            this.gbxDebugPos.Controls.Add(this.label1);
            this.gbxDebugPos.Controls.Add(this.label2);
            this.gbxDebugPos.Location = new System.Drawing.Point(757, 575);
            this.gbxDebugPos.Name = "gbxDebugPos";
            this.gbxDebugPos.Size = new System.Drawing.Size(105, 64);
            this.gbxDebugPos.TabIndex = 14;
            this.gbxDebugPos.TabStop = false;
            this.gbxDebugPos.Text = "Отладка";
            this.gbxDebugPos.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(747, 83);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 24);
            this.label13.TabIndex = 15;
            this.label13.Text = "Волна:";
            // 
            // lblWave
            // 
            this.lblWave.AutoSize = true;
            this.lblWave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWave.Location = new System.Drawing.Point(820, 83);
            this.lblWave.Name = "lblWave";
            this.lblWave.Size = new System.Drawing.Size(26, 24);
            this.lblWave.TabIndex = 16;
            this.lblWave.Text = "-1";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(872, 644);
            this.Controls.Add(this.lblWave);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.gbxDebugPos);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblLives);
            this.Controls.Add(this.gbxInfo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.glControl);
            this.Controls.Add(this.lblMoney);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Game";
            this.Text = "Tower Defense";
            this.Load += new System.EventHandler(this.Game_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UltimateTowerIco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrowTowerIco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AirTowerIco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IceTowerIco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PoisonTowerIco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplashTowerIco)).EndInit();
            this.gbxInfo.ResumeLayout(false);
            this.gbxInfo.PerformLayout();
            this.gbxDebugPos.ResumeLayout(false);
            this.gbxDebugPos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer RenderTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox SplashTowerIco;
        private System.Windows.Forms.PictureBox PoisonTowerIco;
        private System.Windows.Forms.PictureBox UltimateTowerIco;
        private System.Windows.Forms.PictureBox ArrowTowerIco;
        private System.Windows.Forms.PictureBox AirTowerIco;
        private System.Windows.Forms.PictureBox IceTowerIco;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMoney;
        private System.Windows.Forms.ToolTip TipTower;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private OpenTK.GLControl glControl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblDamage;
        private System.Windows.Forms.Label lblRadius;
        private System.Windows.Forms.Label lblKills;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Button btnUpgrade;
        private System.Windows.Forms.GroupBox gbxInfo;
        private System.Windows.Forms.Label lblLives;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox gbxDebugPos;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblWave;
    }
}

