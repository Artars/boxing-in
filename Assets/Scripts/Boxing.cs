using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class Boxing : MonoBehaviour, IInteractable
{
    public InteractionType InteractionType => InteractionType.Any;
    public TileSystem tileSystem;
    Controls actions;

    public Transform cursor;

    public float speed = 2;

    protected Vector2 positionFloat;

    public Transform offPosition;
    public Vector3 offsetWhenGrabbing = Vector3.up;

    public GameObject[] piecesPrefabs;

    protected bool menuOpen;

    protected PuzzlePiece grabbed;

    protected Vector2 lastPosition;

    protected PuzzlePiece onHand;


    void Start()
    {
        actions = new Controls();
        actions.Gameplay.Cancel.performed += OnCancel;
        actions.Gameplay.Pick.performed += OnPick;
        actions.Gameplay.RotateClockwise.performed += OnRotateClock;
        actions.Gameplay.RotateAntiClockwise.performed += OnRotateAntiClock;
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

    void OnPick(InputAction.CallbackContext context)
    {
        int currentX = Mathf.FloorToInt(positionFloat.x);
        int currentY = Mathf.FloorToInt(positionFloat.y);
        if(grabbed == null)
        {
            if(positionFloat.x >= tileSystem.size.x)
            {
                if(onHand != null)
                {
                    grabbed = onHand;
                    onHand = null;
                }
            }
            else
            {
                GameObject onTile =tileSystem.GetTile(currentX, currentY);
                if(onTile != null)
                {
                    grabbed = onTile.GetComponent<PuzzlePiece>();
                    FillTiles(currentX, currentY, grabbed, null);
                }
            }
        }
        else
        {
            if(CheckPositionAvailableWithPiece(currentX,currentY, grabbed))
            {
                FillTiles(currentX, currentY, grabbed, grabbed.gameObject);
                grabbed.transform.position = cursor.position - offsetWhenGrabbing;
                grabbed = null;
            }
        }
    }

    protected bool CheckPositionAvailableWithPiece(int x, int y, PuzzlePiece piece)
    {
        PuzzlePiece.Configuration configuration = piece.GetCurrentConfiguration();
        for (int i = 0; i < configuration.dimension.x; i++)
        {
            int currentX = x + i - configuration.pivot.x;
            if(currentX < 0 || currentX >= tileSystem.size.x)
                return false;
            for (int j = 0; j < configuration.dimension.y; j++)
            {
                int currentY = y + j - configuration.pivot.y;
                if(currentY < 0 || currentY >= tileSystem.size.y)
                    return false;
                
                if(tileSystem.GetTile(currentX,currentY) != null)
                {
                    return false;
                }
            }
        }
        return true;
    }

    protected void FillTiles(int x, int y, PuzzlePiece piece, GameObject value)
    {
        PuzzlePiece.Configuration configuration = piece.GetCurrentConfiguration();
        for (int i = 0; i < configuration.dimension.x; i++)
        {
            int currentX = x + i - configuration.pivot.x;
            if(currentX < 0 || currentX >= tileSystem.size.x)
                continue;
            for (int j = 0; j < configuration.dimension.y; j++)
            {
                int currentY = y + j - configuration.pivot.y;
                if(currentY < 0 || currentY >= tileSystem.size.y)
                    continue;
                
                tileSystem.SetTile(value,currentX,currentY);
            }
        }
    }

    void OnRotateClock(InputAction.CallbackContext context)
    {
        if(grabbed != null)
        {
            grabbed.RotateClockwise();
        }
    }

    void OnRotateAntiClock(InputAction.CallbackContext context)
    {
        {
            grabbed.RotateAnticlockwise();
        }
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
            Vector2 direction = new Vector2(actions.Gameplay.MoveX.ReadValue<float>(),actions.Gameplay.MoveY.ReadValue<float>());
            if(direction.sqrMagnitude > .1f)
            {
                positionFloat += direction*speed*Time.deltaTime;
                if(positionFloat.x > tileSystem.size.x+1)
                    positionFloat.x = tileSystem.size.x;
                else if(positionFloat.x < 0)
                    positionFloat.x = 0;

                if(positionFloat.y >= tileSystem.size.y)
                    positionFloat.y = tileSystem.size.y-1;
                else if(positionFloat.y < 0)
                    positionFloat.y = 0;

                UpdateCursorPosition();
            }
        }
    }

    void UpdateCursorPosition()
    {
        Vector3 offset = (grabbed != null) ? offsetWhenGrabbing : Vector3.zero;
        if(positionFloat.x > tileSystem.size.x)
        {
            cursor.position = offPosition.position + offset;
        }
        else
        {
            cursor.position = tileSystem.GetCenterOfCell(Mathf.FloorToInt(positionFloat.x),Mathf.FloorToInt(positionFloat.y))+ offset;
        }
    }

}


