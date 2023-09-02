using JetBrains.Annotations;
using Terraria;
using Terraria.ModLoader;

namespace DegradationOfLife.Content.Features.WoFLootAccessibility;

[UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
public sealed class WoFLootAccessibilitySystem : ModSystem {
    public override void Load() {
        base.Load();

        On_NPC.CreateBrickBoxForWallOfFlesh += CreateAccessibleBrickBox;
    }

    private static void CreateAccessibleBrickBox(On_NPC.orig_CreateBrickBoxForWallOfFlesh orig, NPC self) { }
}
