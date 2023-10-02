using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

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

    protected float counter;

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
        truckModel.SetActive(true);
        Visible = true;
        currentElements = boxes;
        counter = expireTime;
        AudioManager.instance.PlaySound("Truck");
    }

    void Update()
    {
        if(Visible)
        {
            counter -= Time.deltaTime;
            if(counter <= 0)
            {
                Player.instance.AddFault();
                Disapear();
            }
        }
    }

    public void Disapear()
    {
        truckModel.SetActive(false);
        Visible = false;
        currentElements.Clear();
    }

    public void TryToInteract(CharacterMovement character)
    {
        int boxIndex = currentElements[0];
        currentElements.RemoveAt(0);
        GameObject newBox = GameObject.Instantiate(prefabs[boxIndex]);
        if(mapTile != null)
            newBox.transform.localScale = mapTile.GetScale();
        character.PlayerGrab(newBox);

        if(currentElements.Count == 0)
            Disapear();
    }
}
