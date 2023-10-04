using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class Truck : MonoBehaviour, IInteractable
{
    public bool Visible
    {
        get; protected set;
    } = false;

    public InteractionType InteractionType => InteractionType.EmptyHand;
    public GameObject[] prefabs;

    public List<int> currentElements = new List<int>();

    public GameObject truckModel;

    public TileSystem mapTile;

    [Header("Truck UI")]
    public GameObject ui;
    public Image expireSlider;
    public GameObject itemPrefab;
    public Transform itemParent;
    protected List<Image> images = new List<Image>();
    public Sprite[] piecesSprite;
    // public Sprite[] pieceColors;

    protected float counter;
    protected float expireTime;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        truckModel.SetActive(false);
        Visible = false;
    }

    public void Appear(List<int> boxes, float expireTime)
    {
        ui.SetActive(true);
        truckModel.SetActive(true);
        Visible = true;
        currentElements = boxes;
        this.expireTime = expireTime;
        counter = expireTime;
        AudioManager.instance.PlaySound("Truck");

        ConfigureImages(boxes);
    }

    protected void ConfigureImages(List<int> boxes)
    {
        while(images.Count < boxes.Count)
        {
            GameObject newImage = GameObject.Instantiate(itemPrefab, itemParent);
            newImage.SetActive(true);
            Image image = newImage.GetComponent<Image>();
            images.Add(image);
        }

        UpdatePiecesUI();
    }

    protected void UpdatePiecesUI()
    {
        for (int i = 0; i < images.Count; i++)
        {
            if(i < currentElements.Count)
            {
                images[i].enabled = true;
                images[i].sprite = piecesSprite[currentElements[i]];
            }
            else
            {
                images[i].enabled = false;
            }
        }
    }

    void Update()
    {
        if(Visible)
        {
            counter -= Time.deltaTime;
            expireSlider.fillAmount = counter / expireTime;
            if(counter <= 0)
            {
                Player.instance.AddFault();
                AudioManager.instance.PlaySound("Fail");
                Disapear();
            }
        }
    }

    public void Disapear()
    {
        truckModel.SetActive(false);
        ui.SetActive(false);
        Visible = false;
        currentElements.Clear();
    }

    public void TryToInteract(CharacterMovement character)
    {
        int boxIndex = currentElements[0];
        currentElements.RemoveAt(0);
        UpdatePiecesUI();
        GameObject newBox = GameObject.Instantiate(prefabs[boxIndex]);
        if(mapTile != null)
            newBox.transform.localScale = mapTile.GetScale();
        character.PlayerGrab(newBox);

        if(currentElements.Count == 0)
            Disapear();
    }
}
