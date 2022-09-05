using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Action<Vector2Int> TryMatchClickedTiles;

    private Vector2Int _pos;
    private string _id;

    public void InitObject(Vector2Int pos)
    {
        _pos = pos;
    }

    public void SetId(ThemeElement theme)
    {
        _id = theme.Id;
        Debug.Log(_id);
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = theme.Sprite;
    }

    public Vector2Int GetPos() => _pos;
    public string GetId() => _id;

    public void TileClicked() => TryMatchClickedTiles(_pos);
}
