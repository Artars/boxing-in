using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScreenViewer : MonoBehaviour
{
    public GameObject[] screens;

    public Button nextButton;
    public Button previousButton;
    public Button closeScreenButton;

    protected int current;
    
    void Start()
    {
        nextButton.onClick.AddListener(OnClickNext);
        previousButton.onClick.AddListener(OnClickPrevious);
        closeScreenButton.onClick.AddListener(CloseMenu);
    }

    public void OpenMenu()
    {
        gameObject.SetActive(true);
        SetCurrent(0);
        EventSystem.current.SetSelectedGameObject(nextButton.gameObject);
    }

    public void CloseMenu()
    {
        gameObject.SetActive(false);
    }

    public void SetCurrent(int index)
    {
        for (int i = 0; i < screens.Length; i++)
        {
            screens[i].SetActive(i == index);
        }
        current = index;

        nextButton.interactable = (index < screens.Length-1);
        previousButton.interactable = (index > 0);
    }

    public void OnClickNext()
    {
        if(current == screens.Length-2)
            EventSystem.current.SetSelectedGameObject(closeScreenButton.gameObject);
        SetCurrent(current+1);
    }

    public void OnClickPrevious()
    {
        if(current == 1)
            EventSystem.current.SetSelectedGameObject(closeScreenButton.gameObject);
        SetCurrent(current-1);
    }
}
