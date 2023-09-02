using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DegradationOfLife.Content.Features.EntityClutterOptimizer;

public sealed class CoinLossRemoverClutterOptimizerSystem : ModSystem {
    public override void Load() {
        base.Load();

        On_Player.DropCoins += DontDropCoinsOnGround;
    }

    private static long DontDropCoinsOnGround(On_Player.orig_DropCoins orig, Player self) {
        var coins = 0L;

        for (var i = 0; i < 59; i++) {
            var item = self.inventory[i];

            if (!item.IsACoin)
                continue;

            var amount = item.stack / 2;

            if (Main.expertMode)
                amount = (int)(item.stack * 0.25f);

            if (Main.masterMode)
                amount = 0;

            amount = item.stack - amount;
            item.stack -= amount;

            switch (item.type) {
                case ItemID.CopperCoin:
                    coins += amount;
                    break;

                case ItemID.SilverCoin:
                    coins += amount * 100;
                    break;

                case ItemID.GoldCoin:
                    coins += amount * 10000;
                    break;

                case ItemID.PlatinumCoin:
                    coins += amount * 1000000;
                    break;
            }

            if (item.stack <= 0)
                item.TurnToAir();

            if (i == 58)
                Main.mouseItem = item.Clone();
        }

        self.lostCoins = coins;
        self.lostCoinString = Main.ValueToCoins(coins);
        return coins;
    }
}
