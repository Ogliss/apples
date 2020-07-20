using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using System.Threading.Tasks;
using Verse;
using System.Reflection;
using RimWorld;

namespace Mechanionjoin
{ 
    [StaticConstructorOnStartup]
    static class Main
    {
        static Main() 
        {
			foreach (PawnKindDef kindDef in DefDatabase<PawnKindDef>.AllDefs)
			{
				if (kindDef.RaceProps.Humanlike)
				{
					continue;
				}
				if (!kindDef.RaceProps.IsMechanoid)
				{
					continue;
				}
				Log.Message("Mechanoid ");
				ThingDef thingDef2 = new ThingDef();
				thingDef2.category = ThingCategory.Item;
				thingDef2.thingClass = typeof(ThingWithComps);
				thingDef2.selectable = true;
				thingDef2.tickerType = TickerType.Normal;
				thingDef2.altitudeLayer = AltitudeLayer.ItemImportant;
				thingDef2.scatterableOnMapGen = false;
				thingDef2.SetStatBaseValue(StatDefOf.Beauty, -4f);
				thingDef2.alwaysHaulable = true;
				thingDef2.soundDrop = SoundDefOf.Standard_Drop;
				thingDef2.pathCost = 15;
				thingDef2.socialPropernessMatters = false;
				thingDef2.tradeability = Tradeability.None;
				thingDef2.messageOnDeteriorateInStorage = false;
				thingDef2.comps.Add(new CompProperties_MechanoidSpawner(kindDef));
				thingDef2.defName = "MechanoidEngram_" + kindDef.defName;
				thingDef2.label = "MechanoidEngram_Label".Translate(kindDef.label);
				thingDef2.description = "MechanoidEngram_Desc".Translate(kindDef.label);
				thingDef2.SetStatBaseValue(StatDefOf.MarketValue, 2000);
				thingDef2.SetStatBaseValue(StatDefOf.Flammability, 0);
				thingDef2.SetStatBaseValue(StatDefOf.MaxHitPoints, 100);
				thingDef2.SetStatBaseValue(StatDefOf.WorkToMake, 10 * kindDef.combatPower);
				thingDef2.SetStatBaseValue(StatDefOf.Mass, 1);
				thingDef2.thingCategories = new List<ThingCategoryDef>();
				thingDef2.thingCategories.Add(ThingCategoryDefOf.Manufactured);
				thingDef2.tradeTags = new List<string>();
				thingDef2.tradeTags.Add("ExoticMisc");
				thingDef2.thingSetMakerTags = new List<string>(); ;
				thingDef2.thingSetMakerTags.Add("RewardStandardLowFreq");
				thingDef2.thingSetMakerTags.Add("RewardStandardQualitySuper");
				thingDef2.modContentPack = kindDef.modContentPack;
				Log.Message(" generated");
				DefDatabase<ThingDef>.Add(thingDef2);
			}
        }
    }
}
