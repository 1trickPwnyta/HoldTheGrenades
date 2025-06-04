using HarmonyLib;
using RimWorld;

namespace HoldTheGrenades
{
    [HarmonyPatch(typeof(Pawn_DraftController))]
    [HarmonyPatch("set_Drafted")]
    public static class Patch_Pawn_DraftController
    {
        public static void Postfix(Pawn_DraftController __instance)
        {
            FireAtWillTool.SetFireAtWill(__instance.pawn);
        }
    }
}
