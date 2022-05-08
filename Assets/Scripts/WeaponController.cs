﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using Utils;

public class WeaponController : MonoBehaviour
{
    [SerializeField] public bool _isForPlayer = false;
    [SerializeField] private WeaponNavigationScreen _navigationScreen = null;
    [SerializeField] private List<Weapon> _attachedWeapons = null;
    
    private const string Fire1 = "Fire1";
    private const string Fire2 = "Fire2";
    
    private const int FirstWeapon = 0;
    private const int SecondWeapon = 1;

    private void OnNewTarget(Transform target)
    {
        INavigational cachedWeapon = null;
        
        foreach (Weapon weapon in _attachedWeapons)
        {
            cachedWeapon = weapon as INavigational;

            if (cachedWeapon != null)
            {
                cachedWeapon.SetTarget(target);
            }
        }
    }

    private void OnEnable()
    {
        _navigationScreen.OnNewTarget += OnNewTarget;
    }

    private void Update()
    {
        if (_isForPlayer)
        {
            if (_attachedWeapons[FirstWeapon].GetPlayerInput(Fire1))
            {
                _attachedWeapons[FirstWeapon].FireIfPossible();
            }
        
            if (PlayerUtils.SecondWeaponIsAvailable && _attachedWeapons[SecondWeapon].GetPlayerInput(Fire2))
            {
                _attachedWeapons[SecondWeapon].FireIfPossible();
            }
        }

        
    }
    
    private void OnDisable()
    {
        _navigationScreen.OnNewTarget -= OnNewTarget;
    }
}

