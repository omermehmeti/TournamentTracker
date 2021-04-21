namespace TournamentUI
{
    partial class Tournamentv
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tournamentv));
            this.HeaderLabel = new System.Windows.Forms.Label();
            this.TournamentName = new System.Windows.Forms.Label();
            this.Round = new System.Windows.Forms.Label();
            this.RoundDropdown = new System.Windows.Forms.ComboBox();
            this.Unplayedbox = new System.Windows.Forms.CheckBox();
            this.matchupListBox = new System.Windows.Forms.ListBox();
            this.teamOneName = new System.Windows.Forms.Label();
            this.TeamoneScoreLabel = new System.Windows.Forms.Label();
            this.teamOneScoreText = new System.Windows.Forms.TextBox();
            this.teamtwoScoreText = new System.Windows.Forms.TextBox();
            this.ScoreteamoneLabel = new System.Windows.Forms.Label();
            this.teamtwoName = new System.Windows.Forms.Label();
            this.VsLabel = new System.Windows.Forms.Label();
            this.ScoreButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HeaderLabel
            // 
            this.HeaderLabel.AutoSize = true;
            this.HeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.HeaderLabel.Location = new System.Drawing.Point(12, 21);
            this.HeaderLabel.Name = "HeaderLabel";
            this.HeaderLabel.Size = new System.Drawing.Size(229, 42);
            this.HeaderLabel.TabIndex = 0;
            this.HeaderLabel.Text = "Tournament:";
            this.HeaderLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // TournamentName
            // 
            this.TournamentName.AutoSize = true;
            this.TournamentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TournamentName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.TournamentName.Location = new System.Drawing.Point(247, 21);
            this.TournamentName.Name = "TournamentName";
            this.TournamentName.Size = new System.Drawing.Size(146, 42);
            this.TournamentName.TabIndex = 1;
            this.TournamentName.Text = "<none>";
            // 
            // Round
            // 
            this.Round.AutoSize = true;
            this.Round.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Round.ForeColor = System.Drawing.SystemColors.GrayText;
            this.Round.Location = new System.Drawing.Point(26, 85);
            this.Round.Name = "Round";
            this.Round.Size = new System.Drawing.Size(57, 20);
            this.Round.TabIndex = 2;
            this.Round.Text = "Round";
            // 
            // RoundDropdown
            // 
            this.RoundDropdown.FormattingEnabled = true;
            this.RoundDropdown.Location = new System.Drawing.Point(106, 84);
            this.RoundDropdown.Name = "RoundDropdown";
            this.RoundDropdown.Size = new System.Drawing.Size(234, 21);
            this.RoundDropdown.TabIndex = 3;
            this.RoundDropdown.SelectedIndexChanged += new System.EventHandler(this.RoundDropdown_SelectedIndexChanged);
            // 
            // Unplayedbox
            // 
            this.Unplayedbox.AutoSize = true;
            this.Unplayedbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Unplayedbox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Unplayedbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.Unplayedbox.Location = new System.Drawing.Point(145, 127);
            this.Unplayedbox.Name = "Unplayedbox";
            this.Unplayedbox.Size = new System.Drawing.Size(109, 21);
            this.Unplayedbox.TabIndex = 4;
            this.Unplayedbox.Text = "Unplayed Only";
            this.Unplayedbox.UseVisualStyleBackColor = true;
            this.Unplayedbox.CheckedChanged += new System.EventHandler(this.Unplayedbox_CheckedChanged);
            // 
            // matchupListBox
            // 
            this.matchupListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.matchupListBox.FormattingEnabled = true;
            this.matchupListBox.Location = new System.Drawing.Point(19, 160);
            this.matchupListBox.Name = "matchupListBox";
            this.matchupListBox.Size = new System.Drawing.Size(321, 197);
            this.matchupListBox.TabIndex = 5;
            this.matchupListBox.SelectedIndexChanged += new System.EventHandler(this.matchupListBox_SelectedIndexChanged);
            // 
            // teamOneName
            // 
            this.teamOneName.AutoSize = true;
            this.teamOneName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamOneName.ForeColor = System.Drawing.SystemColors.GrayText;
            this.teamOneName.Location = new System.Drawing.Point(447, 172);
            this.teamOneName.Name = "teamOneName";
            this.teamOneName.Size = new System.Drawing.Size(94, 20);
            this.teamOneName.TabIndex = 6;
            this.teamOneName.Text = "<team one>";
            // 
            // TeamoneScoreLabel
            // 
            this.TeamoneScoreLabel.AutoSize = true;
            this.TeamoneScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TeamoneScoreLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.TeamoneScoreLabel.Location = new System.Drawing.Point(438, 205);
            this.TeamoneScoreLabel.Name = "TeamoneScoreLabel";
            this.TeamoneScoreLabel.Size = new System.Drawing.Size(51, 20);
            this.TeamoneScoreLabel.TabIndex = 7;
            this.TeamoneScoreLabel.Text = "Score";
            // 
            // teamOneScoreText
            // 
            this.teamOneScoreText.Location = new System.Drawing.Point(495, 207);
            this.teamOneScoreText.Name = "teamOneScoreText";
            this.teamOneScoreText.Size = new System.Drawing.Size(57, 20);
            this.teamOneScoreText.TabIndex = 8;
            this.teamOneScoreText.Text = "0";
            // 
            // teamtwoScoreText
            // 
            this.teamtwoScoreText.Location = new System.Drawing.Point(495, 302);
            this.teamtwoScoreText.Name = "teamtwoScoreText";
            this.teamtwoScoreText.Size = new System.Drawing.Size(57, 20);
            this.teamtwoScoreText.TabIndex = 11;
            this.teamtwoScoreText.Text = "0";
            // 
            // ScoreteamoneLabel
            // 
            this.ScoreteamoneLabel.AutoSize = true;
            this.ScoreteamoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreteamoneLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ScoreteamoneLabel.Location = new System.Drawing.Point(438, 302);
            this.ScoreteamoneLabel.Name = "ScoreteamoneLabel";
            this.ScoreteamoneLabel.Size = new System.Drawing.Size(51, 20);
            this.ScoreteamoneLabel.TabIndex = 10;
            this.ScoreteamoneLabel.Text = "Score";
            // 
            // teamtwoName
            // 
            this.teamtwoName.AutoSize = true;
            this.teamtwoName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamtwoName.ForeColor = System.Drawing.SystemColors.GrayText;
            this.teamtwoName.Location = new System.Drawing.Point(447, 269);
            this.teamtwoName.Name = "teamtwoName";
            this.teamtwoName.Size = new System.Drawing.Size(92, 20);
            this.teamtwoName.TabIndex = 9;
            this.teamtwoName.Text = "<team two>";
            // 
            // VsLabel
            // 
            this.VsLabel.AutoSize = true;
            this.VsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VsLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.VsLabel.Location = new System.Drawing.Point(458, 239);
            this.VsLabel.Name = "VsLabel";
            this.VsLabel.Size = new System.Drawing.Size(59, 20);
            this.VsLabel.TabIndex = 12;
            this.VsLabel.Text = "<-VS->";
            // 
            // ScoreButton
            // 
            this.ScoreButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ScoreButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.ScoreButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ScoreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ScoreButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreButton.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ScoreButton.Location = new System.Drawing.Point(616, 233);
            this.ScoreButton.Name = "ScoreButton";
            this.ScoreButton.Size = new System.Drawing.Size(85, 40);
            this.ScoreButton.TabIndex = 13;
            this.ScoreButton.Text = "Score";
            this.ScoreButton.UseVisualStyleBackColor = true;
            this.ScoreButton.Click += new System.EventHandler(this.ScoreButton_Click);
            // 
            // Tournamentv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(745, 415);
            this.Controls.Add(this.ScoreButton);
            this.Controls.Add(this.VsLabel);
            this.Controls.Add(this.teamtwoScoreText);
            this.Controls.Add(this.ScoreteamoneLabel);
            this.Controls.Add(this.teamtwoName);
            this.Controls.Add(this.teamOneScoreText);
            this.Controls.Add(this.TeamoneScoreLabel);
            this.Controls.Add(this.teamOneName);
            this.Controls.Add(this.matchupListBox);
            this.Controls.Add(this.Unplayedbox);
            this.Controls.Add(this.RoundDropdown);
            this.Controls.Add(this.Round);
            this.Controls.Add(this.TournamentName);
            this.Controls.Add(this.HeaderLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Tournamentv";
            this.Text = "Tournamentv";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HeaderLabel;
        private System.Windows.Forms.Label TournamentName;
        private System.Windows.Forms.Label Round;
        private System.Windows.Forms.ComboBox RoundDropdown;
        private System.Windows.Forms.CheckBox Unplayedbox;
        private System.Windows.Forms.ListBox matchupListBox;
        private System.Windows.Forms.Label teamOneName;
        private System.Windows.Forms.Label TeamoneScoreLabel;
        private System.Windows.Forms.TextBox teamOneScoreText;
        private System.Windows.Forms.TextBox teamtwoScoreText;
        private System.Windows.Forms.Label ScoreteamoneLabel;
        private System.Windows.Forms.Label teamtwoName;
        private System.Windows.Forms.Label VsLabel;
        private System.Windows.Forms.Button ScoreButton;
    }
}

