using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeDatabase : MonoBehaviour
{
    private static ThemeDatabase _instance = null;
    public static ThemeDatabase Instance { get => _instance; }

    [SerializeField] private ThemeGroup[] _themeList;

    private Currency _currency;
    private PlayerData _data;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else if (_instance == null)
        {
            _instance = this;
            _currency = Currency.Instance;
            _data = PlayerData.Instance;
            

            foreach (string code in _data.GetThemeUnlock())
            {
                foreach (ThemeGroup item in _themeList)
                {
                    if (code == item.Code)
                    {
                        item.SetUnlock();
                        break;
                    }
                }
            }

            DontDestroyOnLoad(gameObject);
        }
    }

    public ThemeGroup[] GetThemeList() => _themeList;

    public ThemeGroup GetCurrentTheme(){
        string currentTheme = _data.GetCurrentTheme();

        foreach(ThemeGroup item in _themeList)
        {
            if (currentTheme == item.Code) return item;
        }

        return null;
    }

    public bool BuyTheme(string name)
    {
        foreach(ThemeGroup item in _themeList)
        {
            if (item.Code == name)
            {
                if (item.IsUnlock())
                {
                    _data.SaveCurrentTheme(item.Code);
                    return true;
                }
                else if (_currency.Gold >= item.Price())
                {
                    _currency.UpdateGold(-item.Price());
                    SaveDataUnlock();
                    return true;
                }
                else
                    return false;
            }
        }

        return false;
    }

    private void SaveDataUnlock()
    {
        List<string> data = new List<string>();

        foreach (ThemeGroup item in _themeList)
        {
            if (item.IsUnlock())
            {
                data.Add(item.Code);
            }
        }

        _data.SaveThemeUnlock(data.ToArray());
    }
}