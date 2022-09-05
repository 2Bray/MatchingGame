using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGroup : MonoBehaviour
{
    public Action TileCleared;

    private List<Tile> _tilePool;
    public List<Tile> GetTilePool() => _tilePool;

    private Tile LatestClicked = null;

    private ThemeGroup currentTheme;

    public void StartInit(List<Tile> tilePool)
    {
        currentTheme = ThemeDatabase.Instance.GetCurrentTheme();

        _tilePool = tilePool;

        RandomizeTile();
    }

    private void OnDisable()
    {
        foreach (Tile item in _tilePool)
        {
            item.TryMatchClickedTiles -= TryMatching;
        }
    }

    private void RandomizeTile()
    {
        int count = _tilePool.Count / 2;
        int[] idx = new int[count];

        for (int i=0; i<idx.Length; i++)
        {
            idx[i] = 2;
        }

        foreach (Tile item in _tilePool)
        {
            int r = 0;
            do
            {
                r = UnityEngine.Random.Range(0, count);
            }
            while (idx[r] <= 0);

            idx[r]--;
            item.SetId(currentTheme.Element[r]);
            item.TryMatchClickedTiles += TryMatching;
        }
    }

    private void TryMatching(Vector2Int pos)
    {
        Tile currentTile = _tilePool[pos.x + pos.y];
        Debug.Log(currentTile.GetId());
        if (LatestClicked == null)
            LatestClicked = currentTile;
        else
        {
            if (LatestClicked.GetId() == currentTile.GetId() && LatestClicked != currentTile)
            {
                RemoveTile(new Tile[] { LatestClicked, currentTile });
                LatestClicked = null;
            }
            else
                LatestClicked = currentTile;
        }
        
    }

    private void RemoveTile(Tile[] tiles)
    {
        foreach(Tile item in tiles)
        {
            item.gameObject.SetActive(false);
            _tilePool.Remove(item);
        }

        if (_tilePool.Count == 0) 
            TileCleared();
    }
}
