using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Terraria.ID;
using Terraria.ModLoader;

namespace DegradationOfLife.Content.Features.InfiniteBuffs;

[UsedImplicitly(ImplicitUseKindFlags.InstantiatedWithFixedConstructorSignature)]
internal sealed class BuffDebuffMap : ModSystem {
    private readonly Dictionary<int, int> buffDebuffMap = new();

    public override void Load() {
        base.Load();

        AddDebuff(BuffID.ObsidianSkin, -1); // TODO: effect?
        AddDebuff(BuffID.Regeneration, -1); // TODO: halves player regeneration
        AddDebuff(BuffID.Swiftness, -1); // TODO: decrease movement speed by 15%
        AddDebuff(BuffID.Gills, -1); // TODO: drown faster
        AddDebuff(BuffID.Ironskin, -1); // TODO: reduced defense (or dr?)
        AddDebuff(BuffID.ManaRegeneration, -1); // TODO: halves mana regeneration
        AddDebuff(BuffID.MagicPower, -1); // TODO: decreases magic damage by 10%
        AddDebuff(BuffID.Featherfall, -1); // TODO: artifact of glass
        AddDebuff(BuffID.Spelunker, -1); // TODO: effect?
        AddDebuff(BuffID.Invisibility, -1); // TODO: increased aggro
        AddDebuff(BuffID.Shine, -1); // TODO: dim lighting around the player significantly
        AddDebuff(BuffID.NightOwl, -1); // TODO: blindness
        AddDebuff(BuffID.Battle, -1); // TODO: calm
        AddDebuff(BuffID.Thorns, -1); // TODO: dealing damage to enemies damages you
        AddDebuff(BuffID.WaterWalking, -1); // TODO: can't jump in water
        AddDebuff(BuffID.Archery, -1); // TODO: decrease damage by 10%
        AddDebuff(BuffID.Hunter, -1); // TODO: dim all npcs
        AddDebuff(BuffID.Gravitation, -1); // TODO: flips randomly
        AddDebuff(BuffID.Tipsy, -1); // TODO: only -4 defense
        AddDebuff(BuffID.WellFed, BuffID.NeutralHunger);
        AddDebuff(BuffID.Mining, -1); // TODO: mine slower
        AddDebuff(BuffID.Heartreach, -1); // TODO: decrease range
        AddDebuff(BuffID.Calm, -1); // TODO: battle
        AddDebuff(BuffID.Builder, BuffID.NoBuilding);
        AddDebuff(BuffID.Titan, -1); // TODO: reduced kb
        AddDebuff(BuffID.Flipper, -1); // TODO: increased water slow-down
        AddDebuff(BuffID.Summoning, -1); // TODO: -1 minion slot
        AddDebuff(BuffID.Dangersense, -1); // TODO: make dangerous tiles invisible
        AddDebuff(BuffID.AmmoReservation, -1); // TODO: 20% chance to use extra ammo
        AddDebuff(BuffID.Lifeforce, -1); // TODO: Math.Max(-100, health * .2), kills player at 100 hp
        AddDebuff(BuffID.Endurance, -1); // TODO: -10% dr
        AddDebuff(BuffID.Rage, -1); // TODO: -10% critical chance; negative critical chance can heal enemies
        AddDebuff(BuffID.Inferno, BuffID.OnFire /*3*/);
        AddDebuff(BuffID.Wrath, -1); // TODO: -10% damage
        AddDebuff(BuffID.Fishing, -1); // TODO: -15 fishing power
        AddDebuff(BuffID.Sonar, -1); // TODO: lie to the player
        AddDebuff(BuffID.Crate, -1); // TODO: increase chance of getting trash instead
        AddDebuff(BuffID.Warmth, BuffID.Frozen);
        AddDebuff(BuffID.WellFed2, BuffID.Hunger);
        AddDebuff(BuffID.WellFed3, BuffID.Starving);
        AddDebuff(BuffID.Lucky, -1); // TODO: constant torch god fight
    }

    public void AddDebuff(int buffType, int debuffType) {
        if (debuffType == -1)
            return; // no-op; just for code consistency above

        if (buffType < 0 || buffType > BuffLoader.BuffCount)
            throw new ArgumentOutOfRangeException(nameof(buffType));

        if ( /*debuffType < 0 ||*/ debuffType > BuffLoader.BuffCount)
            throw new ArgumentOutOfRangeException(nameof(debuffType));

        buffDebuffMap[buffType] = debuffType;
    }

    public int? GetDebuffFromBuff(int buffType) {
        return buffDebuffMap.TryGetValue(buffType, out var debuffType) ? debuffType : null;
    }
}
