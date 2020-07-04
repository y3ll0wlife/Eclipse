using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace Eclipse
{
    public class Cheats
    {
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(int vKey);

        // ===Aim===
        // Triggerbot
        public static void Triggerbot(CheckBox check, CheckBox needsScoped, CheckBox shootTeam, MetroTrackBar delay)
        {
           
            while (check.Checked)
            {
                int address = Player.LocalPlayer + Offsets.m_iCrosshairId;
                int PlayerInCross = Memory.Read<int>(address);
                int WeaponIndex = Memory.Read<int>(Player.LocalPlayer + Offsets.m_hActiveWeapon) & 0xFFF;
                int WeapInt = Memory.Read<int>((Player.BaseClient + Offsets.dwEntityList + WeaponIndex * 0x10) - 0x10);
                int WeaponID = Memory.Read<int>(WeapInt + Offsets.m_iItemDefinitionIndex);
                

                if (PlayerInCross > 0 && PlayerInCross < 65)
                {
                    address = Player.BaseClient + Offsets.dwEntityList + (PlayerInCross - 1) * Config.OEntityLoopDistance;
                    int PtrToPIC = Memory.Read<int>(address);

                    address = PtrToPIC + Offsets.m_iHealth;
                    int PICHealth = Memory.Read<int>(address);

                    address = PtrToPIC + Offsets.m_iTeamNum;
                    int PICTeam = Memory.Read<int>(address);

                    if (((PICTeam != Player.PlayerTeam) && (PICTeam > 1) && (PICHealth > 0)) || shootTeam.Checked && (PICTeam > 1) && (PICHealth > 0))
                    {
                        if (needsScoped.Checked)
                        {
                            
                            if (WeaponID == 8 || WeaponID == 9 || WeaponID == 11 || WeaponID == 38 || WeaponID == 39 ||
                                WeaponID == 40)
                            {
                                if (Utils.IsScoped()) Utils.Shoot(Convert.ToInt32(delay.Value));
                            }
                            else Utils.Shoot(Convert.ToInt32(delay.Value));
                        }
                        else Utils.Shoot(Convert.ToInt32(delay.Value));
                    }
                }
                Thread.Sleep(10);
            }
        }

        //==Visual==
        // Glow
        public static void Glow(CheckBox check, CheckBox healthBased, CheckBox onlyEnemy, CheckBox onlyTeam)
        {
            while (check.Checked)
            {
                for (int i = 0; i < 64; i++)
                {
                    int entity = Memory.Read<int>(Player.BaseClient + Offsets.dwEntityList + i * 0x10);

                    int glowIndx = Memory.Read<int>(entity + Offsets.m_iGlowIndex);
                    int entityTeam = Memory.Read<int>(entity + Offsets.m_iTeamNum);

                    int entityHealth = Memory.Read<int>(entity + Offsets.m_iHealth);


                    float val1 = 1;
                    float val2 = 0;
                    float val3 = 0;
                    float val4 = 1;


                    if (Player.PlayerTeam == entityTeam)
                    {
                        val1 = 0;
                        val2 = 0;
                        val3 = 1;
                        val4 = 1;
                        
                        if(onlyEnemy.Checked) continue;
                        Memory.Write(Player.GlowObject + ((glowIndx * 0x38) + 0x4), val1);
                        Memory.Write(Player.GlowObject + ((glowIndx * 0x38) + 0x8), val2);
                        Memory.Write(Player.GlowObject + ((glowIndx * 0x38) + 0xC), val3);
                        Memory.Write(Player.GlowObject + ((glowIndx * 0x38) + 0x10), val4);
                    }
                    else
                    {
                        if (onlyTeam.Checked) continue;

                        if (entityHealth > 75 && healthBased.Checked) // Green
                        {
                            val1 = 0;
                            val2 = 1;
                            val3 = 0;
                            val4 = 1;
                        }
                        else if (entityHealth > 50 && healthBased.Checked) // Yellow
                        {
                            val1 = 1;
                            val2 = 1;
                            val3 = 0;
                            val4 = 1;
                        }
                        else if (entityHealth > 25 && healthBased.Checked) // Red
                        {
                            val1 = 1;
                            val2 = 0;
                            val3 = 0;
                            val4 = 1;
                        }

                        
                        Memory.Write(Player.GlowObject + ((glowIndx * 0x38) + 0x4), val1);
                        Memory.Write(Player.GlowObject + ((glowIndx * 0x38) + 0x8), val2);
                        Memory.Write(Player.GlowObject + ((glowIndx * 0x38) + 0xC), val3);
                        Memory.Write(Player.GlowObject + ((glowIndx * 0x38) + 0x10), val4);
                    }

                    Memory.Write(Player.GlowObject + ((glowIndx * 0x38) + 0x24), true);
                    Memory.Write(Player.GlowObject + ((glowIndx * 0x38) + 0x25), false);

                }

                Thread.Sleep(10);
            }
        }

        // Chams
        public static void Chams(CheckBox check, MetroTrackBar rfs, MetroTrackBar gfs, MetroTrackBar bfs, MetroTrackBar res, MetroTrackBar ges, MetroTrackBar bes, MetroTrackBar brightnes)
        {
            while (check.Checked)
            {
                for (int i = 0; i < 64; i++)
                {
                    int entity = Memory.Read<int>(Player.BaseClient + Offsets.dwEntityList + i * 0x10);
                    int entityTeam = Memory.Read<int>(entity + Offsets.m_iTeamNum);

                    if (Player.PlayerTeam == entityTeam)
                    {
                        //Model Color
                        Memory.Write(entity + 0x70, (byte)rfs.Value); // r
                        Memory.Write(entity + 0x71, (byte)gfs.Value); // g
                        Memory.Write(entity + 0x72, (byte)bfs.Value); // b
                    }
                    else
                    {
                        //Model Color
                        Memory.Write(entity + 0x70, (byte)res.Value); // r
                        Memory.Write(entity + 0x71, (byte)ges.Value); // g
                        Memory.Write(entity + 0x72, (byte)bes.Value); // b
                    }
                    // https://www.unknowncheats.me/forum/counterstrike-global-offensive/305257-clrrender-brightness-external-chams.html
                }
                float brightness = (float)brightnes.Value;
                int thisPtr = (int)(Player.EngineBase + Offsets.model_ambient_min - 0x2c);

                byte[] bytearray = BitConverter.GetBytes(brightness);
                int intbrightness = BitConverter.ToInt32(bytearray, 0);
                int xored = intbrightness ^ thisPtr;

                Memory.Write(Player.EngineBase + Offsets.model_ambient_min, xored);

                Thread.Sleep(10);
            }

            if (check.Checked == false)
            {
                for (int i = 0; i < 64; i++)
                {
                    int entity = Memory.Read<int>(Player.BaseClient + Offsets.dwEntityList + i * 0x10);
                    int entityTeam = Memory.Read<int>(entity + Offsets.m_iTeamNum);

                    if (Player.PlayerTeam == entityTeam)
                    {
                        //Model Color
                        Memory.Write(entity + 0x70, (byte)255); // r
                        Memory.Write(entity + 0x71, (byte)255); // g
                        Memory.Write(entity + 0x72, (byte)255); // b
                    }
                    else
                    {
                        //Model Color
                        Memory.Write(entity + 0x70, (byte)255); // r
                        Memory.Write(entity + 0x71, (byte)255); // g
                        Memory.Write(entity + 0x72, (byte)255); // b
                    }
                    // https://www.unknowncheats.me/forum/counterstrike-global-offensive/305257-clrrender-brightness-external-chams.html
                }

                float brightness = (float)0;
                int thisPtr = (int)(Player.EngineBase + Offsets.model_ambient_min - 0x2c);

                byte[] bytearray = BitConverter.GetBytes(brightness);
                int intbrightness = BitConverter.ToInt32(bytearray, 0);
                int xored = intbrightness ^ thisPtr;

                Memory.Write(Player.EngineBase + Offsets.model_ambient_min, xored);

            }
        }


        // Radar
        public static void Radar(CheckBox check)
        {
            while (check.Checked)
            {
                for (int i = 0; i < 64; i++)
                {
                    int entity = Memory.Read<int>(Player.BaseClient + Offsets.dwEntityList + i * 0x10);
                    Memory.Write(entity + Offsets.m_bSpotted, true);
                }

                Thread.Sleep(10);
            }
        }

        // ===MISC===
        // Bunnyhop
        public static void Bunnyhop(CheckBox check)
        {
            while (check.Checked)
            {
                while (GetAsyncKeyState(32) > 0)
                {
                    int flag = Memory.Read<int>(Player.AFlag);

                    if (flag == 257 || flag == 263)
                    {
                        Memory.Write(Player.ForceJump, 5);
                        Thread.Sleep(10);
                        Memory.Write(Player.ForceJump, 4);

                    }

                }
                Thread.Sleep(10);
            }
           
        }

        // Anti flash
        public static void AntiFlash(CheckBox check, MetroTrackBar delayBar)
        {
            while (check.Checked)
            {
                int flashDur = 0;
                flashDur = Memory.Read<int>(Player.LocalPlayer + Offsets.m_flFlashDuration);
                if (flashDur != 0)
                {
                    Thread.Sleep(delayBar.Value);
                    Memory.Write(Player.LocalPlayer + Offsets.m_flFlashDuration, 0);
                }
                Thread.Sleep(10);
            }
        }

        // Skin changer
        public static void SkinChanger(CheckBox check)
        {
            while (check.Checked)
            {
                int WeaponIndex = Memory.Read<int>(Player.LocalPlayer + Offsets.m_hActiveWeapon) & 0xFFF;
                int WeapInt = Memory.Read<int>((Player.BaseClient + Offsets.dwEntityList + WeaponIndex * 0x10) - 0x10);
                int WeaponID = Memory.Read<int>(WeapInt + Offsets.m_iItemDefinitionIndex);

                // https://www.mpgh.net/forum/showthread.php?t=1031822
                // https://www.mpgh.net/forum/showthread.php?t=1031822
                // https://tf2b.com/itemlist.php?gid=730

                if (WeaponID == 1) Utils.ApplySkin(WeapInt, Properties.Settings.Default.DESERTEAGLE_SkinID, Properties.Settings.Default.Killstreaknumber); //Desert Eagle
                else if (WeaponID == 2) Utils.ApplySkin(WeapInt, Properties.Settings.Default.DUALBERETTAS_SkinID, Properties.Settings.Default.Killstreaknumber); // Dual Berettas
                else if (WeaponID == 3) Utils.ApplySkin(WeapInt, Properties.Settings.Default.FIVESEVEN_SkinID, Properties.Settings.Default.Killstreaknumber); //Five-SeveN
                else if (WeaponID == 4) Utils.ApplySkin(WeapInt, Properties.Settings.Default.Glock18_SkinID, Properties.Settings.Default.Killstreaknumber);// Glock-18
                else if (WeaponID == 7) Utils.ApplySkin(WeapInt, Properties.Settings.Default.AK47_SkinID, Properties.Settings.Default.Killstreaknumber);// Ak-47
                else if (WeaponID == 8) Utils.ApplySkin(WeapInt, Properties.Settings.Default.AUG_SkinID, Properties.Settings.Default.Killstreaknumber);// AUG
                else if (WeaponID == 9) Utils.ApplySkin(WeapInt, Properties.Settings.Default.AWP_SkinID, Properties.Settings.Default.Killstreaknumber);// AWP
                else if (WeaponID == 10) Utils.ApplySkin(WeapInt, Properties.Settings.Default.FAMAS_SkinID, Properties.Settings.Default.Killstreaknumber); // FAMAS
                else if (WeaponID == 11) Utils.ApplySkin(WeapInt, Properties.Settings.Default.G3SG1_SkinID, Properties.Settings.Default.Killstreaknumber);// G3SSG1
                else if (WeaponID == 13) Utils.ApplySkin(WeapInt, Properties.Settings.Default.GALILAR_SkinID, Properties.Settings.Default.Killstreaknumber); // Galil AR
                else if (WeaponID == 14) Utils.ApplySkin(WeapInt, Properties.Settings.Default.M249_SkinID, Properties.Settings.Default.Killstreaknumber);// M249
                else if (WeaponID == 16) Utils.ApplySkin(WeapInt, Properties.Settings.Default.M4A4_SkinID, Properties.Settings.Default.Killstreaknumber); // M4A4
                else if (WeaponID == 17) Utils.ApplySkin(WeapInt, Properties.Settings.Default.MAC10_SkinID, Properties.Settings.Default.Killstreaknumber); // MAC-10
                else if (WeaponID == 19) Utils.ApplySkin(WeapInt, Properties.Settings.Default.P90_SkinID, Properties.Settings.Default.Killstreaknumber); // P90 
                else if (WeaponID == 23) Utils.ApplySkin(WeapInt, Properties.Settings.Default.MP5SD_SkinID, Properties.Settings.Default.Killstreaknumber); // Mp5-SD
                else if (WeaponID == 24) Utils.ApplySkin(WeapInt, Properties.Settings.Default.UMP45_SkinID, Properties.Settings.Default.Killstreaknumber); // UMP-45
                else if (WeaponID == 25) Utils.ApplySkin(WeapInt, Properties.Settings.Default.XM1014_SkinID, Properties.Settings.Default.Killstreaknumber); // XM1014 
                else if (WeaponID == 26) Utils.ApplySkin(WeapInt, Properties.Settings.Default.PPBIZON_SkinID, Properties.Settings.Default.Killstreaknumber); // PP-Bizon
                else if (WeaponID == 27) Utils.ApplySkin(WeapInt, Properties.Settings.Default.MAG7_SkinID, Properties.Settings.Default.Killstreaknumber); // MAG-7
                else if (WeaponID == 28) Utils.ApplySkin(WeapInt, Properties.Settings.Default.NEGEV_SkinID, Properties.Settings.Default.Killstreaknumber); // NEGEV
                else if (WeaponID == 29) Utils.ApplySkin(WeapInt, Properties.Settings.Default.SAWEDOFF_SkinID, Properties.Settings.Default.Killstreaknumber);// Sawed-Off
                else if (WeaponID == 30) Utils.ApplySkin(WeapInt, Properties.Settings.Default.TEC9_SkinID, Properties.Settings.Default.Killstreaknumber);// TEC-9
                else if (WeaponID == 32) Utils.ApplySkin(WeapInt, Properties.Settings.Default.P2000_SkinID, Properties.Settings.Default.Killstreaknumber); // P2000
                else if (WeaponID == 33) Utils.ApplySkin(WeapInt, Properties.Settings.Default.MP7_SkinID, Properties.Settings.Default.Killstreaknumber); // MP7
                else if (WeaponID == 34) Utils.ApplySkin(WeapInt, Properties.Settings.Default.MP9_SkinID, Properties.Settings.Default.Killstreaknumber); // MP9
                else if (WeaponID == 35) Utils.ApplySkin(WeapInt, Properties.Settings.Default.NOVA_SkinID, Properties.Settings.Default.Killstreaknumber); // Nova
                else if (WeaponID == 36) Utils.ApplySkin(WeapInt, Properties.Settings.Default.P250_SkinID, Properties.Settings.Default.Killstreaknumber); // P250
                else if (WeaponID == 38) Utils.ApplySkin(WeapInt, Properties.Settings.Default.SCAR20_SkinID, Properties.Settings.Default.Killstreaknumber); // SCAR-20
                else if (WeaponID == 39) Utils.ApplySkin(WeapInt, Properties.Settings.Default.SG553_SkinID, Properties.Settings.Default.Killstreaknumber); // SG-553
                else if (WeaponID == 40) Utils.ApplySkin(WeapInt, Properties.Settings.Default.SSG08_SkinID, Properties.Settings.Default.Killstreaknumber); // SSG 08
                else if (WeaponID == 60) Utils.ApplySkin(WeapInt, Properties.Settings.Default.M4A1S_SkinID, Properties.Settings.Default.Killstreaknumber);// M4A1-S
                else if (WeaponID == 61) Utils.ApplySkin(WeapInt, Properties.Settings.Default.USPS_SkinID, Properties.Settings.Default.Killstreaknumber); // USP-S
                else if (WeaponID == 63) Utils.ApplySkin(WeapInt, Properties.Settings.Default.CZ75Auto_SkinID, Properties.Settings.Default.Killstreaknumber); // CZ75-Auto
                else if (WeaponID == 64) Utils.ApplySkin(WeapInt, Properties.Settings.Default.R8REVOLVER_SkinID, Properties.Settings.Default.Killstreaknumber); // R8 Revolver

                Memory.Write(Offsets.dwClientState_GetLocalPlayer + 0x16C, -1);

                Properties.Settings.Default.Save();
            }
        }

        // Fov changer
        public static void Fov(CheckBox check, MetroTrackBar slider)
        {
            while (check.Checked)
            {
                Memory.Write(Player.LocalPlayer + Offsets.m_iFOV, slider.Value);
                Thread.Sleep(10);
            }
        }

        // Third person
        public static void ThirdPerson(CheckBox check)
        {
            Memory.Write(Player.LocalPlayer + Offsets.m_iObserverMode, 1);
        }
    }

}
