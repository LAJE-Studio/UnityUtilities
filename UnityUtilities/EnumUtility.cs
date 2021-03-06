﻿using System;

namespace UnityUtilities {
    public static class EnumUtility {
        public static bool IsSet(this int enumeration, int mask) {
            return (enumeration & mask) == mask;
        }

        public static bool IsSet(this byte enumeration, byte mask) {
            return (enumeration & mask) == mask;
        }
    }
}