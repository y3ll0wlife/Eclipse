using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eclipse
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {

            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(Form1_FormClosed);

            Running();
        }

        //  When the form is closed
        private static void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process[] ps = Process.GetProcessesByName("Eclipse");

            foreach (Process p in ps)
            {
                try
                {
                    if (!p.HasExited) p.Kill();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(String.Format("Unable to kill process {0}, exception: {1}", p.ToString(), ex.ToString()));
                }
            }

        }

        public static bool IsReady()
        {
            Memory.OpenProcess(Config.Process_name);
            Memory.ProcessHandle();
            Memory.GetModules();

            Player.BaseClient = Memory.Client;
            Player.EngineBase = Memory.Engine;

            return true;
        }

        private static void Running()
        {
            if (IsReady())
            {
                Utils.UpdateActions();

                Thread runner = new Thread(BackgroundRunner);
                runner.Start();
            }
            else
            {
                MessageBox.Show("Error when starting the client");
                Thread.Sleep(5000);
            }
        }

        private static void BackgroundRunner()
        {
            while (true)
            {
                Utils.UpdateActions();
                Thread.Sleep(5000);
            }
        }


        // ===Aim===
        // Triggerbot
        public void TriggerbotCheck_CheckedChanged(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => Cheats.Triggerbot(TriggerbotCheck, TriggerbotScopebefore, TriggerbotShootTeammates, DelayTriggerbotMS));
            thread.Start();
        }

        private void DelayTriggerbotMS_Scroll(object sender, ScrollEventArgs e)
        {
            TriggerbotDelayLabel.Text = DelayTriggerbotMS.Value + " ms";
        }



        //==Visual==
        // Glow
        private void GlowCheck_CheckedChanged(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => Cheats.Glow(GlowCheck, GlowHealthbased, GlowOnlyEnemy, GlowOnlyTeammates));
            thread.Start();
        }
        // Chams
        private void ChamsCheck_CheckedChanged(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => Cheats.Chams(ChamsCheck, ChamFriendlyRed, ChamFriendlyGreen, ChamFriendlyBlue, ChamEnemyRed, ChamEnemyGreen, ChamEnemyBlue, ChamBrigtness));
            thread.Start();
        }

        // Radar
        private void RadarCheck_CheckedChanged(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => Cheats.Radar(RadarCheck));
            thread.Start();
        }

        // ===MISC===
        // Bunnyhop
        private void BunnyhopCheck_CheckedChanged(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => Cheats.Bunnyhop(BunnyhopCheck));
            thread.Start();
        }


        // Anti Flash
        private void AntiflashCheck_CheckedChanged(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => Cheats.AntiFlash(AntiflashCheck, AntiflashDelay));
            thread.Start();
        }
        private void AntiflashDelay_Scroll(object sender, ScrollEventArgs e)
        {
            AntiflashDelayLabel.Text = AntiflashDelay.Value + " ms";
        }


        // Skin Changer
        private void SkinchangerCheck_CheckedChanged(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => Cheats.SkinChanger(SkinchangerCheck));
            thread.Start();
        }
        // Fov Changer
        private void FovCheck_CheckedChanged(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => Cheats.Fov(FovCheck, FovAmount));
            thread.Start();
        }

        // Third person
        private void ThirdpersonCheck_CheckedChanged(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => Cheats.ThirdPerson(ThirdpersonCheck));
            thread.Start();

            if(!ThirdpersonCheck.Checked) Memory.Write(Player.LocalPlayer + Offsets.m_iObserverMode, 0);
        }

        
    }
}
