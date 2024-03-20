using HarmonyLib;
using RimWorld;
using System.Reflection;

namespace HoldTheGrenades
{
    public static class Refs
    {
        public static FieldInfo f_Pawn_DraftController_pawn = AccessTools.Field(typeof(Pawn_DraftController), "pawn");

        public static MethodInfo m_Pawn_DraftController_set_Drafted = AccessTools.Method(typeof(Pawn_DraftController), "set_Drafted");
        public static MethodInfo m_FireAtWillTool_SetFireAtWill = AccessTools.Method(typeof(FireAtWillTool), "SetFireAtWill");
    }
}
