using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Eclipse
{
    public class Utils
    {
        public static void UpdateActions()
        {
            // Player
            Player.ALocalPlayer = Player.BaseClient + Offsets.dwLocalPlayer;
            Player.LocalPlayer = Memory.Read<int>(Player.ALocalPlayer);

            Player.AFlag = Player.LocalPlayer + Offsets.m_fFlags;

            // Player Attributes
            Player.PlayerTeam = Memory.Read<int>(Player.LocalPlayer + Offsets.m_iTeamNum);

            // Actions
            Player.ForceAttack = Player.BaseClient + Offsets.dwForceAttack;
            Player.ForceJump = Player.BaseClient + Offsets.dwForceJump;

             // Other
            Player.GlowObject = Memory.Read<int>(Player.BaseClient + Offsets.dwGlowObjectManager);

        }

        public static void Shoot(int delay) // Makes the player shoot a bullet
        {
            Thread.Sleep(delay);
            Memory.Write<int>(Player.ForceAttack, 1);
            Thread.Sleep(10);
            Memory.Write<int>(Player.ForceAttack, 4);
        }

        public static bool IsScoped() // Return is the player is scoped
        {
            return Memory.Read<bool>(Player.LocalPlayer + Offsets.m_bIsScoped);
        }

        public static void ApplySkin(int weapInt, int skinId, int killstreakNum) // Apply the skin
        {
            Memory.Write(weapInt + Offsets.m_iItemIDHigh, 1);
            Memory.Write(weapInt + Offsets.m_nFallbackPaintKit, skinId);        // Skin ID
            Memory.Write(weapInt + Offsets.m_nFallbackStatTrak, killstreakNum); // Kill streak number
            Memory.Write(weapInt + Offsets.m_nFallbackSeed, 12);                // Seed
            Memory.Write(weapInt + Offsets.m_flFallbackWear, 0f);               // Float value

        }

    }
}
