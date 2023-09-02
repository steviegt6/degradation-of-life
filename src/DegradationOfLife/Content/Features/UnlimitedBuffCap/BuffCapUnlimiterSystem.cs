using JetBrains.Annotations;
using Terraria;
using Terraria.ModLoader;

namespace DegradationOfLife.Content.Features.UnlimitedBuffCap;

[UsedImplicitly(ImplicitUseKindFlags.InstantiatedWithFixedConstructorSignature)]
internal sealed class BuffCapUnlimiterSystem : ModSystem {
    public override void Load() {
        base.Load();

        On_Player.AddBuff += AddUnlimitedBuffs;
    }

    private static void AddUnlimitedBuffs(On_Player.orig_AddBuff orig, Player self, int type, int timeToAdd, bool quiet, bool foodHack) {
        var buffCount = 0;

        for (var i = 0; i < Player.MaxBuffs; i++) {
            var theType = self.buffType[i];
            if (theType == 0)
                continue;

            if (!Main.debuff[theType])
                buffCount++;
        }

        if (!Main.debuff[type] && buffCount >= 5)
            return;

        orig(self, type, timeToAdd, quiet, foodHack);
    }
}
