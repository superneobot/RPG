namespace GameRPG
{
    partial class mainform
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Viewport = new GameRPG.ViewPortBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Viewport
            // 
            this.Viewport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Viewport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Viewport.Location = new System.Drawing.Point(0, 0);
            this.Viewport.Name = "Viewport";
            this.Viewport.Size = new System.Drawing.Size(1026, 1026);
            this.Viewport.TabIndex = 0;
            this.Viewport.Paint += new System.Windows.Forms.PaintEventHandler(this.Viewport_Paint);
            this.Viewport.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Viewport_MouseDown);
            this.Viewport.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Viewport_MouseMove);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 1026);
            this.Controls.Add(this.Viewport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mainform";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game RPG";
            this.ResumeLayout(false);

        }

        #endregion

        private ViewPortBox Viewport;
        private System.Windows.Forms.Timer timer1;
    }
}

