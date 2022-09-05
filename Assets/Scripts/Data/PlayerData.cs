using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    private static PlayerData _instance;
    public static PlayerData Instance { get {
            if (_instance == null)
            {
                _instance = new PlayerData();
                _instance.LoadData();
            }

            return _instance; 
        } 
    }

    private DataPlayer _dataPlayer;

    public int GetGold() => _dataPlayer.Gold;
    public void SaveGold(int gold)
    {
        _dataPlayer.Gold = gold;
        SaveData();
    }

    public string GetCurrentTheme() => _dataPlayer.CurrentTheme;
    public void SaveCurrentTheme(string themeName)
    {
        _dataPlayer.CurrentTheme = themeName;
        SaveData();
    }

    public string[] GetThemeUnlock() => _dataPlayer.ThemesUnlock;
    public void SaveThemeUnlock(string[] code)
    {
        _dataPlayer.ThemesUnlock = code;
        SaveData();
    }

    private void SaveData()
    {
        DataPlayer saveData = new DataPlayer(_dataPlayer);
        PlayerPrefs.SetString("PlayerData", JsonUtility.ToJson(saveData));
    }

    private void LoadData()
    {
        string json = PlayerPrefs.GetString("PlayerData");
        if (string.IsNullOrWhiteSpace(json))
            _dataPlayer = new DataPlayer();
        else
            _dataPlayer = JsonUtility.FromJson<DataPlayer>(json);

        _dataPlayer.loadData = true;
    }
}

[Serializable]
public class DataPlayer
{
    public int Gold = 0;
    public string CurrentTheme = "Fruit";
    public string[] ThemesUnlock = new string[] { "Fruit", "Food" };

    public bool loadData = false;


    public DataPlayer(DataPlayer data)
    {
        Gold = data.Gold;
        CurrentTheme = data.CurrentTheme;
        ThemesUnlock = data.ThemesUnlock;

        loadData = false;
    }

    public DataPlayer() { }
}