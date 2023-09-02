using System;
using System.Reflection;
using DegradationOfLife.Content.Features.InfiniteBuffs;
using JetBrains.Annotations;
using Terraria.ModLoader;

namespace DegradationOfLife;

[UsedImplicitly(ImplicitUseKindFlags.InstantiatedWithFixedConstructorSignature)]
public sealed class DoLMod : Mod {
    public override object? Call(params object?[] args) {
        var command = ExpectCallArg<string>(0, args).ToLower();

        switch (command) {
            case "addbuffdebufmap": {
                var buffId = ExpectCallArg<int>(1, args);
                var debuffId = ExpectCallArg<int>(2, args);
                ModContent.GetInstance<BuffDebuffMap>().AddDebuff(buffId, debuffId);
                break;
            }
        }

        return base.Call(args);
    }

    private static T ExpectCallArg<T>(int index, object?[] args) {
        if (args.Length <= index)
            throw new TargetParameterCountException();

        if (args[index] is not T obj)
            throw new InvalidCastException();

        return obj;
    }
}
