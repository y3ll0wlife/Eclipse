﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using MetroFramework.Forms;


namespace Eclipse
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
            
            this.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
            this.Style = MetroFramework.MetroColorStyle.Purple;
            FixColors();
            startGame();

        }

        // Importing and setting default variables
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(int vKey);

        public static int oEntityLoopDistance = 0x00000010; //

        public static string ProcessName = "csgo";
        public static int BClient;
        public static int EngineBase;


        private int fJump;
        private int aLocalPlayer;
        private int LocalPlayer;

        private int fAttack;
        private int aFlags;

        private int glowObject;
        private int myTeam;

        // Memory
        VAMemory vam = new VAMemory(ProcessName);

        // When program is launched
        private void startGame()
        {
            if (GetModule())
            {

                fJump = BClient + Offsets.dwForceJump;
                aLocalPlayer = BClient + Offsets.dwLocalPlayer;
                LocalPlayer = vam.ReadInt32((IntPtr)aLocalPlayer);

                fAttack = BClient + Offsets.dwForceAttack;
                aFlags = LocalPlayer + Offsets.m_fFlags;

                glowObject = vam.ReadInt32((IntPtr)BClient + Offsets.dwGlowObjectManager);
                myTeam = vam.ReadInt32((IntPtr)LocalPlayer + Offsets.m_iTeamNum);

                aLocalPlayer = BClient + aLocalPlayer;


                Thread BG = new Thread(BackgroundRunner);
                BG.Start();

            }
        }
        static bool GetModule()
        {
            try
            {
                Process[] p = Process.GetProcessesByName(ProcessName);
                if (p.Length > 0)
                {
                    foreach (ProcessModule m in p[0].Modules) if (m.ModuleName == "client_panorama.dll") BClient = (int)m.BaseAddress;
                    foreach (ProcessModule m in p[0].Modules)
                        if (m.ModuleName == "engine.dll")
                        {
                            EngineBase = (int)m.BaseAddress;
                            return true;
                        }
                    return false;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }
        private void FixColors()
        {
            var color = MetroFramework.MetroColorStyle.Purple;
            CheatTabs.Style = color;
            // Misc
            antiFlashCheck.Style = color;
            skinChangerCheck.Style = color;
            bunnyCheck.Style = color;
            thirdPersonCheck.Style = color;
            // Aim
            triggerbotCheck.Style = color;
            hasToBeScopedCheck.Style = color;
            shootTeamCheck.Style = color;
            // Visuals
            glowCheck.Style = color;
            onlyEnemyGlow.Style = color;
            healthBasedGlowCheck.Style = color;
            radarCheck.Style = color;
            fovCheck.Style = color;
            chamsCheck.Style = color;

            // Restore last run
            // Scrolls
            antiFlashScroll.Value = Properties.Settings.Default.DelayAntiFlash;
            metroLabel7.Text = antiFlashScroll.Value + " ms";

            tiggerbotDelay.Value = Properties.Settings.Default.DelayTriggerBot;
            metroLabel5.Text = tiggerbotDelay.Value + " ms";

            fovSlider.Value = Properties.Settings.Default.FovSlider;
            metroLabel3.Text = fovSlider.Value.ToString();

            redEnemyCharmSlider.Value = Properties.Settings.Default.ChamEnemyRed;
            greenEnemyCharmSlider.Value = Properties.Settings.Default.ChamEnemyGreen;
            blueEnemyCharmSlider.Value = Properties.Settings.Default.ChamEnemyBlue;

            redFriendlyCharmSlider.Value = Properties.Settings.Default.ChamFriendlyRed;
            greenFriendlyCharmSlider.Value = Properties.Settings.Default.ChamFriendlyGreen;
            blueFriendlyCharmSlider.Value = Properties.Settings.Default.ChamFriendlyBlue;

            brightnessCharmSlider.Value = Properties.Settings.Default.ChamBrightness;


            // Buttons
            antiFlashCheck.Checked = Properties.Settings.Default.AntiFlashToggled;
            fovCheck.Checked = Properties.Settings.Default.FovToggled;
            bunnyCheck.Checked = Properties.Settings.Default.BunnyhopToggled;
            skinChangerCheck.Checked = Properties.Settings.Default.SkinChangerToggled;
            thirdPersonCheck.Checked = Properties.Settings.Default.SkinChangerToggled;
            triggerbotCheck.Checked = Properties.Settings.Default.TriggerbotToggled;
            shootTeamCheck.Checked = Properties.Settings.Default.TriggerbotShootTeammates;
            glowCheck.Checked = Properties.Settings.Default.GlowToggled;
            healthBasedGlowCheck.Checked = Properties.Settings.Default.GlowHealthBased;
            onlyEnemyGlow.Checked = Properties.Settings.Default.GlowOnlyEnemy;
            radarCheck.Checked = Properties.Settings.Default.RadarToggled;
            chamsCheck.Checked = Properties.Settings.Default.ChamsToggled;

        }  // Fixing the colors of the program
        private void BackgroundRunner()
        {
            while (true)
            {
              
                fJump = BClient + Offsets.dwForceJump;
                aLocalPlayer = BClient + Offsets.dwLocalPlayer;
                LocalPlayer = vam.ReadInt32((IntPtr)aLocalPlayer);

                fAttack = BClient + Offsets.dwForceAttack;
                aFlags = LocalPlayer + Offsets.m_fFlags;

                glowObject = vam.ReadInt32((IntPtr)BClient + Offsets.dwGlowObjectManager);
                myTeam = vam.ReadInt32((IntPtr)LocalPlayer + Offsets.m_iTeamNum);

                aLocalPlayer = BClient + aLocalPlayer;

                Thread.Sleep(5000);

            }
        }

        // Functions
        private bool IsScoped()
        {
            return vam.ReadBoolean((IntPtr)LocalPlayer + Offsets.m_bIsScoped);
        } // Checks if user is scoped
        private void Shoot()
        {
            Thread.Sleep(Convert.ToInt32(tiggerbotDelay.Value));
            vam.WriteInt32((IntPtr)fAttack, 1);
            Thread.Sleep(10);
            vam.WriteInt32((IntPtr)fAttack, 4);
        } // Force shoot

        private void ApplySkin(int WeapInt, int skinID, int KillstreakNum)
        {
            vam.WriteInt32((IntPtr)WeapInt + Offsets.m_iItemIDHigh, 1);
            vam.WriteInt32((IntPtr)WeapInt + Offsets.m_nFallbackPaintKit, skinID); // Skin ID
            vam.WriteInt32((IntPtr)WeapInt + Offsets.m_nFallbackStatTrak, KillstreakNum); // Kill streak number
            vam.WriteInt32((IntPtr)WeapInt + Offsets.m_nFallbackSeed, 12); // Seed
            vam.WriteFloat((IntPtr)WeapInt + Offsets.m_flFallbackWear, 0f); // Float value
           
        }

        // Cheats
        private void AntiFlash()
        {
            while (antiFlashCheck.Checked)
            {
                int flashDur = 0;
                flashDur = vam.ReadInt32((IntPtr)LocalPlayer + Offsets.m_flFlashDuration);
                if (flashDur != 0)
                {
                    Thread.Sleep(antiFlashScroll.Value);
                    vam.WriteInt32((IntPtr)LocalPlayer + Offsets.m_flFlashDuration, 0);
                }
                Thread.Sleep(10);
            }
        } // Anti Flash
        private void Bunnyhop()
        {
            while (bunnyCheck.Checked)
            {
                while (GetAsyncKeyState(32) > 0)
                {
                    int flags = vam.ReadInt32((IntPtr)aFlags);
                    if (flags == 257 || flags == 263)
                    {
                        vam.WriteInt32((IntPtr)fJump, 5);
                        Thread.Sleep(10);
                        vam.WriteInt32((IntPtr)fJump, 4);
                    }
                    


                }
                Thread.Sleep(10);
            }
        } // Bunnyhop
        private void Glow()
        {
            while (glowCheck.Checked)
            {
                for (int i = 0; i < 64; i++)
                {
                    int entity = vam.ReadInt32((IntPtr)BClient + Offsets.dwEntityList + i * 0x10);

                    int glowIndx = vam.ReadInt32((IntPtr)entity + Offsets.m_iGlowIndex);
                    int entityTeam = vam.ReadInt32((IntPtr)entity + Offsets.m_iTeamNum);

                    int entityHealth = vam.ReadInt32((IntPtr)entity + Offsets.m_iHealth);


                    if (myTeam == entityTeam)
                    {
                        if (onlyEnemyGlow.Checked) continue;
                        vam.WriteFloat((IntPtr)glowObject + ((glowIndx * 0x38) + 0x4), 0);
                        vam.WriteFloat((IntPtr)glowObject + ((glowIndx * 0x38) + 0x8), 0);
                        vam.WriteFloat((IntPtr)glowObject + ((glowIndx * 0x38) + 0xC), 2);
                        vam.WriteFloat((IntPtr)glowObject + ((glowIndx * 0x38) + 0x10), 1);
                    }
                    else
                    {
                        float val1 = 1;
                        float val2 = 0;
                        float val3 = 0;
                        float val4 = 1;

                        if (entityHealth > 75 && healthBasedGlowCheck.Checked) // Green
                        {
                            val1 = 0;
                            val2 = 1;
                            val3 = 0;
                            val4 = 1;
                        }
                        else if (entityHealth > 50 && healthBasedGlowCheck.Checked) // Yellow
                        {
                            val1 = 1;
                            val2 = 1;
                            val3 = 0;
                            val4 = 1;
                        }
                        else if (entityHealth > 25 && healthBasedGlowCheck.Checked) // Red
                        {
                            val1 = 1;
                            val2 = 0;
                            val3 = 0;
                            val4 = 1;
                        }

                        vam.WriteFloat((IntPtr)glowObject + ((glowIndx * 0x38) + 0x4), val1);
                        vam.WriteFloat((IntPtr)glowObject + ((glowIndx * 0x38) + 0x8), val2);
                        vam.WriteFloat((IntPtr)glowObject + ((glowIndx * 0x38) + 0xC), val3);
                        vam.WriteFloat((IntPtr)glowObject + ((glowIndx * 0x38) + 0x10), val4);
                    }

                    vam.WriteBoolean((IntPtr)glowObject + ((glowIndx * 0x38) + 0x24), true);
                    vam.WriteBoolean((IntPtr)glowObject + ((glowIndx * 0x38) + 0x25), false);

                }
                Thread.Sleep(10);
            }
        } // Glow
        private void TriggerBot()
        {
            while (triggerbotCheck.Checked)
            {
                int address = LocalPlayer + Offsets.m_iCrosshairId;
                int PlayerInCross = vam.ReadInt32((IntPtr)address);
                int WeaponIndex = vam.ReadInt32((IntPtr)LocalPlayer + Offsets.m_hActiveWeapon) & 0xFFF;
                int WeapInt = vam.ReadInt32((IntPtr)(BClient + Offsets.dwEntityList + WeaponIndex * 0x10) - 0x10);
                int WeaponID = vam.ReadInt32((IntPtr)WeapInt + Offsets.m_iItemDefinitionIndex);

                if (PlayerInCross > 0 && PlayerInCross < 65)
                {
                    address = BClient + Offsets.dwEntityList + (PlayerInCross - 1) * oEntityLoopDistance;
                    int PtrToPIC = vam.ReadInt32((IntPtr)address);

                    address = PtrToPIC + Offsets.m_iHealth;
                    int PICHealth = vam.ReadInt32((IntPtr)address);

                    address = PtrToPIC + Offsets.m_iTeamNum;
                    int PICTeam = vam.ReadInt32((IntPtr)address);

                    if (((PICTeam != myTeam) && (PICTeam > 1) && (PICHealth > 0)) || shootTeamCheck.Checked && (PICTeam > 1) && (PICHealth > 0))
                    {
                        if (hasToBeScopedCheck.Checked)
                        {
                            if (WeaponID == 8 || WeaponID == 9 || WeaponID == 11 || WeaponID == 38 || WeaponID == 39 ||
                                WeaponID == 40)
                            {
                                if(IsScoped()) Shoot();
                            }
                            else Shoot();
                        }
                        else Shoot();
                    }
                }
                Thread.Sleep(10);
            }
        }  // Triggerbot
        private void SkinChanger()
        {
            while (skinChangerCheck.Checked)
            {
                int WeaponIndex = vam.ReadInt32((IntPtr)LocalPlayer + Offsets.m_hActiveWeapon) & 0xFFF;
                int WeapInt = vam.ReadInt32((IntPtr)(BClient + Offsets.dwEntityList + WeaponIndex * 0x10) - 0x10);
                int WeaponID = vam.ReadInt32((IntPtr)WeapInt + Offsets.m_iItemDefinitionIndex);
              
                //Debug.WriteLine(WeaponID);

                // https://www.mpgh.net/forum/showthread.php?t=1031822
                // https://www.mpgh.net/forum/showthread.php?t=1031822
                // https://tf2b.com/itemlist.php?gid=730

                if (WeaponID == 1)ApplySkin(WeapInt, Properties.Settings.Default.DESERTEAGLE_SkinID, Properties.Settings.Default.Killstreaknumber); //Desert Eagle
                else if (WeaponID == 2) ApplySkin(WeapInt, Properties.Settings.Default.DUALBERETTAS_SkinID, Properties.Settings.Default.Killstreaknumber); // Dual Berettas
                else if (WeaponID == 3) ApplySkin(WeapInt, Properties.Settings.Default.FIVESEVEN_SkinID, Properties.Settings.Default.Killstreaknumber); //Five-SeveN
                else if (WeaponID == 4) ApplySkin(WeapInt, Properties.Settings.Default.Glock18_SkinID, Properties.Settings.Default.Killstreaknumber);// Glock-18
                else if (WeaponID == 7) ApplySkin(WeapInt, Properties.Settings.Default.AK47_SkinID, Properties.Settings.Default.Killstreaknumber);// Ak-47
                else if (WeaponID == 8) ApplySkin(WeapInt, Properties.Settings.Default.AUG_SkinID, Properties.Settings.Default.Killstreaknumber);// AUG
                else if (WeaponID == 9) ApplySkin(WeapInt, Properties.Settings.Default.AWP_SkinID, Properties.Settings.Default.Killstreaknumber);// AWP
                else if (WeaponID == 10) ApplySkin(WeapInt, Properties.Settings.Default.FAMAS_SkinID, Properties.Settings.Default.Killstreaknumber); // FAMAS
                else if (WeaponID == 11) ApplySkin(WeapInt, Properties.Settings.Default.G3SG1_SkinID, Properties.Settings.Default.Killstreaknumber);// G3SSG1
                else if (WeaponID == 13) ApplySkin(WeapInt, Properties.Settings.Default.GALILAR_SkinID, Properties.Settings.Default.Killstreaknumber); // Galil AR
                else if (WeaponID == 14) ApplySkin(WeapInt, Properties.Settings.Default.M249_SkinID, Properties.Settings.Default.Killstreaknumber);// M249
                else if (WeaponID == 16) ApplySkin(WeapInt, Properties.Settings.Default.M4A4_SkinID, Properties.Settings.Default.Killstreaknumber); // M4A4
                else if (WeaponID == 17) ApplySkin(WeapInt, Properties.Settings.Default.MAC10_SkinID, Properties.Settings.Default.Killstreaknumber); // MAC-10
                else if (WeaponID == 19) ApplySkin(WeapInt, Properties.Settings.Default.P90_SkinID, Properties.Settings.Default.Killstreaknumber); // P90 
                else if (WeaponID == 23) ApplySkin(WeapInt, Properties.Settings.Default.MP5SD_SkinID, Properties.Settings.Default.Killstreaknumber); // Mp5-SD
                else if (WeaponID == 24) ApplySkin(WeapInt, Properties.Settings.Default.UMP45_SkinID, Properties.Settings.Default.Killstreaknumber); // UMP-45
                else if (WeaponID == 25) ApplySkin(WeapInt, Properties.Settings.Default.XM1014_SkinID, Properties.Settings.Default.Killstreaknumber); // XM1014 
                else if (WeaponID == 26) ApplySkin(WeapInt, Properties.Settings.Default.PPBIZON_SkinID, Properties.Settings.Default.Killstreaknumber); // PP-Bizon
                else if (WeaponID == 27) ApplySkin(WeapInt, Properties.Settings.Default.MAG7_SkinID, Properties.Settings.Default.Killstreaknumber); // MAG-7
                else if (WeaponID == 28) ApplySkin(WeapInt, Properties.Settings.Default.NEGEV_SkinID, Properties.Settings.Default.Killstreaknumber); // NEGEV
                else if (WeaponID == 29) ApplySkin(WeapInt, Properties.Settings.Default.SAWEDOFF_SkinID, Properties.Settings.Default.Killstreaknumber);// Sawed-Off
                else if (WeaponID == 30) ApplySkin(WeapInt, Properties.Settings.Default.TEC9_SkinID, Properties.Settings.Default.Killstreaknumber);// TEC-9
                else if (WeaponID == 32) ApplySkin(WeapInt, Properties.Settings.Default.P2000_SkinID, Properties.Settings.Default.Killstreaknumber); // P2000
                else if (WeaponID == 33) ApplySkin(WeapInt, Properties.Settings.Default.MP7_SkinID, Properties.Settings.Default.Killstreaknumber); // MP7
                else if (WeaponID == 34) ApplySkin(WeapInt, Properties.Settings.Default.MP9_SkinID, Properties.Settings.Default.Killstreaknumber); // MP9
                else if (WeaponID == 35) ApplySkin(WeapInt, Properties.Settings.Default.NOVA_SkinID, Properties.Settings.Default.Killstreaknumber); // Nova
                else if (WeaponID == 36) ApplySkin(WeapInt, Properties.Settings.Default.P250_SkinID, Properties.Settings.Default.Killstreaknumber); // P250
                else if (WeaponID == 38) ApplySkin(WeapInt, Properties.Settings.Default.SCAR20_SkinID, Properties.Settings.Default.Killstreaknumber); // SCAR-20
                else if (WeaponID == 39) ApplySkin(WeapInt, Properties.Settings.Default.SG553_SkinID, Properties.Settings.Default.Killstreaknumber); // SG-553
                else if (WeaponID == 40) ApplySkin(WeapInt, Properties.Settings.Default.SSG08_SkinID, Properties.Settings.Default.Killstreaknumber); // SSG 08
                else if (WeaponID == 60) ApplySkin(WeapInt, Properties.Settings.Default.M4A1S_SkinID, Properties.Settings.Default.Killstreaknumber);// M4A1-S
                else if (WeaponID == 61) ApplySkin(WeapInt, Properties.Settings.Default.USPS_SkinID, Properties.Settings.Default.Killstreaknumber); // USP-S
                else if (WeaponID == 63) ApplySkin(WeapInt, Properties.Settings.Default.CZ75Auto_SkinID, Properties.Settings.Default.Killstreaknumber); // CZ75-Auto
                else if (WeaponID == 64) ApplySkin(WeapInt, Properties.Settings.Default.R8REVOLVER_SkinID, Properties.Settings.Default.Killstreaknumber); // R8 Revolver

              

                vam.WriteInt32((IntPtr)Offsets.dwClientState_GetLocalPlayer + 0x16C, -1);




                Properties.Settings.Default.Save();
            }
        } // Skin changer
        private void Radar()
        {
            while (radarCheck.Checked)
            {
                for (int i = 0; i < 64; i++)
                {
                    int entity = vam.ReadInt32((IntPtr) BClient + Offsets.dwEntityList + i * 0x10);
                    vam.WriteBoolean((IntPtr) entity + Offsets.m_bSpotted, true);
                }

                Thread.Sleep(10);
            }
        } // Radar
        private void Fov()
        {
            while (fovCheck.Checked)
            {
               vam.WriteInt32((IntPtr)LocalPlayer + Offsets.m_iFOV, fovSlider.Value);
               Thread.Sleep(10);
            }
        } // Fov changer
        private void Chams()
        {
            while (chamsCheck.Checked)
            {
                for (int i = 0; i < 64; i++)
                {
                    int entity = vam.ReadInt32((IntPtr)BClient + Offsets.dwEntityList + i * 0x10);
                    int entityTeam = vam.ReadInt32((IntPtr)entity + Offsets.m_iTeamNum);

                    if (myTeam == entityTeam)
                    {
                        //Model Color
                        vam.WriteByte((IntPtr)entity + 0x70, (byte)redFriendlyCharmSlider.Value); // r
                        vam.WriteByte((IntPtr)entity + 0x71, (byte)greenFriendlyCharmSlider.Value); // g
                        vam.WriteByte((IntPtr)entity + 0x72, (byte)blueFriendlyCharmSlider.Value); // b
                    }
                    else
                    {
                        //Model Color
                        vam.WriteByte((IntPtr)entity + 0x70, (byte)redEnemyCharmSlider.Value); // r
                        vam.WriteByte((IntPtr)entity + 0x71, (byte)greenEnemyCharmSlider.Value); // g
                        vam.WriteByte((IntPtr)entity + 0x72, (byte)blueEnemyCharmSlider.Value); // b
                    }
                    // https://www.unknowncheats.me/forum/counterstrike-global-offensive/305257-clrrender-brightness-external-chams.html
                }
                float brightness = (float)brightnessCharmSlider.Value;
                int thisPtr = (int)(EngineBase + Offsets.model_ambient_min - 0x2c);

                byte[] bytearray = BitConverter.GetBytes(brightness);
                int intbrightness = BitConverter.ToInt32(bytearray, 0);
                int xored = intbrightness ^ thisPtr;

                vam.WriteInt32((IntPtr)EngineBase + Offsets.model_ambient_min, xored);

                Thread.Sleep(10);
            }

            if (chamsCheck.Checked == false)
            {
                for (int i = 0; i < 64; i++)
                {
                    int entity = vam.ReadInt32((IntPtr)BClient + Offsets.dwEntityList + i * 0x10);
                    int entityTeam = vam.ReadInt32((IntPtr)entity + Offsets.m_iTeamNum);

                    if (myTeam == entityTeam)
                    {
                        //Model Color
                        vam.WriteByte((IntPtr)entity + 0x70, (byte)255); // r
                        vam.WriteByte((IntPtr)entity + 0x71, (byte)255); // g
                        vam.WriteByte((IntPtr)entity + 0x72, (byte)255); // b
                    }
                    else
                    {
                        //Model Color
                        vam.WriteByte((IntPtr)entity + 0x70, (byte)255); // r
                        vam.WriteByte((IntPtr)entity + 0x71, (byte)255); // g
                        vam.WriteByte((IntPtr)entity + 0x72, (byte)255); // b
                    }
                    // https://www.unknowncheats.me/forum/counterstrike-global-offensive/305257-clrrender-brightness-external-chams.html
                }

                float brightness = (float)0;
                int thisPtr = (int)(EngineBase + Offsets.model_ambient_min - 0x2c);

                byte[] bytearray = BitConverter.GetBytes(brightness);
                int intbrightness = BitConverter.ToInt32(bytearray, 0);
                int xored = intbrightness ^ thisPtr;

                vam.WriteInt32((IntPtr)EngineBase + Offsets.model_ambient_min, xored);

            }
        }
       

      
        //  When the form is closed
        void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process[] ps = Process.GetProcessesByName("Eclipse");

            foreach (Process p in ps)
            {
                try
                {
                    if (!p.HasExited)
                    {
                        p.Kill();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(String.Format("Unable to kill process {0}, exception: {1}", p.ToString(), ex.ToString()));
                }
            }

        }

        // Checks
        private void glowCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (glowCheck.Checked)
            {
                Thread Glow = new Thread(this.Glow);
                Glow.Start();
            }
            Properties.Settings.Default.GlowToggled = glowCheck.Checked;
            Properties.Settings.Default.Save();
        }
        private void radarCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (radarCheck.Checked)
            {
                Thread Glow = new Thread(this.Radar);
                Glow.Start();
            }
            Properties.Settings.Default.RadarToggled = radarCheck.Checked;
            Properties.Settings.Default.Save();
        }
        private void antiFlashCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (antiFlashCheck.Checked)
            {
                Thread AntiFlash = new Thread(this.AntiFlash);
                AntiFlash.Start();
            }

            Properties.Settings.Default.AntiFlashToggled = antiFlashCheck.Checked;
            Properties.Settings.Default.Save();
        }
        private void skinChangerCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (skinChangerCheck.Checked)
            {
                Thread SkinChanger = new Thread(this.SkinChanger);
                SkinChanger.Start();
            }
            Properties.Settings.Default.SkinChangerToggled = skinChangerCheck.Checked;
            Properties.Settings.Default.Save();
        }
        private void thirdPersonCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (thirdPersonCheck.Checked) vam.WriteInt32((IntPtr)LocalPlayer + Offsets.m_iObserverMode, 1);
            else vam.WriteInt32((IntPtr)LocalPlayer + Offsets.m_iObserverMode, 0);

            Properties.Settings.Default.ThirdpersonToggled = thirdPersonCheck.Checked;
            Properties.Settings.Default.Save();
        }
        private void bunnyCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (bunnyCheck.Checked)
            {
                Thread BunnyHop = new Thread(this.Bunnyhop);
                BunnyHop.Start();
            }
            Properties.Settings.Default.BunnyhopToggled = bunnyCheck.Checked;
            Properties.Settings.Default.Save();
        }
        private void triggerbotCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (triggerbotCheck.Checked)
            {
                Thread TriggerBot = new Thread(this.TriggerBot);
                TriggerBot.Start();
            }
            Properties.Settings.Default.TriggerbotToggled = triggerbotCheck.Checked;
            Properties.Settings.Default.Save();
        }
        private void fovCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (fovCheck.Checked)
            {
                Thread f = new Thread(this.Fov);
                f.Start();
            }
            Properties.Settings.Default.FovToggled = fovCheck.Checked;
            Properties.Settings.Default.Save();
        }
        private void chamsCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (chamsCheck.Checked)
            {
                Thread f = new Thread(this.Chams);
                f.Start();
            }
            Properties.Settings.Default.ChamsToggled = chamsCheck.Checked;
            Properties.Settings.Default.Save();
        }
        // Scrolls
        private void tiggerbotDelay_Scroll(object sender, ScrollEventArgs e)
        {
            double indexDbl = (tiggerbotDelay.Value * 1.0) / 5;
            int index = Convert.ToInt32(Math.Round(indexDbl));

            tiggerbotDelay.Value = 5 * index;

            metroLabel5.Text = tiggerbotDelay.Value + " ms";

            Properties.Settings.Default.DelayTriggerBot = tiggerbotDelay.Value;
            Properties.Settings.Default.Save();
        }
        private void antiFlashScroll_Scroll_1(object sender, ScrollEventArgs e)
        {
            double indexDbl = (antiFlashScroll.Value * 1.0) / 10;
            int index = Convert.ToInt32(Math.Round(indexDbl));

            antiFlashScroll.Value = 10 * index;

            metroLabel7.Text = antiFlashScroll.Value + " ms";

            Properties.Settings.Default.DelayAntiFlash = antiFlashScroll.Value;
            Properties.Settings.Default.Save();
        }
        private void fovSlider_Scroll(object sender, ScrollEventArgs e)
        {
            metroLabel3.Text = fovSlider.Value.ToString();

            Properties.Settings.Default.FovSlider = fovSlider.Value;
            Properties.Settings.Default.Save();
        }
        // New skin
        private void applySkinUpdate_Click(object sender, EventArgs e)
        {
            string gun = weaponName.Text.Replace("-", "");
            gun = gun.ToUpper();

            Properties.Settings.Default[gun.Replace(" ", "") + "_SkinID"] = Convert.ToInt32(skinID.Text);
            Properties.Settings.Default.Save(); // Saves settings in application configuration file
        }

        private void shootTeamCheck_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.TriggerbotShootTeammates = shootTeamCheck.Checked;
            Properties.Settings.Default.Save();
        }
        private void healthBasedGlowCheck_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.GlowHealthBased = healthBasedGlowCheck.Checked;
            Properties.Settings.Default.Save();
        }
        private void onlyEnemyGlow_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.GlowOnlyEnemy = onlyEnemyGlow.Checked;
            Properties.Settings.Default.Save();
        }
        private void redEnemyCharmSlider_Scroll(object sender, ScrollEventArgs e)
        {
            Properties.Settings.Default.ChamEnemyRed = redEnemyCharmSlider.Value;
            Properties.Settings.Default.Save();
        }
        private void greenEnemyCharmSlider_Scroll(object sender, ScrollEventArgs e)
        {
            Properties.Settings.Default.ChamEnemyGreen = greenEnemyCharmSlider.Value;
            Properties.Settings.Default.Save();
        }
        private void blueEnemyCharmSlider_Scroll(object sender, ScrollEventArgs e)
        {
            Properties.Settings.Default.ChamEnemyBlue= blueEnemyCharmSlider.Value;
            Properties.Settings.Default.Save();
        }
        private void redFriendlyCharmSlider_Scroll(object sender, ScrollEventArgs e)
        {
            Properties.Settings.Default.ChamFriendlyRed = redFriendlyCharmSlider.Value;
            Properties.Settings.Default.Save();
        }
        private void greenFriendlyCharmSlider_Scroll(object sender, ScrollEventArgs e)
        {
            Properties.Settings.Default.ChamFriendlyGreen = greenFriendlyCharmSlider.Value;
            Properties.Settings.Default.Save();
        }
        private void blueFriendlyCharmSlider_Scroll(object sender, ScrollEventArgs e)
        {
            Properties.Settings.Default.ChamFriendlyBlue= blueFriendlyCharmSlider.Value;
            Properties.Settings.Default.Save();
        }
        private void brightnessCharmSlider_Scroll(object sender, ScrollEventArgs e)
        {
            Properties.Settings.Default.ChamBrightness = brightnessCharmSlider.Value;
            Properties.Settings.Default.Save();
        }

        // Tabs
        // Aim
        private void label1_Click(object sender, EventArgs e)
        {
            CheatTabs.SelectedTab = aimTab;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CheatTabs.SelectedTab = aimTab;
        }
        // Visual
        private void label2_Click(object sender, EventArgs e)
        {
            CheatTabs.SelectedTab = visualTab;
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            CheatTabs.SelectedTab = visualTab;
        }
        // Misc
        private void label3_Click(object sender, EventArgs e)
        {
            CheatTabs.SelectedTab = miscTab;
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            CheatTabs.SelectedTab = miscTab;
        }
        // Skin Changer
        private void label4_Click(object sender, EventArgs e)
        {
            CheatTabs.SelectedTab = skinChangerTab;
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            CheatTabs.SelectedTab = skinChangerTab;
        }
    }
}
