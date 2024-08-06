using Verse;

namespace HoldTheGrenades
{
    public static class FireAtWillTool
    {
        public static void SetFireAtWill(Pawn pawn)
        {
            if (pawn.Drafted)
            {
                if (pawn.equipment.Primary.def.Verbs.Any((v) => v.defaultProjectile != null && v.defaultProjectile.projectile.explosionRadius > 0.1f))             
                {
                    pawn.drafter.FireAtWill = false;
                }
            }
        }
    }
}
