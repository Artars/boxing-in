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
    }

    public void Disapear()
    {
        truckModel.SetActive(false);
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
