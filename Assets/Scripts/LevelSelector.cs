using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public TMPro.TMP_Text title;
    public TMPro.TMP_Text description;
    public Button nextButton;
    public Button previousButton;
    public Button startGame;
    public Button openMenu;

    public GameObject mapMenu;

    public GameObject titleMenu;

    public GameObject wholeUI;

    public GameParameters[] gameParameters;
    private int current = 0;

    void Start()
    {
        Subscribe();
        SetCurrent(current);
    }

    void Subscribe()
    {
        nextButton.onClick.AddListener(OnClickNext);
        previousButton.onClick.AddListener(OnClickPrevious);
    }

    void SetCurrent(int index)
    {
        current = index;
        title.text = gameParameters[index].stageName;
        description.text = gameParameters[index].description;

        nextButton.interactable = (index < gameParameters.Length-1);
        previousButton.interactable = (index > 0);
    }

    public void OnClickNext()
    {
        if(current == gameParameters.Length-2)
            EventSystem.current.SetSelectedGameObject(startGame.gameObject);

        SetCurrent(current+1);
    }

    public void OnClickPrevious()
    {
        if(current == 1)
            EventSystem.current.SetSelectedGameObject(startGame.gameObject);
        SetCurrent(current-1);
    }

    public void OnClickStart()
    {
        Player.instance.gameParameters = gameParameters[current];
        Player.instance.StartGame();
        gameObject.SetActive(false);
    }

    public void OnClickClose()
    {
        mapMenu.SetActive(false);
        titleMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(openMenu.gameObject);
    }

    public void OnClickOpen()
    {
        titleMenu.SetActive(false);
        mapMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(startGame.gameObject);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
