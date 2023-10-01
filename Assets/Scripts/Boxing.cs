using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class Boxing : MonoBehaviour, IInteractable
{
    public InteractionType InteractionType => InteractionType.BusyHand;
    public TileSystem tileSystem;
    Controls actions;

    public Transform cursor;

    public float speed = 2;

    protected Vector2 positionFloat;


    protected bool menuOpen;

    void Start()
    {
        actions = new Controls();
        actions.Gameplay.Cancel.performed += OnCancel;
    }

    public void TryToInteract(CharacterMovement character)
    {
        OpenMenu();
    }

    public void OpenMenu()
    {
        Player.instance.ChangeToBoxing();
        actions.Enable();
        menuOpen = true;
    }

    void OnCancel(InputAction.CallbackContext context)
    {
        CloseMenu();
    }

    public void CloseMenu()
    {
        actions.Disable();
        Player.instance.ChangeToGame();
    }

    void Update()
    {
        if(menuOpen)
        {
            
        }
    }

}
