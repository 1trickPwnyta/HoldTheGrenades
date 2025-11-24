using RimWorld;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Verse;

namespace HoldTheGrenades
{
    public class HoldTheGrenadesSettings : ModSettings
    {
        private static IEnumerable<ThingDef> RangedWeapons => DefDatabase<ThingDef>.AllDefsListForReading.Where(d => d.IsRangedWeapon);
        private static IEnumerable<ThingDef> DefaultNoFireAtWill => RangedWeapons.Where(d => d.Verbs?.Any((v) => (v.defaultProjectile != null && v.defaultProjectile.projectile.explosionRadius > 0.1f) || v.beamWidth > 1f) ?? false);

        public static HashSet<ThingDef> NoFireAtWill = DefaultNoFireAtWill.ToHashSet();

        private static Vector2 scrollPosition;
        private static float height;
        private static QuickSearchWidget search = new QuickSearchWidget();

        public static void DoSettingsWindowContents(Rect inRect)
        {
            Widgets.Label(inRect, "HoldTheGrenades_NoFireAtWill".Translate());
            search.OnGUI(inRect.TopPartPixels(24f).RightPartPixels(200f));
            
            Rect viewRect = new Rect(0f, 0f, inRect.width - 20f, height);
            Widgets.BeginScrollView(inRect.BottomPartPixels(inRect.height - 30f), ref scrollPosition, viewRect);

            bool shade = false;
            Rect weaponRect = new Rect(viewRect.x, viewRect.y, viewRect.width, 30f);
            foreach (ThingDef weapon in RangedWeapons.Where(w => search.filter.Matches(w.label)).OrderBy(w => w.label))
            {
                if (shade)
                {
                    Widgets.DrawRectFast(weaponRect, Widgets.MenuSectionBGFillColor);
                }
                shade = !shade;

                Rect rect = weaponRect;

                rect.width = rect.height;
                GUI.DrawTexture(rect.ContractedBy(2f), weapon.uiIcon);
                rect.x += rect.width;

                rect.width = weaponRect.width - rect.width;
                bool enabled = NoFireAtWill.Contains(weapon);
                Widgets.CheckboxLabeled(rect, weapon.LabelCap, ref enabled, paintable: true);
                if (enabled)
                {
                    NoFireAtWill.Add(weapon);
                }
                else
                {
                    NoFireAtWill.Remove(weapon);
                }

                weaponRect.y += weaponRect.height;
            }

            Widgets.EndScrollView();
            height = weaponRect.y;
        }

        public override void ExposeData()
        {
            Scribe_Collections.Look(ref NoFireAtWill, "NoFireAtWill", LookMode.Def);
            if (Scribe.mode == LoadSaveMode.PostLoadInit && NoFireAtWill == null)
            {
                NoFireAtWill = DefaultNoFireAtWill.ToHashSet();
            }
        }
    }
}