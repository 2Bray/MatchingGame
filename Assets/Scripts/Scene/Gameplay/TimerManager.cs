using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TimerManager : MonoBehaviour
{
    public Action TimeOver;

    [SerializeField] private float _timeGame;
    [SerializeField] private TextMeshProUGUI _timeUI;

    private bool isGamePlay;
    public void StartGame()
    {
        isGamePlay = true;
    }

    private void Update()
    {
        if (!isGamePlay) return;

        _timeGame -= Time.deltaTime;
        _timeUI.text = Mathf.FloorToInt(_timeGame).ToString();

        if (_timeGame <= 0)
        {
            TimeOver();
            isGamePlay = false;
        }
    }
}
