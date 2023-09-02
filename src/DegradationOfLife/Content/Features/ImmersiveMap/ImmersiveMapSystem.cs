using JetBrains.Annotations;
using Terraria.Map;
using Terraria.ModLoader;

namespace DegradationOfLife.Content.Features.ImmersiveMap;

[UsedImplicitly(ImplicitUseKindFlags.InstantiatedWithFixedConstructorSignature)]
internal sealed class ImmersiveMapSystem : ModSystem {
    public override void Load() {
        base.Load();

        On_WorldMap.UpdateLighting += ImmersivelyUpdateLighting;
    }

    private static bool ImmersivelyUpdateLighting(On_WorldMap.orig_UpdateLighting orig, WorldMap self, int x, int y, byte light) {
        var other = self[x, y];
        if (light == 0 && other.Light == 0)
            return false;

        var tile = MapHelper.CreateMapTile(x, y, light);
        if (tile.Equals(ref other))
            return false;

        self.SetTile(x, y, ref tile);
        return true;
    }
}
