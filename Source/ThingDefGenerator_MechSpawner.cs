using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace Mechanionjoin
{
	// Token: 0x02000880 RID: 2176
	[StaticConstructorOnStartup]
	public static class ThingDefGenerator_MechSpawner
	{
		// Token: 0x060035DF RID: 13791 RVA: 0x0012710B File Offset: 0x0012530B
		public static IEnumerable<ThingDef> ImpliedSpawnerDefs()
		{
			Log.Message("generating Engrams");
			foreach (PawnKindDef kindDef in DefDatabase<PawnKindDef>.AllDefs.ToList<PawnKindDef>())
			{
				if (kindDef.RaceProps.Humanlike)
				{
					continue;
				}
				if (!kindDef.RaceProps.IsMechanoid)
				{
					continue;
				}
				Log.Message("Mechanoid " + kindDef.LabelCap);
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
				Log.Message(thingDef2.defName + " generated");
				yield return thingDef2;
			}
			yield break;
		}
	}
}
