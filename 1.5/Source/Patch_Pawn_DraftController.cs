using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Verse;

namespace HoldTheGrenades
{
    [HarmonyPatch(typeof(Pawn_DraftController))]
    [HarmonyPatch("<GetGizmos>b__15_1")]
    public static class Patch_Pawn_DraftController_GetGizmos_delegate_1
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) 
        {
            foreach (CodeInstruction instruction in instructions)
            {
                if (instruction.opcode == OpCodes.Call && (MethodInfo)instruction.operand == Refs.m_Pawn_DraftController_set_Drafted)
                {
                    yield return instruction;
                    yield return new CodeInstruction(OpCodes.Ldarg_0);
                    yield return new CodeInstruction(OpCodes.Ldfld, Refs.f_Pawn_DraftController_pawn);
                    yield return new CodeInstruction(OpCodes.Call, Refs.m_FireAtWillTool_SetFireAtWill);
                }
                else
                {
                    yield return instruction;
                }
            }
        }
    }
}
