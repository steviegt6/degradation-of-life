using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace DegradationOfLife.Content.Features.InfiniteBuffs.Buffs;

internal abstract class AbstractInfiniteBuff : ModBuff {
    public override LocalizedText DisplayName => GetBuffName(VanillaBuffEquivalent);

    public override LocalizedText Description => GetBuffDescription(VanillaBuffEquivalent);

    public override string Texture => "Terraria/Buff_" + VanillaBuffEquivalent;

    protected abstract int VanillaBuffEquivalent { get; }

    private static LocalizedText GetBuffName(int buffId) {
        if (buffId >= BuffID.Count)
            return BuffLoader.GetBuff(buffId).DisplayName;

        return Language.GetText($"BuffName.{BuffID.Search.GetName(buffId)}");
    }

    private static LocalizedText GetBuffDescription(int buffId) {
        if (buffId >= BuffID.Count)
            return BuffLoader.GetBuff(buffId).Description;

        return Language.GetText($"BuffDescription.{BuffID.Search.GetName(buffId)}");
    }
}
