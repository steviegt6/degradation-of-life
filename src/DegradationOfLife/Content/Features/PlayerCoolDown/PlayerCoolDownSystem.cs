using JetBrains.Annotations;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace DegradationOfLife.Content.Features.PlayerCoolDown;

[UsedImplicitly(ImplicitUseKindFlags.InstantiatedWithFixedConstructorSignature)]
internal sealed class PlayerCoolDownSystem : ModSystem {
    public override void Load() {
        base.Load();

        On_Player.KillMe += AdjustRespawnConditionsForPlayerComfort;
        On_Player.UpdateDead += UpdateAdjustedRespawnTimer;
    }

    private static void AdjustRespawnConditionsForPlayerComfort(On_Player.orig_KillMe orig, Player self, PlayerDeathReason damageSource, double dmg, int hitDirection, bool pvp) {
        orig(self, damageSource, dmg, hitDirection, pvp);

        // Give the player some time to cool down.
        self.respawnTimer *= 5;
    }

    private static void UpdateAdjustedRespawnTimer(On_Player.orig_UpdateDead orig, Player self) {
        var respawnTimer = self.respawnTimer;
        orig(self);
        self.respawnTimer = --respawnTimer;
    }
}
