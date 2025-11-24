using Verse;

namespace HoldTheGrenades
{
    public static class FireAtWillTool
    {
        public static void SetFireAtWill(Pawn pawn)
        {
            if (pawn.Drafted)
            {
                if (HoldTheGrenadesSettings.NoFireAtWill.Contains(pawn.equipment?.Primary?.def))             
                {
                    pawn.drafter.FireAtWill = false;
                }
            }
        }
    }
}
