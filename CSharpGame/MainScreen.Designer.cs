namespace CSharpGame
{
    partial class MainScreen
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
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.newGameButton = new System.Windows.Forms.Button();
            this.Score = new System.Windows.Forms.Label();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ScoreLabel.Location = new System.Drawing.Point(12, 527);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(74, 25);
            this.ScoreLabel.TabIndex = 0;
            this.ScoreLabel.Text = "Score:";
            // 
            // newGameButton
            // 
            this.newGameButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.newGameButton.Location = new System.Drawing.Point(215, 436);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(149, 55);
            this.newGameButton.TabIndex = 1;
            this.newGameButton.Text = "New Game";
            this.newGameButton.UseVisualStyleBackColor = true;
            this.newGameButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.newGameButton_MouseClick);
            // 
            // Score
            // 
            this.Score.AutoSize = true;
            this.Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Score.Location = new System.Drawing.Point(92, 527);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(0, 25);
            this.Score.TabIndex = 2;
            // 
            // SettingsButton
            // 
            this.SettingsButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SettingsButton.Location = new System.Drawing.Point(215, 497);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(149, 55);
            this.SettingsButton.TabIndex = 4;
            this.SettingsButton.TabStop = false;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(584, 643);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.Score);
            this.Controls.Add(this.newGameButton);
            this.Controls.Add(this.ScoreLabel);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "MainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tanks game";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainScreen_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.Label Score;
        private System.Windows.Forms.Button SettingsButton;
    }
}

