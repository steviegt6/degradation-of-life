using System.Linq;
using JetBrains.Annotations;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DegradationOfLife.Content.Features.ConsistentMusic;

[UsedImplicitly(ImplicitUseKindFlags.InstantiatedWithFixedConstructorSignature)]
internal sealed class ConsistentBossMusicSceneEffect : ModSceneEffect {
    public override SceneEffectPriority Priority => SceneEffectPriority.BossHigh;

    public override int Music => MusicID.Boss1;

    public override float GetWeight(Player player) {
        return 1f;
    }

    public override bool IsSceneEffectActive(Player player) {
        return Main.npc.Any(x => x.active && (x.boss || NPCID.Sets.ShouldBeCountedAsBoss[x.type]));
    }
}

[UsedImplicitly(ImplicitUseKindFlags.InstantiatedWithFixedConstructorSignature)]
internal sealed class ConsistentBiomeMusicSceneEffect : ModSceneEffect {
    public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;

    public override int Music => MusicID.Eerie;

    public override float GetWeight(Player player) {
        return 1f;
    }

    public override bool IsSceneEffectActive(Player player) {
        return true;
    }
}
