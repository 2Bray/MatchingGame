using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ThemeGroup
{
    public string Code;
    public ThemeElement[] Element;
    [SerializeField] private int _price;
    public int Price() => _price;

    private bool _isUnlock = false;

    public bool IsUnlock() => _isUnlock;
    public void SetUnlock() => _isUnlock = true;

}

[Serializable]
public class ThemeElement
{
    public string Id;
    public Sprite Sprite;
}
