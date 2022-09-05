using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyThemeButton : MonoBehaviour
{
    private GameObject _price;
    private GameObject _check;
    private string _themeName;
    public string ThemeName() => _themeName;

    public void InitObject(ThemeGroup theme, Action<BuyThemeButton> OnClick)
    {
        _themeName = theme.Code;

        Button button = GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => OnClick(this));

        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = _themeName;
        _check = transform.GetChild(transform.childCount - 1).gameObject;
        _price = transform.GetChild(1).gameObject;

        _check.SetActive(_themeName == ThemeDatabase.Instance.GetCurrentTheme().Code);
        SetActivePrice(!theme.IsUnlock(), theme.Price());
    }

    public void SetCurrentTheme(bool b) => _check.SetActive(b);

    public void SetActivePrice(bool b, int price) { 
        _price.SetActive(b);
        _price.GetComponent<TextMeshProUGUI>().text = price.ToString();
    }
}
