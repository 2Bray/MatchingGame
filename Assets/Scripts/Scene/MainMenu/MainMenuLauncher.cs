using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuLauncher : MonoBehaviour
{
    [SerializeField] private Button Gameplay;
    [SerializeField] private Button ThemeStore;
    private void Start()
    {
        Gameplay.onClick.RemoveAllListeners();
        ThemeStore.onClick.RemoveAllListeners();

        Gameplay.onClick.AddListener(() => SceneManager.LoadScene("Gameplay"));
        ThemeStore.onClick.AddListener(() => SceneManager.LoadScene("ThemeStore"));
    }
}
