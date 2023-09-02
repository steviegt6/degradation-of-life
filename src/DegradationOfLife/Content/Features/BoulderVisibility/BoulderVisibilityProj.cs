using System;
using JetBrains.Annotations;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DegradationOfLife.Content.Features.BoulderVisibility;

[UsedImplicitly(ImplicitUseKindFlags.InstantiatedWithFixedConstructorSignature)]
internal sealed class BoulderVisibilityProj : GlobalProjectile {
    public override void AI(Projectile projectile) {
        base.AI(projectile);

        if (projectile.type is not (ProjectileID.Boulder or ProjectileID.BouncyBoulder or ProjectileID.MiniBoulder or ProjectileID.MoonBoulder or ProjectileID.LifeCrystalBoulder))
            return;

        Lighting.AddLight(projectile.Center, Color.White.ToVector3());

        for (var i = 0; i < 360; i++) {
            var angle = MathHelper.ToRadians(i);
            var vector = new Vector2((float) Math.Cos(angle), (float) Math.Sin(angle));

            for (var j = 0; j < 64; j++)
                Lighting.AddLight(projectile.Center + vector * j * 16f, Color.White.ToVector3());
        }
    }
}
