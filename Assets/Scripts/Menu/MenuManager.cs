﻿using UnityEngine.SceneManagement;
using UnityEngine.Assertions;
using UnityEngine.UI;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Button startButton;

    [SerializeField]
    private Button infoButton;

    [SerializeField]
    private GameObject infoPage;

    [SerializeField]
    private Button infoPageExitButton;

    private void Awake()
    {
        Assert.IsNotNull(startButton);
        Assert.IsNotNull(infoButton);
        Assert.IsNotNull(infoPage);
        Assert.IsNotNull(infoPageExitButton);

        startButton.onClick.AddListener(StartGame);
        infoButton.onClick.AddListener(ActivateInfoPage);
        infoPageExitButton.onClick.AddListener(ReactivateMenu);

        ReactivateMenu();

        // we want the level to always start at level 1 for the players
        // so we enforce it here so restarting the game before they die
        // will not be effective
        PlayerPrefs.SetInt(PlayerPrefConstants.Level, 1);
    }

    private void OnDestroy()
    {
        startButton.onClick.RemoveListener(StartGame);
        infoButton.onClick.RemoveListener(ActivateInfoPage);
        infoPageExitButton.onClick.RemoveListener(ReactivateMenu);
    }

    private void ReactivateMenu()
    {
        startButton.gameObject.SetActive(true);
        infoButton.gameObject.SetActive(true);
        infoPage.SetActive(false);
    }

    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void ActivateInfoPage()
    {
        startButton.gameObject.SetActive(false);
        infoButton.gameObject.SetActive(false);
        infoPage.SetActive(true);
    }
}
