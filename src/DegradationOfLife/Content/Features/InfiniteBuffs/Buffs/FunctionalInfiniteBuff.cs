using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DegradationOfLife.Content.Features.InfiniteBuffs.Buffs;

internal sealed class FunctionalInfiniteBuff : AbstractInfiniteBuff {
    public delegate void UpdateDelegate(Player player, ref int buffIndex);

    public override string Name => VanillaBuffEquivalent >= BuffID.Count ? BuffLoader.GetBuff(VanillaBuffEquivalent).Name : $"{BuffID.Search.GetName(VanillaBuffEquivalent)}";

    protected override int VanillaBuffEquivalent { get; }

    private readonly UpdateDelegate update;

    public FunctionalInfiniteBuff(int vanillaBuffEquivalent, UpdateDelegate update) {
        VanillaBuffEquivalent = vanillaBuffEquivalent;
        this.update = update;
    }

    public override void SetStaticDefaults() {
        base.SetStaticDefaults();

        Main.debuff[Type] = true;
    }

    public override void Update(Player player, ref int buffIndex) {
        base.Update(player, ref buffIndex);
        update?.Invoke(player, ref buffIndex);
    }
}
