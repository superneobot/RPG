namespace EditorRPG
{
    partial class editorform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(editorform));
            this.ControlPanel = new System.Windows.Forms.Panel();
            this.clear_btn = new System.Windows.Forms.Button();
            this.draw_grid_bool = new System.Windows.Forms.CheckBox();
            this.load_btn = new System.Windows.Forms.Button();
            this.save_btn = new System.Windows.Forms.Button();
            this.road_btn = new System.Windows.Forms.Button();
            this.brick_btn = new System.Windows.Forms.Button();
            this.earth = new System.Windows.Forms.Button();
            this.top_grass_btn = new System.Windows.Forms.Button();
            this.bottom_grass_btn = new System.Windows.Forms.Button();
            this.grass = new System.Windows.Forms.Button();
            this.box = new System.Windows.Forms.Button();
            this.mouse_pos = new System.Windows.Forms.Label();
            this.m_size = new System.Windows.Forms.Label();
            this.cleared_btn = new System.Windows.Forms.Button();
            this.Viewport = new EditorRPG.ViewPortBox();
            this.ControlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ControlPanel
            // 
            this.ControlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ControlPanel.Controls.Add(this.cleared_btn);
            this.ControlPanel.Controls.Add(this.clear_btn);
            this.ControlPanel.Controls.Add(this.draw_grid_bool);
            this.ControlPanel.Controls.Add(this.load_btn);
            this.ControlPanel.Controls.Add(this.save_btn);
            this.ControlPanel.Controls.Add(this.road_btn);
            this.ControlPanel.Controls.Add(this.brick_btn);
            this.ControlPanel.Controls.Add(this.earth);
            this.ControlPanel.Controls.Add(this.top_grass_btn);
            this.ControlPanel.Controls.Add(this.bottom_grass_btn);
            this.ControlPanel.Controls.Add(this.grass);
            this.ControlPanel.Controls.Add(this.box);
            this.ControlPanel.Controls.Add(this.mouse_pos);
            this.ControlPanel.Controls.Add(this.m_size);
            this.ControlPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ControlPanel.Location = new System.Drawing.Point(0, 0);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(1026, 100);
            this.ControlPanel.TabIndex = 0;
            this.ControlPanel.Click += new System.EventHandler(this.ControlPanel_Click);
            // 
            // clear_btn
            // 
            this.clear_btn.Location = new System.Drawing.Point(173, 70);
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.Size = new System.Drawing.Size(75, 23);
            this.clear_btn.TabIndex = 6;
            this.clear_btn.Text = "Clear";
            this.clear_btn.UseVisualStyleBackColor = true;
            this.clear_btn.Click += new System.EventHandler(this.clear_btn_Click);
            // 
            // draw_grid_bool
            // 
            this.draw_grid_bool.AutoSize = true;
            this.draw_grid_bool.Location = new System.Drawing.Point(11, 47);
            this.draw_grid_bool.Name = "draw_grid_bool";
            this.draw_grid_bool.Size = new System.Drawing.Size(71, 17);
            this.draw_grid_bool.TabIndex = 5;
            this.draw_grid_bool.Text = "Draw grid";
            this.draw_grid_bool.UseVisualStyleBackColor = true;
            this.draw_grid_bool.CheckedChanged += new System.EventHandler(this.draw_grid_bool_CheckedChanged);
            this.draw_grid_bool.Click += new System.EventHandler(this.draw_grid_bool_Click);
            // 
            // load_btn
            // 
            this.load_btn.Location = new System.Drawing.Point(92, 70);
            this.load_btn.Name = "load_btn";
            this.load_btn.Size = new System.Drawing.Size(75, 23);
            this.load_btn.TabIndex = 4;
            this.load_btn.Text = "Load map";
            this.load_btn.UseVisualStyleBackColor = true;
            this.load_btn.Click += new System.EventHandler(this.load_btn_Click);
            // 
            // save_btn
            // 
            this.save_btn.Location = new System.Drawing.Point(11, 70);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(75, 23);
            this.save_btn.TabIndex = 3;
            this.save_btn.Text = "Save map";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // road_btn
            // 
            this.road_btn.FlatAppearance.BorderSize = 0;
            this.road_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.road_btn.Image = ((System.Drawing.Image)(resources.GetObject("road_btn.Image")));
            this.road_btn.Location = new System.Drawing.Point(355, 8);
            this.road_btn.Name = "road_btn";
            this.road_btn.Size = new System.Drawing.Size(32, 32);
            this.road_btn.TabIndex = 2;
            this.road_btn.UseVisualStyleBackColor = true;
            this.road_btn.Click += new System.EventHandler(this.road_btn_Click);
            // 
            // brick_btn
            // 
            this.brick_btn.FlatAppearance.BorderSize = 0;
            this.brick_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.brick_btn.Image = ((System.Drawing.Image)(resources.GetObject("brick_btn.Image")));
            this.brick_btn.Location = new System.Drawing.Point(317, 8);
            this.brick_btn.Name = "brick_btn";
            this.brick_btn.Size = new System.Drawing.Size(32, 32);
            this.brick_btn.TabIndex = 2;
            this.brick_btn.UseVisualStyleBackColor = true;
            this.brick_btn.Click += new System.EventHandler(this.brick_btn_Click);
            // 
            // earth
            // 
            this.earth.FlatAppearance.BorderSize = 0;
            this.earth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.earth.Image = ((System.Drawing.Image)(resources.GetObject("earth.Image")));
            this.earth.Location = new System.Drawing.Point(279, 8);
            this.earth.Name = "earth";
            this.earth.Size = new System.Drawing.Size(32, 32);
            this.earth.TabIndex = 2;
            this.earth.UseVisualStyleBackColor = true;
            this.earth.Click += new System.EventHandler(this.earth_Click);
            // 
            // top_grass_btn
            // 
            this.top_grass_btn.FlatAppearance.BorderSize = 0;
            this.top_grass_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.top_grass_btn.Image = ((System.Drawing.Image)(resources.GetObject("top_grass_btn.Image")));
            this.top_grass_btn.Location = new System.Drawing.Point(393, 8);
            this.top_grass_btn.Name = "top_grass_btn";
            this.top_grass_btn.Size = new System.Drawing.Size(32, 32);
            this.top_grass_btn.TabIndex = 2;
            this.top_grass_btn.UseVisualStyleBackColor = true;
            this.top_grass_btn.Click += new System.EventHandler(this.top_grass_btn_Click);
            // 
            // bottom_grass_btn
            // 
            this.bottom_grass_btn.FlatAppearance.BorderSize = 0;
            this.bottom_grass_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bottom_grass_btn.Image = ((System.Drawing.Image)(resources.GetObject("bottom_grass_btn.Image")));
            this.bottom_grass_btn.Location = new System.Drawing.Point(241, 8);
            this.bottom_grass_btn.Name = "bottom_grass_btn";
            this.bottom_grass_btn.Size = new System.Drawing.Size(32, 32);
            this.bottom_grass_btn.TabIndex = 2;
            this.bottom_grass_btn.UseVisualStyleBackColor = true;
            this.bottom_grass_btn.Click += new System.EventHandler(this.bottom_grass_btn_Click);
            // 
            // grass
            // 
            this.grass.FlatAppearance.BorderSize = 0;
            this.grass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grass.Image = ((System.Drawing.Image)(resources.GetObject("grass.Image")));
            this.grass.Location = new System.Drawing.Point(203, 8);
            this.grass.Name = "grass";
            this.grass.Size = new System.Drawing.Size(32, 32);
            this.grass.TabIndex = 2;
            this.grass.UseVisualStyleBackColor = true;
            this.grass.Click += new System.EventHandler(this.grass_Click);
            // 
            // box
            // 
            this.box.FlatAppearance.BorderSize = 0;
            this.box.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.box.Image = ((System.Drawing.Image)(resources.GetObject("box.Image")));
            this.box.Location = new System.Drawing.Point(165, 8);
            this.box.Name = "box";
            this.box.Size = new System.Drawing.Size(32, 32);
            this.box.TabIndex = 2;
            this.box.UseVisualStyleBackColor = true;
            this.box.Click += new System.EventHandler(this.box_Click);
            // 
            // mouse_pos
            // 
            this.mouse_pos.AutoSize = true;
            this.mouse_pos.Location = new System.Drawing.Point(11, 30);
            this.mouse_pos.Name = "mouse_pos";
            this.mouse_pos.Size = new System.Drawing.Size(65, 13);
            this.mouse_pos.TabIndex = 1;
            this.mouse_pos.Text = "Mouse pos: ";
            // 
            // m_size
            // 
            this.m_size.AutoSize = true;
            this.m_size.Location = new System.Drawing.Point(11, 8);
            this.m_size.Name = "m_size";
            this.m_size.Size = new System.Drawing.Size(57, 13);
            this.m_size.TabIndex = 0;
            this.m_size.Text = "Map Size: ";
            // 
            // cleared_btn
            // 
            this.cleared_btn.BackColor = System.Drawing.Color.Black;
            this.cleared_btn.FlatAppearance.BorderSize = 0;
            this.cleared_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.cleared_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.cleared_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cleared_btn.Location = new System.Drawing.Point(431, 8);
            this.cleared_btn.Name = "cleared_btn";
            this.cleared_btn.Size = new System.Drawing.Size(32, 32);
            this.cleared_btn.TabIndex = 7;
            this.cleared_btn.UseVisualStyleBackColor = false;
            this.cleared_btn.Click += new System.EventHandler(this.cleared_btn_Click);
            // 
            // Viewport
            // 
            this.Viewport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Viewport.Location = new System.Drawing.Point(0, 100);
            this.Viewport.Name = "Viewport";
            this.Viewport.Size = new System.Drawing.Size(1026, 1025);
            this.Viewport.TabIndex = 1;
            this.Viewport.Paint += new System.Windows.Forms.PaintEventHandler(this.Viewport_Paint);
            this.Viewport.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Viewport_MouseDown);
            this.Viewport.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Viewport_MouseMove);
            this.Viewport.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Viewport_MouseUp);
            // 
            // editorform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 1125);
            this.Controls.Add(this.Viewport);
            this.Controls.Add(this.ControlPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "editorform";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor RPG";
            this.Load += new System.EventHandler(this.editorform_Load);
            this.ControlPanel.ResumeLayout(false);
            this.ControlPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ControlPanel;
        private ViewPortBox Viewport;
        private System.Windows.Forms.Label m_size;
        private System.Windows.Forms.Label mouse_pos;
        private System.Windows.Forms.Button box;
        private System.Windows.Forms.Button load_btn;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Button earth;
        private System.Windows.Forms.Button bottom_grass_btn;
        private System.Windows.Forms.Button grass;
        private System.Windows.Forms.Button road_btn;
        private System.Windows.Forms.Button brick_btn;
        private System.Windows.Forms.Button top_grass_btn;
        private System.Windows.Forms.CheckBox draw_grid_bool;
        private System.Windows.Forms.Button clear_btn;
        private System.Windows.Forms.Button cleared_btn;
    }
}

