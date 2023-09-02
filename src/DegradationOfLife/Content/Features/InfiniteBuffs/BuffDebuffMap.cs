using System;
using System.Collections.Generic;
using DegradationOfLife.Content.Features.InfiniteBuffs.Buffs;
using JetBrains.Annotations;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DegradationOfLife.Content.Features.InfiniteBuffs;

[UsedImplicitly(ImplicitUseKindFlags.InstantiatedWithFixedConstructorSignature)]
internal sealed class BuffDebuffMap : ModSystem {
    private readonly Dictionary<int, int> buffDebuffMap = new();

    public override void Load() {
        base.Load();

        void CreateDebuff(int buffId, FunctionalInfiniteBuff.UpdateDelegate update) {
            var buff = new FunctionalInfiniteBuff(buffId, update);
            Mod.AddContent(buff);
            AddDebuff(buffId, buff.Type);
        }

        CreateDebuff(
            BuffID.ObsidianSkin,
            (Player player, ref int index) => {
                player.lavaImmune = false;
                player.fireWalk = false;
                player.buffImmune[BuffID.OnFire] = false;
                // TODO: effect?
            }
        );

        CreateDebuff(
            BuffID.Regeneration,
            (Player player, ref int _) => {
                player.lifeRegen /= 2;
            }
        );

        CreateDebuff(
            BuffID.Swiftness,
            (Player player, ref int _) => {
                player.moveSpeed -= 0.25f;
            }
        );

        CreateDebuff(
            BuffID.Swiftness,
            (Player player, ref int _) => {
                player.gills = false;
                // TODO: drown faster
            }
        );

        CreateDebuff(
            BuffID.Ironskin,
            (Player player, ref int _) => {
                player.statDefense -= 8;
            }
        );

        CreateDebuff(
            BuffID.ManaRegeneration,
            (Player player, ref int _) => {
                player.manaRegenBuff = false;
                player.manaRegen = (int)(player.manaRegen * 0.1f);
            }
        );

        CreateDebuff(
            BuffID.MagicPower,
            (Player player, ref int _) => {
                player.GetDamage<MagicDamageClass>() *= 0.8f;
            }
        );

        CreateDebuff(
            BuffID.Featherfall,
            (Player player, ref int _) => {
                player.slowFall = false;
                // TODO: artifact of glass
            }
        );

        CreateDebuff(
            BuffID.Spelunker,
            (Player player, ref int _) => {
                player.findTreasure = false;
                // TODO: effect?
            }
        );

        CreateDebuff(
            BuffID.Spelunker,
            (Player player, ref int _) => {
                player.invis = false;
                player.aggro += 400;
            }
        );

        CreateDebuff(
            BuffID.Shine,
            (Player player, ref int _) => {
                // TODO: dim lighting around the player significantly
            }
        );

        CreateDebuff(
            BuffID.NightOwl,
            (Player player, ref int _) => {
                player.nightVision = false;
                player.blind = true;
            }
        );

        CreateDebuff(
            BuffID.Battle,
            (Player player, ref int _) => {
                player.calmed = true;
            }
        );

        CreateDebuff(
            BuffID.Thorns,
            (Player player, ref int _) => {
                player.thorns = 0f;
                // TODO: dealing damage to enemies damages you
            }
        );

        CreateDebuff(
            BuffID.Thorns,
            (Player player, ref int _) => {
                player.waterWalk = false;
                // TODO: can't jump in water
            }
        );

        CreateDebuff(
            BuffID.Archery,
            (Player player, ref int _) => {
                player.archery = false;
                player.GetDamage<RangedDamageClass>() *= 0.8f;
            }
        );

        CreateDebuff(
            BuffID.Hunter,
            (Player player, ref int _) => {
                player.detectCreature = false;
                // TODO: dim all npcs
            }
        );

        CreateDebuff(
            BuffID.Gravitation,
            (Player player, ref int _) => {
                player.gravControl = false;
                // TODO: flips randomly
            }
        );

        CreateDebuff(
            BuffID.Tipsy,
            (Player player, ref int _) => {
                player.tipsy = false;
                player.statDefense -= 4;
            }
        );

        CreateDebuff(
            BuffID.WellFed,
            (Player player, ref int _) => {
                player.wellFed = false;
                // TODO: NeutralHunger
            }
        );

        CreateDebuff(
            BuffID.Mining,
            (Player player, ref int _) => {
                player.pickSpeed += 0.25f;
            }
        );

        CreateDebuff(
            BuffID.Heartreach,
            (Player player, ref int _) => {
                player.lifeMagnet = false;
                // TODO: decrease range
            }
        );

        CreateDebuff(
            BuffID.Calm,
            (Player player, ref int _) => {
                player.enemySpawns = true;
            }
        );

        CreateDebuff(
            BuffID.Builder,
            (Player player, ref int _) => {
                player.noBuilding = true;
            }
        );

        CreateDebuff(
            BuffID.Builder,
            (Player player, ref int _) => {
                player.kbBuff = false;
                // TODO: reduced kb
            }
        );

        CreateDebuff(
            BuffID.Flipper,
            (Player player, ref int _) => {
                player.ignoreWater = false;
                player.accFlipper = false;
                // TODO: increased water slow-down
            }
        );

        CreateDebuff(
            BuffID.Summoning,
            (Player player, ref int _) => {
                player.maxMinions--;
            }
        );

        CreateDebuff(
            BuffID.Dangersense,
            (Player player, ref int _) => {
                player.dangerSense = false;
                // TODO: make dangerous tiles invisible
            }
        );

        CreateDebuff(
            BuffID.AmmoReservation,
            (Player player, ref int _) => {
                player.ammoPotion = false;
                // TODO: 20% chance to use extra ammo
            }
        );

        CreateDebuff(
            BuffID.Lifeforce,
            (Player player, ref int _) => {
                player.lifeForce = false;
                player.statLifeMax2 -= Math.Max(100, player.statLifeMax / 5 / 20 * 20);
            }
        );

        CreateDebuff(
            BuffID.Endurance,
            (Player player, ref int _) => {
                player.endurance -= 0.1f;
            }
        );

        CreateDebuff(
            BuffID.Rage,
            (Player player, ref int _) => {
                player.GetCritChance<MeleeDamageClass>() -= 10;
                player.GetCritChance<RangedDamageClass>() -= 10;
                player.GetCritChance<MagicDamageClass>() -= 10;
                // TODO: negative critical chance can heal enemies
            }
        );

        CreateDebuff(
            BuffID.Inferno,
            (Player player, ref int _) => {
                player.onFire = true;
                // TODO: burn townies
            }
        );

        CreateDebuff(
            BuffID.Wrath,
            (Player player, ref int _) => {
                player.GetDamage<GenericDamageClass>() *= 0.9f;
            }
        );

        CreateDebuff(
            BuffID.Fishing,
            (Player player, ref int _) => {
                player.fishingSkill -= 15;
            }
        );

        CreateDebuff(
            BuffID.Sonar,
            (Player player, ref int _) => {
                player.sonarPotion = false;
                // TODO: lie to the player
            }
        );

        CreateDebuff(
            BuffID.Crate,
            (Player player, ref int _) => {
                player.cratePotion = false;
                // TODO: increase chance of getting trash instead
            }
        );

        CreateDebuff(
            BuffID.Warmth,
            (Player player, ref int _) => {
                player.resistCold = false;
                player.frozen = true;
            }
        );

        CreateDebuff(
            BuffID.WellFed2,
            (Player player, ref int _) => {
                player.wellFed = false;
                // TODO: Hunger
            }
        );

        CreateDebuff(
            BuffID.WellFed3,
            (Player player, ref int _) => {
                player.wellFed = false;
                // TODO: Starving
            }
        );

        CreateDebuff(
            BuffID.Lucky,
            (Player player, ref int _) => {
                player.luckPotion = 0;
                // TODO: constant torch god fight
            }
        );
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
