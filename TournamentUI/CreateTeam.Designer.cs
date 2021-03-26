namespace TournamentUI
{
    partial class CreateTeam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateTeam));
            this.CreateTeamNameValue = new System.Windows.Forms.TextBox();
            this.CreateTeamLabel = new System.Windows.Forms.Label();
            this.HeaderLabel = new System.Windows.Forms.Label();
            this.SelectTeamMemberLabel = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SelectTeamMembersDrop = new System.Windows.Forms.ComboBox();
            this.AddMemberButton = new System.Windows.Forms.Button();
            this.AddNewMemberBox = new System.Windows.Forms.GroupBox();
            this.CreatePlayerButton = new System.Windows.Forms.Button();
            this.CellPhoneValue = new System.Windows.Forms.TextBox();
            this.CellPhoneLabel = new System.Windows.Forms.Label();
            this.EmailValue = new System.Windows.Forms.TextBox();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.SurnameValue = new System.Windows.Forms.TextBox();
            this.LastNameLabel = new System.Windows.Forms.Label();
            this.FirstNameValue = new System.Windows.Forms.TextBox();
            this.FirstNameLabel = new System.Windows.Forms.Label();
            this.TeamMembersListBox = new System.Windows.Forms.ListBox();
            this.RemoveSelectedMember = new System.Windows.Forms.Button();
            this.CreateTeamButton = new System.Windows.Forms.Button();
            this.AddNewMemberBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // CreateTeamNameValue
            // 
            this.CreateTeamNameValue.Location = new System.Drawing.Point(135, 76);
            this.CreateTeamNameValue.Name = "CreateTeamNameValue";
            this.CreateTeamNameValue.Size = new System.Drawing.Size(152, 20);
            this.CreateTeamNameValue.TabIndex = 13;
            // 
            // CreateTeamLabel
            // 
            this.CreateTeamLabel.AutoSize = true;
            this.CreateTeamLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateTeamLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.CreateTeamLabel.Location = new System.Drawing.Point(34, 76);
            this.CreateTeamLabel.Name = "CreateTeamLabel";
            this.CreateTeamLabel.Size = new System.Drawing.Size(95, 20);
            this.CreateTeamLabel.TabIndex = 12;
            this.CreateTeamLabel.Text = "Team Name";
            // 
            // HeaderLabel
            // 
            this.HeaderLabel.AutoSize = true;
            this.HeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.HeaderLabel.Location = new System.Drawing.Point(31, 9);
            this.HeaderLabel.Name = "HeaderLabel";
            this.HeaderLabel.Size = new System.Drawing.Size(245, 42);
            this.HeaderLabel.TabIndex = 11;
            this.HeaderLabel.Text = "Create Team:";
            // 
            // SelectTeamMemberLabel
            // 
            this.SelectTeamMemberLabel.AutoSize = true;
            this.SelectTeamMemberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectTeamMemberLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.SelectTeamMemberLabel.Location = new System.Drawing.Point(34, 124);
            this.SelectTeamMemberLabel.Name = "SelectTeamMemberLabel";
            this.SelectTeamMemberLabel.Size = new System.Drawing.Size(206, 24);
            this.SelectTeamMemberLabel.TabIndex = 14;
            this.SelectTeamMemberLabel.Text = "Select Team Members:";
            // 
            // SelectTeamMembersDrop
            // 
            this.SelectTeamMembersDrop.FormattingEnabled = true;
            this.SelectTeamMembersDrop.Location = new System.Drawing.Point(38, 165);
            this.SelectTeamMembersDrop.Name = "SelectTeamMembersDrop";
            this.SelectTeamMembersDrop.Size = new System.Drawing.Size(203, 21);
            this.SelectTeamMembersDrop.TabIndex = 15;
            // 
            // AddMemberButton
            // 
            this.AddMemberButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.AddMemberButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.AddMemberButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.AddMemberButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddMemberButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddMemberButton.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.AddMemberButton.Location = new System.Drawing.Point(68, 201);
            this.AddMemberButton.Name = "AddMemberButton";
            this.AddMemberButton.Size = new System.Drawing.Size(152, 32);
            this.AddMemberButton.TabIndex = 17;
            this.AddMemberButton.Text = "Add Player";
            this.AddMemberButton.UseVisualStyleBackColor = true;
            this.AddMemberButton.Click += new System.EventHandler(this.AddMemberButton_Click);
            // 
            // AddNewMemberBox
            // 
            this.AddNewMemberBox.Controls.Add(this.CreatePlayerButton);
            this.AddNewMemberBox.Controls.Add(this.CellPhoneValue);
            this.AddNewMemberBox.Controls.Add(this.CellPhoneLabel);
            this.AddNewMemberBox.Controls.Add(this.EmailValue);
            this.AddNewMemberBox.Controls.Add(this.EmailLabel);
            this.AddNewMemberBox.Controls.Add(this.SurnameValue);
            this.AddNewMemberBox.Controls.Add(this.LastNameLabel);
            this.AddNewMemberBox.Controls.Add(this.FirstNameValue);
            this.AddNewMemberBox.Controls.Add(this.FirstNameLabel);
            this.AddNewMemberBox.Location = new System.Drawing.Point(38, 250);
            this.AddNewMemberBox.Name = "AddNewMemberBox";
            this.AddNewMemberBox.Size = new System.Drawing.Size(249, 229);
            this.AddNewMemberBox.TabIndex = 18;
            this.AddNewMemberBox.TabStop = false;
            this.AddNewMemberBox.Text = "AddNewMember";
            this.AddNewMemberBox.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // CreatePlayerButton
            // 
            this.CreatePlayerButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.CreatePlayerButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.CreatePlayerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.CreatePlayerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreatePlayerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreatePlayerButton.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.CreatePlayerButton.Location = new System.Drawing.Point(50, 182);
            this.CreatePlayerButton.Name = "CreatePlayerButton";
            this.CreatePlayerButton.Size = new System.Drawing.Size(152, 32);
            this.CreatePlayerButton.TabIndex = 18;
            this.CreatePlayerButton.Text = "Create Player";
            this.CreatePlayerButton.UseVisualStyleBackColor = true;
            this.CreatePlayerButton.Click += new System.EventHandler(this.CreatePlayerButton_Click);
            // 
            // CellPhoneValue
            // 
            this.CellPhoneValue.Location = new System.Drawing.Point(93, 145);
            this.CellPhoneValue.Name = "CellPhoneValue";
            this.CellPhoneValue.Size = new System.Drawing.Size(119, 20);
            this.CellPhoneValue.TabIndex = 16;
            // 
            // CellPhoneLabel
            // 
            this.CellPhoneLabel.AutoSize = true;
            this.CellPhoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CellPhoneLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.CellPhoneLabel.Location = new System.Drawing.Point(6, 145);
            this.CellPhoneLabel.Name = "CellPhoneLabel";
            this.CellPhoneLabel.Size = new System.Drawing.Size(81, 20);
            this.CellPhoneLabel.TabIndex = 15;
            this.CellPhoneLabel.Text = "CellPhone";
            // 
            // EmailValue
            // 
            this.EmailValue.Location = new System.Drawing.Point(93, 110);
            this.EmailValue.Name = "EmailValue";
            this.EmailValue.Size = new System.Drawing.Size(119, 20);
            this.EmailValue.TabIndex = 14;
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.EmailLabel.Location = new System.Drawing.Point(6, 108);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(48, 20);
            this.EmailLabel.TabIndex = 13;
            this.EmailLabel.Text = "Email";
            // 
            // SurnameValue
            // 
            this.SurnameValue.Location = new System.Drawing.Point(93, 72);
            this.SurnameValue.Name = "SurnameValue";
            this.SurnameValue.Size = new System.Drawing.Size(119, 20);
            this.SurnameValue.TabIndex = 12;
            // 
            // LastNameLabel
            // 
            this.LastNameLabel.AutoSize = true;
            this.LastNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastNameLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.LastNameLabel.Location = new System.Drawing.Point(6, 70);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(74, 20);
            this.LastNameLabel.TabIndex = 11;
            this.LastNameLabel.Text = "Surname";
            // 
            // FirstNameValue
            // 
            this.FirstNameValue.Location = new System.Drawing.Point(93, 34);
            this.FirstNameValue.Name = "FirstNameValue";
            this.FirstNameValue.Size = new System.Drawing.Size(119, 20);
            this.FirstNameValue.TabIndex = 10;
            // 
            // FirstNameLabel
            // 
            this.FirstNameLabel.AutoSize = true;
            this.FirstNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstNameLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.FirstNameLabel.Location = new System.Drawing.Point(6, 32);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(51, 20);
            this.FirstNameLabel.TabIndex = 9;
            this.FirstNameLabel.Text = "Name";
            // 
            // TeamMembersListBox
            // 
            this.TeamMembersListBox.FormattingEnabled = true;
            this.TeamMembersListBox.Location = new System.Drawing.Point(342, 76);
            this.TeamMembersListBox.Name = "TeamMembersListBox";
            this.TeamMembersListBox.Size = new System.Drawing.Size(272, 342);
            this.TeamMembersListBox.TabIndex = 19;
            // 
            // RemoveSelectedMember
            // 
            this.RemoveSelectedMember.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.RemoveSelectedMember.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.RemoveSelectedMember.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.RemoveSelectedMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveSelectedMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveSelectedMember.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.RemoveSelectedMember.Location = new System.Drawing.Point(406, 432);
            this.RemoveSelectedMember.Name = "RemoveSelectedMember";
            this.RemoveSelectedMember.Size = new System.Drawing.Size(152, 32);
            this.RemoveSelectedMember.TabIndex = 20;
            this.RemoveSelectedMember.Text = "Remove Player";
            this.RemoveSelectedMember.UseVisualStyleBackColor = true;
            this.RemoveSelectedMember.Click += new System.EventHandler(this.RemoveSelectedMember_Click);
            // 
            // CreateTeamButton
            // 
            this.CreateTeamButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.CreateTeamButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.CreateTeamButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.CreateTeamButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateTeamButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateTeamButton.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.CreateTeamButton.Location = new System.Drawing.Point(200, 485);
            this.CreateTeamButton.Name = "CreateTeamButton";
            this.CreateTeamButton.Size = new System.Drawing.Size(239, 32);
            this.CreateTeamButton.TabIndex = 26;
            this.CreateTeamButton.Text = "Create Team";
            this.CreateTeamButton.UseVisualStyleBackColor = true;
            this.CreateTeamButton.Click += new System.EventHandler(this.CreateTeamButton_Click);
            // 
            // CreateTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(675, 542);
            this.Controls.Add(this.CreateTeamButton);
            this.Controls.Add(this.RemoveSelectedMember);
            this.Controls.Add(this.TeamMembersListBox);
            this.Controls.Add(this.AddNewMemberBox);
            this.Controls.Add(this.AddMemberButton);
            this.Controls.Add(this.SelectTeamMembersDrop);
            this.Controls.Add(this.SelectTeamMemberLabel);
            this.Controls.Add(this.CreateTeamNameValue);
            this.Controls.Add(this.CreateTeamLabel);
            this.Controls.Add(this.HeaderLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateTeam";
            this.Text = "CreateTeam";
            this.AddNewMemberBox.ResumeLayout(false);
            this.AddNewMemberBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CreateTeamNameValue;
        private System.Windows.Forms.Label CreateTeamLabel;
        private System.Windows.Forms.Label HeaderLabel;
        private System.Windows.Forms.Label SelectTeamMemberLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox SelectTeamMembersDrop;
        private System.Windows.Forms.Button AddMemberButton;
        private System.Windows.Forms.GroupBox AddNewMemberBox;
        private System.Windows.Forms.Button CreatePlayerButton;
        private System.Windows.Forms.TextBox CellPhoneValue;
        private System.Windows.Forms.Label CellPhoneLabel;
        private System.Windows.Forms.TextBox EmailValue;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.TextBox SurnameValue;
        private System.Windows.Forms.Label LastNameLabel;
        private System.Windows.Forms.TextBox FirstNameValue;
        private System.Windows.Forms.Label FirstNameLabel;
        private System.Windows.Forms.ListBox TeamMembersListBox;
        private System.Windows.Forms.Button RemoveSelectedMember;
        private System.Windows.Forms.Button CreateTeamButton;
    }
}