using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeScene : MonoBehaviour
{
    [SerializeField] private BuyThemeButton _button;
    [SerializeField] private Transform _buttonPanel;

    private ThemeList _themeList;
    private List<BuyThemeButton> _buttonList;

    public void SetThemeList(ThemeList themeList)
    {
        _themeList = themeList;
    }

    public void AddingButton(ThemeGroup theme)
    {
        if (_buttonList == null) _buttonList = new List<BuyThemeButton>();

        BuyThemeButton button = Instantiate(_button, _buttonPanel);
        button.InitObject(theme, ButtonOnClick);

        _buttonList.Add(button);
    }

    private void ButtonOnClick(BuyThemeButton button)
    {
        if (_themeList.BuyTheme(button.ThemeName()))
        {
            foreach(BuyThemeButton item in _buttonList)
            {
                item.SetCurrentTheme(false);
            }

            button.SetCurrentTheme(true);
            button.SetActivePrice(false, 0);
        }
    }
}
