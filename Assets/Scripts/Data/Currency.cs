using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    private static Currency _instance = null;
    public static Currency Instance { get {
            if (_instance == null) _instance = FindObjectOfType<Currency>();
            return _instance;
        } 
    }

    public int Gold { get { return _gold; } }
    private int _gold;

    private PlayerData _data;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else if (_instance == null)
        {
            _instance = this;
            _data = PlayerData.Instance;
            _gold = _data.GetGold();
            
            DontDestroyOnLoad(gameObject);
        }
    }

    public void UpdateGold(int value)
    {
        _gold += value;
        _data.SaveGold(_gold);
    }
}