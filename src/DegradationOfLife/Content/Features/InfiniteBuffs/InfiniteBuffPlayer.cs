using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Terraria.ID;
using Terraria.ModLoader;

namespace DoL.Content.Features.InfiniteBuffs;

[UsedImplicitly(ImplicitUseKindFlags.InstantiatedWithFixedConstructorSignature)]
internal sealed class InfiniteBuffPlayer : ModPlayer {
    public override void PreUpdateBuffs() {
        base.PreUpdateBuffs();

        var itemCounts = new Dictionary<int, int>();
        var items = Player.inventory.Concat(Player.bank.item).Concat(Player.bank2.item).Concat(Player.bank3.item).Concat(Player.bank4.item);

        foreach (var item in items) {
            if (itemCounts.ContainsKey(item.type))
                itemCounts[item.type] += item.stack;
            else
                itemCounts[item.type] = item.stack;
        }

        foreach (var (itemId, itemCount) in itemCounts) {
            if (itemCount < 30)
                continue;

            var debuff = ModContent.GetInstance<BuffDebuffMap>().GetDebuffFromBuff(ContentSamples.ItemsByType[itemId].buffType);
            if (!debuff.HasValue)
                continue;

            Player.AddBuff(debuff.Value, 2);
        }
    }
}
