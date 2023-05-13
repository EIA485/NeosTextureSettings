﻿using NeosModLoader;
using System.Reflection;
using FrooxEngine;

namespace NeosTextureSettings
{
    public enum TextureLimit
    {
        Unlimited,
        _128 = 128,
        _256 = 256,
        _512 = 512,
        _1024 = 1024,
        _2048 = 2048,
        _4096 = 4096,
    }

    public class Config
    {
        internal static ModConfiguration _config;

        public static ref ModConfiguration Fetch() => ref _config;

        public static T GetValue<T>(ModConfigurationKey<T> key)
        {
            return _config.GetValue(key);
        }

        public static bool IsAndroid()
        {
            return Engine.Current.SystemInfo.Platform == Platform.Android;
        }

        public static TextureLimit DefaultSizeForPlatform()
        {
            if (IsAndroid()) return TextureLimit._512;
            else return TextureLimit.Unlimited;
        }

        public static string GetMasterLimitDesc()
        {
            string description = "Master Texture Limit";

            TextureLimit plat_limit = DefaultSizeForPlatform();
            if (plat_limit != TextureLimit.Unlimited)
            {
                description += string.Format(" (Default: {0})", (int)plat_limit);
            }
            return description;
        }
    }
}
