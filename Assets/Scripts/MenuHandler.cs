using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[DefaultExecutionOrder(1000)]
public class MenuHandler : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;
    public TMP_InputField playerInput;

    private GameController controller;

    private void Awake()
    {
        controller = FindObjectOfType<GameController>();
    }
    private void Start()
    {
        playerInput.text = controller.PlayerName;

    }
    private void OnEnable()
    {
        startButton.onClick.AddListener(OnStartClick);
        exitButton?.onClick.AddListener(ExitButtonClick);
    }


    private void OnDisable()
    {
        startButton.onClick.RemoveListener(OnStartClick);
        exitButton?.onClick.RemoveListener(ExitButtonClick);
    }
    private void OnStartClick()
    {
        controller.SetPlayerName(playerInput.text);
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(1);
    }

    private void ExitButtonClick()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }
}
