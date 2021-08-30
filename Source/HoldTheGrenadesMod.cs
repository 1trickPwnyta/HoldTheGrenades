using Verse;
using HarmonyLib;

namespace HoldTheGrenades
{
    public class HoldTheGrenadesMod : Mod
    {
        public const string PACKAGE_ID = "holdthegrenades.1trickPonyta";
        public const string PACKAGE_NAME = "Hold the Grenades";

        public HoldTheGrenadesMod(ModContentPack content) : base(content)
        {
            var harmony = new Harmony(PACKAGE_ID);
            harmony.PatchAll();

            Log.Message($"[{PACKAGE_NAME}] Loaded.");
        }
    }
}
