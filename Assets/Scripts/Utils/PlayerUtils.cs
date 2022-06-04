﻿using System.Collections.Generic;
using Entities;
using UnityEditor;

namespace Utils
{
    public static class PlayerUtils
    {
        public static bool SecondWeaponIsAvailable = true;

        public static EquipmentItemType FirstWeapon { get; private set; } = EquipmentItemType.NONE;
        public static EquipmentItemType SecondWeapon { get; private set; } = EquipmentItemType.NONE;
        public static EquipmentItemType Protection { get; private set; } = EquipmentItemType.NONE;
        
        public static int MaxHealth { get; set; } = 0;

        public static void SetEquipment(EquipmentItemType firstWeapon, EquipmentItemType secondWeapon, EquipmentItemType protection)
        {
            FirstWeapon = firstWeapon;
            SecondWeapon = secondWeapon;
            Protection = protection;
        }
        
        
        

    }
}