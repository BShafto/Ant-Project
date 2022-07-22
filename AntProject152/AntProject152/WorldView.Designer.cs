namespace AntProject152
{
    partial class WorldView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.antWorld = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtNoAnts = new System.Windows.Forms.TextBox();
            this.timerLabel = new System.Windows.Forms.Label();
            this.timerTrackBar = new System.Windows.Forms.TrackBar();
            this.sliderLabel = new System.Windows.Forms.Label();
            this.simpleTimer = new System.Windows.Forms.Timer(this.components);
            this.lbNoFood = new System.Windows.Forms.Label();
            this.lbNoNests = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.timerTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // antWorld
            // 
            this.antWorld.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.antWorld.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.antWorld.Location = new System.Drawing.Point(108, 12);
            this.antWorld.Name = "antWorld";
            this.antWorld.Size = new System.Drawing.Size(751, 369);
            this.antWorld.TabIndex = 0;
            this.antWorld.MouseDown += new System.Windows.Forms.MouseEventHandler(this.antWorld_MouseDown);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 130);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtNoAnts
            // 
            this.txtNoAnts.Location = new System.Drawing.Point(12, 72);
            this.txtNoAnts.Name = "txtNoAnts";
            this.txtNoAnts.Size = new System.Drawing.Size(75, 20);
            this.txtNoAnts.TabIndex = 0;
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Location = new System.Drawing.Point(12, 12);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(0, 13);
            this.timerLabel.TabIndex = 0;
            // 
            // timerTrackBar
            // 
            this.timerTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timerTrackBar.Location = new System.Drawing.Point(108, 400);
            this.timerTrackBar.Maximum = 100;
            this.timerTrackBar.Minimum = 10;
            this.timerTrackBar.Name = "timerTrackBar";
            this.timerTrackBar.Size = new System.Drawing.Size(751, 45);
            this.timerTrackBar.TabIndex = 2;
            this.timerTrackBar.TickFrequency = 10;
            this.timerTrackBar.Value = 10;
            this.timerTrackBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // sliderLabel
            // 
            this.sliderLabel.AutoSize = true;
            this.sliderLabel.Location = new System.Drawing.Point(12, 39);
            this.sliderLabel.Name = "sliderLabel";
            this.sliderLabel.Size = new System.Drawing.Size(0, 13);
            this.sliderLabel.TabIndex = 3;
            // 
            // simpleTimer
            // 
            this.simpleTimer.Tick += new System.EventHandler(this.TimerTick);
            // 
            // lbNoFood
            // 
            this.lbNoFood.AutoSize = true;
            this.lbNoFood.Location = new System.Drawing.Point(12, 202);
            this.lbNoFood.Name = "lbNoFood";
            this.lbNoFood.Size = new System.Drawing.Size(31, 13);
            this.lbNoFood.TabIndex = 5;
            this.lbNoFood.Text = "Food";
            // 
            // lbNoNests
            // 
            this.lbNoNests.AutoSize = true;
            this.lbNoNests.Location = new System.Drawing.Point(12, 175);
            this.lbNoNests.Name = "lbNoNests";
            this.lbNoNests.Size = new System.Drawing.Size(0, 13);
            this.lbNoNests.TabIndex = 4;
            // 
            // WorldView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(871, 457);
            this.Controls.Add(this.lbNoFood);
            this.Controls.Add(this.lbNoNests);
            this.Controls.Add(this.sliderLabel);
            this.Controls.Add(this.timerTrackBar);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.txtNoAnts);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.antWorld);
            this.Name = "WorldView";
            this.Text = "WorldView";
            this.Load += new System.EventHandler(this.AntForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.timerTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel antWorld;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtNoAnts;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.TrackBar timerTrackBar;
        private System.Windows.Forms.Label sliderLabel;
        private System.Windows.Forms.Timer simpleTimer;
        private System.Windows.Forms.Label lbNoFood;
        private System.Windows.Forms.Label lbNoNests;
    }
}

