using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePool : MonoBehaviour
{
    [SerializeField] private Tile _tileObject;
    [SerializeField] private Vector2Int _size;

    private List<Tile> _tilePool;

    public void StartInit()
    {
        _tilePool = new List<Tile>();

        Vector3 tilePosition = new Vector3(0, 0, transform.position.z);
        for (int x = 0; x < _size.x; x++)
        {
            for (int y = 0; y < _size.y; y++)
            {
                InstantiateNewOne(new Vector2Int(x, y), tilePosition);
                tilePosition.y += 1;
            }

            tilePosition.x += 1;
            tilePosition.y = 0;
        }


        Vector2 camPos = Vector2.Lerp(_tilePool[0].transform.position, _tilePool[^1].transform.position, 0.5f);
        Camera.main.transform.position = new Vector3(
            camPos.x,
            camPos.y,
            Camera.main.transform.position.z
            );
    }

    private void InstantiateNewOne(Vector2Int idx, Vector3 position)
    {
        _tilePool.Add(Instantiate(_tileObject, transform));
        _tilePool[^1].transform.position = position;
        _tilePool[^1].InitObject(idx);
    }

    public List<Tile> GetTilePool() => _tilePool;
}
