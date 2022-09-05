using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverListener : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _status;
    [SerializeField] GameObject _gameOverPanel;

    private TileGroup _tileGroup;
    private TimerManager _timeManager;

    public void StartInit(TileGroup tileGroup, TimerManager timeManager)
    {
        _tileGroup = tileGroup;
        _timeManager = timeManager;

        _tileGroup.TileCleared += SetGameOver;
        _timeManager.TimeOver += SetGameOver;
    }

    private void SetGameOver()
    {
        _tileGroup.TileCleared -= SetGameOver;
        _timeManager.TimeOver -= SetGameOver;

        if (_tileGroup.GetTilePool().Count > 0)
        {

        }
        else
            return;
    }
}
