using Verse;
using HarmonyLib;
using UnityEngine;

namespace HoldTheGrenades
{
    [StaticConstructorOnStartup]
    public static class HoldTheGrenadesInitializer
    {
        static HoldTheGrenadesInitializer()
        {
            HoldTheGrenadesMod.Settings = HoldTheGrenadesMod.Mod.GetSettings<HoldTheGrenadesSettings>();
        }
    }

    public class HoldTheGrenadesMod : Mod
    {
        public const string PACKAGE_ID = "holdthegrenades.1trickPonyta";
        public const string PACKAGE_NAME = "Hold the Grenades";

        public static HoldTheGrenadesMod Mod;
        public static HoldTheGrenadesSettings Settings;

        public HoldTheGrenadesMod(ModContentPack content) : base(content)
        {
            Mod = this;

            var harmony = new Harmony(PACKAGE_ID);
            harmony.PatchAll();

            Log.Message($"[{PACKAGE_NAME}] Loaded.");
        }

        public override string SettingsCategory() => PACKAGE_NAME;

        public override void DoSettingsWindowContents(Rect inRect)
        {
            base.DoSettingsWindowContents(inRect);
            HoldTheGrenadesSettings.DoSettingsWindowContents(inRect);
        }
    }
}
