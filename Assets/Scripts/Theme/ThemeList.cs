using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeList : MonoBehaviour
{
    [SerializeField] private ThemeScene _themeScene;

    private ThemeGroup[] _themeList;
    private ThemeDatabase _themeDataBase;
    private void Start()
    {
        _themeDataBase = ThemeDatabase.Instance;

        _themeList = _themeDataBase.GetThemeList();
        _themeScene.SetThemeList(this);

        foreach(ThemeGroup item in _themeList)
        {
            _themeScene.AddingButton(item);
        }
    }

    public bool BuyTheme(string name)
    {
        return _themeDataBase.BuyTheme(name);
    }
}
