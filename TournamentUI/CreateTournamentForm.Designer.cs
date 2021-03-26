namespace TournamentUI
{
    partial class CreateTournamentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateTournamentForm));
            this.HeaderLabel = new System.Windows.Forms.Label();
            this.TournamentNameText = new System.Windows.Forms.TextBox();
            this.TeamoneScoreLabel = new System.Windows.Forms.Label();
            this.EnterFeeValue = new System.Windows.Forms.TextBox();
            this.EntryFeeLabel = new System.Windows.Forms.Label();
            this.SelectTeamDrop = new System.Windows.Forms.ComboBox();
            this.SelectTeamLabel = new System.Windows.Forms.Label();
            this.CreateNewTeamLabel = new System.Windows.Forms.LinkLabel();
            this.AddTeamButton = new System.Windows.Forms.Button();
            this.CreatePrize = new System.Windows.Forms.Button();
            this.TournamentPlayersListBox = new System.Windows.Forms.ListBox();
            this.PlayersTeams = new System.Windows.Forms.Label();
            this.DeleteSelectedTeams = new System.Windows.Forms.Button();
            this.DeletePrizes = new System.Windows.Forms.Button();
            this.PrizesLabel = new System.Windows.Forms.Label();
            this.PrizesBox = new System.Windows.Forms.ListBox();
            this.CreateTournamentButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HeaderLabel
            // 
            this.HeaderLabel.AutoSize = true;
            this.HeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.HeaderLabel.Location = new System.Drawing.Point(12, 21);
            this.HeaderLabel.Name = "HeaderLabel";
            this.HeaderLabel.Size = new System.Drawing.Size(351, 42);
            this.HeaderLabel.TabIndex = 1;
            this.HeaderLabel.Text = "Create Tournament:";
            // 
            // TournamentNameText
            // 
            this.TournamentNameText.Location = new System.Drawing.Point(200, 100);
            this.TournamentNameText.Name = "TournamentNameText";
            this.TournamentNameText.Size = new System.Drawing.Size(152, 20);
            this.TournamentNameText.TabIndex = 10;
          
            // 
            // TeamoneScoreLabel
            // 
            this.TeamoneScoreLabel.AutoSize = true;
            this.TeamoneScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TeamoneScoreLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.TeamoneScoreLabel.Location = new System.Drawing.Point(53, 98);
            this.TeamoneScoreLabel.Name = "TeamoneScoreLabel";
            this.TeamoneScoreLabel.Size = new System.Drawing.Size(141, 20);
            this.TeamoneScoreLabel.TabIndex = 9;
            this.TeamoneScoreLabel.Text = "Tournament Name";
            // 
            // EnterFeeValue
            // 
            this.EnterFeeValue.Location = new System.Drawing.Point(156, 138);
            this.EnterFeeValue.Name = "EnterFeeValue";
            this.EnterFeeValue.Size = new System.Drawing.Size(57, 20);
            this.EnterFeeValue.TabIndex = 12;
            this.EnterFeeValue.Text = "0";
            // 
            // EntryFeeLabel
            // 
            this.EntryFeeLabel.AutoSize = true;
            this.EntryFeeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EntryFeeLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.EntryFeeLabel.Location = new System.Drawing.Point(53, 136);
            this.EntryFeeLabel.Name = "EntryFeeLabel";
            this.EntryFeeLabel.Size = new System.Drawing.Size(97, 20);
            this.EntryFeeLabel.TabIndex = 11;
            this.EntryFeeLabel.Text = "Entry Fee :";
            // 
            // SelectTeamDrop
            // 
            this.SelectTeamDrop.FormattingEnabled = true;
            this.SelectTeamDrop.Location = new System.Drawing.Point(57, 198);
            this.SelectTeamDrop.Name = "SelectTeamDrop";
            this.SelectTeamDrop.Size = new System.Drawing.Size(234, 21);
            this.SelectTeamDrop.TabIndex = 14;
            // 
            // SelectTeamLabel
            // 
            this.SelectTeamLabel.AutoSize = true;
            this.SelectTeamLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectTeamLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.SelectTeamLabel.Location = new System.Drawing.Point(53, 175);
            this.SelectTeamLabel.Name = "SelectTeamLabel";
            this.SelectTeamLabel.Size = new System.Drawing.Size(94, 20);
            this.SelectTeamLabel.TabIndex = 13;
            this.SelectTeamLabel.Text = "SelectTeam";
            // 
            // CreateNewTeamLabel
            // 
            this.CreateNewTeamLabel.AutoSize = true;
            this.CreateNewTeamLabel.Location = new System.Drawing.Point(235, 175);
            this.CreateNewTeamLabel.Name = "CreateNewTeamLabel";
            this.CreateNewTeamLabel.Size = new System.Drawing.Size(65, 13);
            this.CreateNewTeamLabel.TabIndex = 15;
            this.CreateNewTeamLabel.TabStop = true;
            this.CreateNewTeamLabel.Text = "CreateTeam";
            this.CreateNewTeamLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CreateNewTeamLabel_LinkClicked);
            // 
            // AddTeamButton
            // 
            this.AddTeamButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.AddTeamButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.AddTeamButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.AddTeamButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddTeamButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddTeamButton.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.AddTeamButton.Location = new System.Drawing.Point(94, 247);
            this.AddTeamButton.Name = "AddTeamButton";
            this.AddTeamButton.Size = new System.Drawing.Size(152, 32);
            this.AddTeamButton.TabIndex = 16;
            this.AddTeamButton.Text = "AddTeam";
            this.AddTeamButton.UseVisualStyleBackColor = true;
            this.AddTeamButton.Click += new System.EventHandler(this.AddTeamButton_Click);
            // 
            // CreatePrize
            // 
            this.CreatePrize.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.CreatePrize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.CreatePrize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.CreatePrize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreatePrize.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreatePrize.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.CreatePrize.Location = new System.Drawing.Point(94, 314);
            this.CreatePrize.Name = "CreatePrize";
            this.CreatePrize.Size = new System.Drawing.Size(152, 32);
            this.CreatePrize.TabIndex = 18;
            this.CreatePrize.Text = "Create Prize";
            this.CreatePrize.UseVisualStyleBackColor = true;
            this.CreatePrize.Click += new System.EventHandler(this.CreatePrize_Click);
            // 
            // TournamentPlayersListBox
            // 
            this.TournamentPlayersListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TournamentPlayersListBox.FormattingEnabled = true;
            this.TournamentPlayersListBox.Location = new System.Drawing.Point(407, 136);
            this.TournamentPlayersListBox.Name = "TournamentPlayersListBox";
            this.TournamentPlayersListBox.Size = new System.Drawing.Size(237, 106);
            this.TournamentPlayersListBox.TabIndex = 19;
            // 
            // PlayersTeams
            // 
            this.PlayersTeams.AutoSize = true;
            this.PlayersTeams.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayersTeams.ForeColor = System.Drawing.SystemColors.GrayText;
            this.PlayersTeams.Location = new System.Drawing.Point(403, 97);
            this.PlayersTeams.Name = "PlayersTeams";
            this.PlayersTeams.Size = new System.Drawing.Size(112, 20);
            this.PlayersTeams.TabIndex = 20;
            this.PlayersTeams.Text = "Players/Teams";
            // 
            // DeleteSelectedTeams
            // 
            this.DeleteSelectedTeams.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.DeleteSelectedTeams.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.DeleteSelectedTeams.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.DeleteSelectedTeams.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteSelectedTeams.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteSelectedTeams.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.DeleteSelectedTeams.Location = new System.Drawing.Point(669, 167);
            this.DeleteSelectedTeams.Name = "DeleteSelectedTeams";
            this.DeleteSelectedTeams.Size = new System.Drawing.Size(85, 52);
            this.DeleteSelectedTeams.TabIndex = 21;
            this.DeleteSelectedTeams.Text = "Delete Team";
            this.DeleteSelectedTeams.UseVisualStyleBackColor = true;
            this.DeleteSelectedTeams.Click += new System.EventHandler(this.DeleteSelectedTeams_Click);
            // 
            // DeletePrizes
            // 
            this.DeletePrizes.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.DeletePrizes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.DeletePrizes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.DeletePrizes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeletePrizes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeletePrizes.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.DeletePrizes.Location = new System.Drawing.Point(669, 314);
            this.DeletePrizes.Name = "DeletePrizes";
            this.DeletePrizes.Size = new System.Drawing.Size(85, 50);
            this.DeletePrizes.TabIndex = 24;
            this.DeletePrizes.Text = "Delete Prize";
            this.DeletePrizes.UseVisualStyleBackColor = true;
            this.DeletePrizes.Click += new System.EventHandler(this.DeletePrizes_Click);
            // 
            // PrizesLabel
            // 
            this.PrizesLabel.AutoSize = true;
            this.PrizesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrizesLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.PrizesLabel.Location = new System.Drawing.Point(403, 247);
            this.PrizesLabel.Name = "PrizesLabel";
            this.PrizesLabel.Size = new System.Drawing.Size(52, 20);
            this.PrizesLabel.TabIndex = 23;
            this.PrizesLabel.Text = "Prizes";
            // 
            // PrizesBox
            // 
            this.PrizesBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PrizesBox.FormattingEnabled = true;
            this.PrizesBox.Location = new System.Drawing.Point(407, 286);
            this.PrizesBox.Name = "PrizesBox";
            this.PrizesBox.Size = new System.Drawing.Size(237, 106);
            this.PrizesBox.TabIndex = 22;
            // 
            // CreateTournamentButton
            // 
            this.CreateTournamentButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.CreateTournamentButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.CreateTournamentButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.CreateTournamentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateTournamentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateTournamentButton.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.CreateTournamentButton.Location = new System.Drawing.Point(255, 411);
            this.CreateTournamentButton.Name = "CreateTournamentButton";
            this.CreateTournamentButton.Size = new System.Drawing.Size(239, 32);
            this.CreateTournamentButton.TabIndex = 25;
            this.CreateTournamentButton.Text = "Create Tournament";
            this.CreateTournamentButton.UseVisualStyleBackColor = true;
            this.CreateTournamentButton.Click += new System.EventHandler(this.CreateTournamentButton_Click);
            // 
            // CreateTournamentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(776, 470);
            this.Controls.Add(this.CreateTournamentButton);
            this.Controls.Add(this.DeletePrizes);
            this.Controls.Add(this.PrizesLabel);
            this.Controls.Add(this.PrizesBox);
            this.Controls.Add(this.DeleteSelectedTeams);
            this.Controls.Add(this.PlayersTeams);
            this.Controls.Add(this.TournamentPlayersListBox);
            this.Controls.Add(this.CreatePrize);
            this.Controls.Add(this.AddTeamButton);
            this.Controls.Add(this.CreateNewTeamLabel);
            this.Controls.Add(this.SelectTeamDrop);
            this.Controls.Add(this.SelectTeamLabel);
            this.Controls.Add(this.EnterFeeValue);
            this.Controls.Add(this.EntryFeeLabel);
            this.Controls.Add(this.TournamentNameText);
            this.Controls.Add(this.TeamoneScoreLabel);
            this.Controls.Add(this.HeaderLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateTournamentForm";
            this.Text = "CreateTournament";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HeaderLabel;
        private System.Windows.Forms.TextBox TournamentNameText;
        private System.Windows.Forms.Label TeamoneScoreLabel;
        private System.Windows.Forms.TextBox EnterFeeValue;
        private System.Windows.Forms.Label EntryFeeLabel;
        private System.Windows.Forms.ComboBox SelectTeamDrop;
        private System.Windows.Forms.Label SelectTeamLabel;
        private System.Windows.Forms.LinkLabel CreateNewTeamLabel;
        private System.Windows.Forms.Button AddTeamButton;
        private System.Windows.Forms.Button CreatePrize;
        private System.Windows.Forms.ListBox TournamentPlayersListBox;
        private System.Windows.Forms.Label PlayersTeams;
        private System.Windows.Forms.Button DeleteSelectedTeams;
        private System.Windows.Forms.Button DeletePrizes;
        private System.Windows.Forms.Label PrizesLabel;
        private System.Windows.Forms.ListBox PrizesBox;
        private System.Windows.Forms.Button CreateTournamentButton;
    }
}