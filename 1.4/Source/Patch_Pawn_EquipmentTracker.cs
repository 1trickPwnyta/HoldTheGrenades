using HarmonyLib;
using Verse;

namespace HoldTheGrenades
{
    [HarmonyPatch(typeof(Pawn_EquipmentTracker))]
    [HarmonyPatch("Notify_EquipmentAdded")]
    public static class Patch_Pawn_EquipmentTracker_Notify_EquipmentAdded
    {
        public static void Postfix(Pawn_EquipmentTracker __instance) 
        {
            FireAtWillTool.SetFireAtWill(__instance.pawn);
        }
    }
}
