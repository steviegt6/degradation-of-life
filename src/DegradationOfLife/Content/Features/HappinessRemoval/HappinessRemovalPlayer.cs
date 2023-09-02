using JetBrains.Annotations;
using Terraria;
using Terraria.ModLoader;

namespace DegradationOfLife.Content.Features.HappinessRemoval;

[UsedImplicitly(ImplicitUseKindFlags.InstantiatedWithFixedConstructorSignature)]
internal sealed class HappinessRemovalPlayer : ModPlayer {
    private int timer;

    public override void Load() {
        base.Load();

        On_Main.OpenShop += ResetHappiness;
    }

    public override void PreUpdate() {
        base.PreUpdate();

        if (++timer % 4 == 0)
            Player.currentShoppingSettings.PriceAdjustment *= 1.005f;
    }

    private static void ResetHappiness(On_Main.orig_OpenShop orig, Main self, int shopIndex) {
        orig(self, shopIndex);
        Main.LocalPlayer.currentShoppingSettings.PriceAdjustment = 1f;
    }
}
