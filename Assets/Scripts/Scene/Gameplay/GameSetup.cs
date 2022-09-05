using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    [SerializeField] private TilePool _tilePool;
    [SerializeField] private TileGroup _tileGroup;
    [SerializeField] private GameOverListener _gameOverListener;
    [SerializeField] private TimerManager _timerManager;


    void Start()
    {
        _tilePool.StartInit();
        _tileGroup.StartInit(_tilePool.GetTilePool());
        _gameOverListener.StartInit(_tileGroup, _timerManager);

        _timerManager.StartGame();
    }
}
