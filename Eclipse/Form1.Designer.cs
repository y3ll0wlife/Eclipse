namespace Eclipse
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.CheatTabs = new MetroFramework.Controls.MetroTabControl();
            this.miscTab = new MetroFramework.Controls.MetroTabPage();
            this.antiFlashScroll = new MetroFramework.Controls.MetroTrackBar();
            this.thirdPersonCheck = new MetroFramework.Controls.MetroCheckBox();
            this.bunnyCheck = new MetroFramework.Controls.MetroCheckBox();
            this.skinChangerCheck = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.delayAntiFlash = new MetroFramework.Controls.MetroTrackBar();
            this.antiFlashCheck = new MetroFramework.Controls.MetroCheckBox();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.applySkinUpdate = new MetroFramework.Controls.MetroButton();
            this.skinID = new MetroFramework.Controls.MetroTextBox();
            this.weaponName = new MetroFramework.Controls.MetroComboBox();
            this.aimTab = new MetroFramework.Controls.MetroTabPage();
            this.hasToBeScopedCheck = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.tiggerbotDelay = new MetroFramework.Controls.MetroTrackBar();
            this.triggerbotCheck = new MetroFramework.Controls.MetroCheckBox();
            this.visualTab = new MetroFramework.Controls.MetroTabPage();
            this.glowCheck = new MetroFramework.Controls.MetroCheckBox();
            this.healthBasedGlowCheck = new MetroFramework.Controls.MetroCheckBox();
            this.onlyEnemyGlow = new MetroFramework.Controls.MetroCheckBox();
            this.radarCheck = new MetroFramework.Controls.MetroCheckBox();
            this.CheatTabs.SuspendLayout();
            this.miscTab.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.aimTab.SuspendLayout();
            this.visualTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // CheatTabs
            // 
            this.CheatTabs.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.CheatTabs.Controls.Add(this.miscTab);
            this.CheatTabs.Controls.Add(this.metroTabPage1);
            this.CheatTabs.Controls.Add(this.aimTab);
            this.CheatTabs.Controls.Add(this.visualTab);
            this.CheatTabs.Location = new System.Drawing.Point(10, 52);
            this.CheatTabs.Name = "CheatTabs";
            this.CheatTabs.RightToLeftLayout = true;
            this.CheatTabs.SelectedIndex = 3;
            this.CheatTabs.Size = new System.Drawing.Size(797, 394);
            this.CheatTabs.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.CheatTabs.TabIndex = 0;
            this.CheatTabs.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // miscTab
            // 
            this.miscTab.Controls.Add(this.antiFlashScroll);
            this.miscTab.Controls.Add(this.thirdPersonCheck);
            this.miscTab.Controls.Add(this.bunnyCheck);
            this.miscTab.Controls.Add(this.skinChangerCheck);
            this.miscTab.Controls.Add(this.metroLabel7);
            this.miscTab.Controls.Add(this.metroLabel2);
            this.miscTab.Controls.Add(this.delayAntiFlash);
            this.miscTab.Controls.Add(this.antiFlashCheck);
            this.miscTab.HorizontalScrollbarBarColor = true;
            this.miscTab.Location = new System.Drawing.Point(4, 38);
            this.miscTab.Name = "miscTab";
            this.miscTab.Size = new System.Drawing.Size(789, 352);
            this.miscTab.TabIndex = 0;
            this.miscTab.Text = "Misc";
            this.miscTab.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.miscTab.VerticalScrollbarBarColor = true;
            // 
            // antiFlashScroll
            // 
            this.antiFlashScroll.BackColor = System.Drawing.Color.Transparent;
            this.antiFlashScroll.Location = new System.Drawing.Point(487, 17);
            this.antiFlashScroll.Maximum = 1000;
            this.antiFlashScroll.Name = "antiFlashScroll";
            this.antiFlashScroll.Size = new System.Drawing.Size(222, 23);
            this.antiFlashScroll.TabIndex = 18;
            this.antiFlashScroll.Text = "metroTrackBar1";
            this.antiFlashScroll.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.antiFlashScroll.Value = 0;
            this.antiFlashScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.antiFlashScroll_Scroll_1);
            // 
            // thirdPersonCheck
            // 
            this.thirdPersonCheck.AutoSize = true;
            this.thirdPersonCheck.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.thirdPersonCheck.Location = new System.Drawing.Point(120, 48);
            this.thirdPersonCheck.Name = "thirdPersonCheck";
            this.thirdPersonCheck.Size = new System.Drawing.Size(123, 25);
            this.thirdPersonCheck.TabIndex = 17;
            this.thirdPersonCheck.Text = "Thirdperson";
            this.thirdPersonCheck.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.thirdPersonCheck.UseVisualStyleBackColor = true;
            this.thirdPersonCheck.CheckedChanged += new System.EventHandler(this.thirdPersonCheck_CheckedChanged);
            // 
            // bunnyCheck
            // 
            this.bunnyCheck.AutoSize = true;
            this.bunnyCheck.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.bunnyCheck.Location = new System.Drawing.Point(9, 48);
            this.bunnyCheck.Name = "bunnyCheck";
            this.bunnyCheck.Size = new System.Drawing.Size(109, 25);
            this.bunnyCheck.TabIndex = 16;
            this.bunnyCheck.Text = "Bunnyhop";
            this.bunnyCheck.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.bunnyCheck.UseVisualStyleBackColor = true;
            this.bunnyCheck.CheckedChanged += new System.EventHandler(this.bunnyCheck_CheckedChanged);
            // 
            // skinChangerCheck
            // 
            this.skinChangerCheck.AutoSize = true;
            this.skinChangerCheck.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.skinChangerCheck.Location = new System.Drawing.Point(120, 17);
            this.skinChangerCheck.Name = "skinChangerCheck";
            this.skinChangerCheck.Size = new System.Drawing.Size(132, 25);
            this.skinChangerCheck.TabIndex = 15;
            this.skinChangerCheck.Text = "Skin Changer";
            this.skinChangerCheck.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.skinChangerCheck.UseVisualStyleBackColor = true;
            this.skinChangerCheck.CheckedChanged += new System.EventHandler(this.skinChangerCheck_CheckedChanged);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(715, 13);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(36, 19);
            this.metroLabel7.TabIndex = 12;
            this.metroLabel7.Text = "x ms";
            this.metroLabel7.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(380, 17);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(101, 19);
            this.metroLabel2.TabIndex = 9;
            this.metroLabel2.Text = "Delay Anti Flash";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // delayAntiFlash
            // 
            this.delayAntiFlash.BackColor = System.Drawing.Color.Transparent;
            this.delayAntiFlash.Location = new System.Drawing.Point(0, 0);
            this.delayAntiFlash.Name = "delayAntiFlash";
            this.delayAntiFlash.Size = new System.Drawing.Size(0, 0);
            this.delayAntiFlash.TabIndex = 14;
            // 
            // antiFlashCheck
            // 
            this.antiFlashCheck.AutoSize = true;
            this.antiFlashCheck.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.antiFlashCheck.Location = new System.Drawing.Point(9, 17);
            this.antiFlashCheck.Name = "antiFlashCheck";
            this.antiFlashCheck.Size = new System.Drawing.Size(105, 25);
            this.antiFlashCheck.TabIndex = 2;
            this.antiFlashCheck.Text = "Anti Flash";
            this.antiFlashCheck.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.antiFlashCheck.UseVisualStyleBackColor = true;
            this.antiFlashCheck.CheckedChanged += new System.EventHandler(this.antiFlashCheck_CheckedChanged);
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.applySkinUpdate);
            this.metroTabPage1.Controls.Add(this.skinID);
            this.metroTabPage1.Controls.Add(this.weaponName);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(789, 352);
            this.metroTabPage1.TabIndex = 4;
            this.metroTabPage1.Text = "Skin Changer";
            this.metroTabPage1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            // 
            // applySkinUpdate
            // 
            this.applySkinUpdate.Location = new System.Drawing.Point(355, 20);
            this.applySkinUpdate.Name = "applySkinUpdate";
            this.applySkinUpdate.Size = new System.Drawing.Size(89, 29);
            this.applySkinUpdate.TabIndex = 4;
            this.applySkinUpdate.Text = "Apply";
            this.applySkinUpdate.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.applySkinUpdate.Click += new System.EventHandler(this.applySkinUpdate_Click);
            // 
            // skinID
            // 
            this.skinID.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.skinID.Location = new System.Drawing.Point(182, 20);
            this.skinID.Name = "skinID";
            this.skinID.Size = new System.Drawing.Size(167, 29);
            this.skinID.TabIndex = 3;
            this.skinID.Text = "SKIN ID";
            this.skinID.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // weaponName
            // 
            this.weaponName.FormattingEnabled = true;
            this.weaponName.ItemHeight = 23;
            this.weaponName.Items.AddRange(new object[] {
            "P2000",
            "USP-S",
            "Glock-18",
            "P250",
            "Five-SeveN",
            "Tec-9",
            "CZ75-Auto",
            "Dual Berettas",
            "Desert Eagle",
            "R8 Revolver",
            "MP9",
            "MAC-10",
            "PP-Bizon",
            "MP7",
            "UMP-45",
            "P90",
            "MP5-SD",
            "FAMAS",
            "Galil AR",
            "M4A4",
            "M4A1-S",
            "AK-47",
            "AUG",
            "SG 553",
            "SSG 08",
            "AWP",
            "SSCAR-20",
            "G3SG1",
            "Nova",
            "XM1014",
            "MAG-7",
            "Sawed-Off",
            "M249",
            "Negev"});
            this.weaponName.Location = new System.Drawing.Point(9, 20);
            this.weaponName.Name = "weaponName";
            this.weaponName.Size = new System.Drawing.Size(167, 29);
            this.weaponName.TabIndex = 2;
            this.weaponName.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // aimTab
            // 
            this.aimTab.Controls.Add(this.hasToBeScopedCheck);
            this.aimTab.Controls.Add(this.metroLabel1);
            this.aimTab.Controls.Add(this.metroLabel5);
            this.aimTab.Controls.Add(this.tiggerbotDelay);
            this.aimTab.Controls.Add(this.triggerbotCheck);
            this.aimTab.HorizontalScrollbarBarColor = true;
            this.aimTab.Location = new System.Drawing.Point(4, 38);
            this.aimTab.Name = "aimTab";
            this.aimTab.Size = new System.Drawing.Size(789, 352);
            this.aimTab.TabIndex = 1;
            this.aimTab.Text = "Aim";
            this.aimTab.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.aimTab.VerticalScrollbarBarColor = true;
            // 
            // hasToBeScopedCheck
            // 
            this.hasToBeScopedCheck.AutoSize = true;
            this.hasToBeScopedCheck.Checked = true;
            this.hasToBeScopedCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hasToBeScopedCheck.Location = new System.Drawing.Point(377, 46);
            this.hasToBeScopedCheck.Name = "hasToBeScopedCheck";
            this.hasToBeScopedCheck.Size = new System.Drawing.Size(197, 15);
            this.hasToBeScopedCheck.TabIndex = 10;
            this.hasToBeScopedCheck.Text = "Triggerbot, snipers need to scope";
            this.hasToBeScopedCheck.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.hasToBeScopedCheck.UseVisualStyleBackColor = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(377, 17);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(106, 19);
            this.metroLabel1.TabIndex = 6;
            this.metroLabel1.Text = "Delay Triggerbot";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(717, 17);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(36, 19);
            this.metroLabel5.TabIndex = 5;
            this.metroLabel5.Text = "x ms";
            this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // tiggerbotDelay
            // 
            this.tiggerbotDelay.BackColor = System.Drawing.Color.Transparent;
            this.tiggerbotDelay.Location = new System.Drawing.Point(489, 17);
            this.tiggerbotDelay.Maximum = 1000;
            this.tiggerbotDelay.Name = "tiggerbotDelay";
            this.tiggerbotDelay.Size = new System.Drawing.Size(222, 23);
            this.tiggerbotDelay.TabIndex = 4;
            this.tiggerbotDelay.Text = "metroTrackBar1";
            this.tiggerbotDelay.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tiggerbotDelay.Value = 0;
            this.tiggerbotDelay.Scroll += new System.Windows.Forms.ScrollEventHandler(this.tiggerbotDelay_Scroll);
            // 
            // triggerbotCheck
            // 
            this.triggerbotCheck.AutoSize = true;
            this.triggerbotCheck.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.triggerbotCheck.Location = new System.Drawing.Point(9, 17);
            this.triggerbotCheck.Name = "triggerbotCheck";
            this.triggerbotCheck.Size = new System.Drawing.Size(110, 25);
            this.triggerbotCheck.TabIndex = 3;
            this.triggerbotCheck.Text = "Triggerbot";
            this.triggerbotCheck.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.triggerbotCheck.UseVisualStyleBackColor = true;
            this.triggerbotCheck.CheckedChanged += new System.EventHandler(this.triggerbotCheck_CheckedChanged);
            // 
            // visualTab
            // 
            this.visualTab.Controls.Add(this.radarCheck);
            this.visualTab.Controls.Add(this.glowCheck);
            this.visualTab.Controls.Add(this.healthBasedGlowCheck);
            this.visualTab.Controls.Add(this.onlyEnemyGlow);
            this.visualTab.HorizontalScrollbarBarColor = true;
            this.visualTab.Location = new System.Drawing.Point(4, 38);
            this.visualTab.Name = "visualTab";
            this.visualTab.Size = new System.Drawing.Size(789, 352);
            this.visualTab.TabIndex = 2;
            this.visualTab.Text = "Visual";
            this.visualTab.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.visualTab.VerticalScrollbarBarColor = true;
            // 
            // glowCheck
            // 
            this.glowCheck.AutoSize = true;
            this.glowCheck.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.glowCheck.Location = new System.Drawing.Point(3, 17);
            this.glowCheck.Name = "glowCheck";
            this.glowCheck.Size = new System.Drawing.Size(68, 25);
            this.glowCheck.TabIndex = 7;
            this.glowCheck.Text = "Glow";
            this.glowCheck.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.glowCheck.UseVisualStyleBackColor = true;
            this.glowCheck.CheckedChanged += new System.EventHandler(this.glowCheck_CheckedChanged);
            // 
            // healthBasedGlowCheck
            // 
            this.healthBasedGlowCheck.AutoSize = true;
            this.healthBasedGlowCheck.Location = new System.Drawing.Point(565, 17);
            this.healthBasedGlowCheck.Name = "healthBasedGlowCheck";
            this.healthBasedGlowCheck.Size = new System.Drawing.Size(151, 15);
            this.healthBasedGlowCheck.TabIndex = 9;
            this.healthBasedGlowCheck.Text = "Health based glow color";
            this.healthBasedGlowCheck.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.healthBasedGlowCheck.UseVisualStyleBackColor = true;
            // 
            // onlyEnemyGlow
            // 
            this.onlyEnemyGlow.AutoSize = true;
            this.onlyEnemyGlow.Location = new System.Drawing.Point(565, 48);
            this.onlyEnemyGlow.Name = "onlyEnemyGlow";
            this.onlyEnemyGlow.Size = new System.Drawing.Size(116, 15);
            this.onlyEnemyGlow.TabIndex = 8;
            this.onlyEnemyGlow.Text = "Only enemy glow";
            this.onlyEnemyGlow.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.onlyEnemyGlow.UseVisualStyleBackColor = true;
            // 
            // radarCheck
            // 
            this.radarCheck.AutoSize = true;
            this.radarCheck.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.radarCheck.Location = new System.Drawing.Point(3, 48);
            this.radarCheck.Name = "radarCheck";
            this.radarCheck.Size = new System.Drawing.Size(74, 25);
            this.radarCheck.TabIndex = 10;
            this.radarCheck.Text = "Radar";
            this.radarCheck.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.radarCheck.UseVisualStyleBackColor = true;
            this.radarCheck.CheckedChanged += new System.EventHandler(this.radarCheck_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CheatTabs);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Eclipse";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.CheatTabs.ResumeLayout(false);
            this.miscTab.ResumeLayout(false);
            this.miscTab.PerformLayout();
            this.metroTabPage1.ResumeLayout(false);
            this.aimTab.ResumeLayout(false);
            this.aimTab.PerformLayout();
            this.visualTab.ResumeLayout(false);
            this.visualTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl CheatTabs;
        private MetroFramework.Controls.MetroTabPage miscTab;
        private MetroFramework.Controls.MetroTabPage aimTab;
        private MetroFramework.Controls.MetroTabPage visualTab;
        private MetroFramework.Controls.MetroCheckBox antiFlashCheck;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTrackBar delayAntiFlash;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTrackBar tiggerbotDelay;
        private MetroFramework.Controls.MetroCheckBox glowCheck;
        private MetroFramework.Controls.MetroCheckBox healthBasedGlowCheck;
        private MetroFramework.Controls.MetroCheckBox onlyEnemyGlow;
        private MetroFramework.Controls.MetroCheckBox triggerbotCheck;
        private MetroFramework.Controls.MetroComboBox weaponName;
        private MetroFramework.Controls.MetroButton applySkinUpdate;
        private MetroFramework.Controls.MetroTextBox skinID;
        private MetroFramework.Controls.MetroCheckBox hasToBeScopedCheck;
        private MetroFramework.Controls.MetroCheckBox thirdPersonCheck;
        private MetroFramework.Controls.MetroCheckBox bunnyCheck;
        private MetroFramework.Controls.MetroCheckBox skinChangerCheck;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroTrackBar antiFlashScroll;
        private MetroFramework.Controls.MetroCheckBox radarCheck;
    }
}

