
using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace SpawnForMe
{
	// Token: 0x020000CC RID: 204
	public class CompCentipedeSpawner : ThingComp
	{
		// Token: 0x06000254 RID: 596 RVA: 0x00018554 File Offset: 0x00016754
		public override void CompTick()
		{
			this.CheckShouldSpawn();
		}

		// Token: 0x06000255 RID: 597 RVA: 0x00018560 File Offset: 0x00016760
		private void CheckShouldSpawn()
		{
			this.SpawnMe();
			this.parent.Destroy(0);
		}

		// Token: 0x06000256 RID: 598 RVA: 0x00018588 File Offset: 0x00016788
		public void SpawnMe()
		{
			PawnKindDef pawnKindDef = PawnKindDef.Named("Mech_Centipede");

			PawnGenerationRequest req = new PawnGenerationRequest(pawnKindDef, Faction.OfPlayer);
			Pawn pawn  = PawnGenerator.GeneratePawn(req);
			GenSpawn.Spawn(pawn, this.parent.Position, this.parent.Map, 0);
		}

	}

}
	





