using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Boxing : MonoBehaviour, IInteractable
{
    public InteractionType InteractionType
    {
        get
        {
            if(grabbed != null)
                return InteractionType.EmptyHand;
            else
                return InteractionType.Any;
        }
    }
    public TileSystem tileSystem;
    public TileSystem mapTiles;
    Controls actions;

    public Transform cursor;

    public float speed = 2;

    protected Vector2 positionFloat;

    public Transform offPosition;
    public Vector3 offsetWhenGrabbing = Vector3.up;

    public GameObject[] piecesPrefabs;
    public GameObject[] boxesPrefabs;

    protected bool menuOpen;

    protected PuzzlePiece grabbed;

    protected Vector2 lastPosition;

    protected PuzzlePiece onHand;

    public Slider slider;
    public Slider sliderBackground;
    public GameObject canPack;

    public GameObject openCursor;
    public GameObject closedCursor;

    protected bool canDeliver;

    void Start()
    {
        actions = new Controls();
        actions.Gameplay.Cancel.performed += OnCancel;
        actions.Gameplay.Pick.performed += OnPick;
        actions.Gameplay.RotateClockwise.performed += OnRotateClock;
        actions.Gameplay.RotateAntiClockwise.performed += OnRotateAntiClock;
        actions.Gameplay.Pack.performed += OnPack;
    }

    public void TryToInteract(CharacterMovement character)
    {
        if(character.playerGrabbing != null)
        {
            Box box = character.playerGrabbing.GetComponent<Box>();
            if(box.pieceType == Box.Pieces.Delivery)
                return;
            onHand = CreatePiece(box);
            character.PlayerGrab(null);
            positionFloat.x = tileSystem.size.x+.5f;
            UpdateCursorPosition();
        }
        else
        {
            positionFloat = Vector3.zero;
            UpdateCursorPosition();
        }
        OpenMenu();
    }

    protected PuzzlePiece CreatePiece(Box box)
    {
        GameObject newPiece = GameObject.Instantiate(piecesPrefabs[(int)box.pieceType], offPosition.position, Quaternion.identity);
        newPiece.transform.localScale = tileSystem.GetScale();

        PuzzlePiece piece = newPiece.GetComponent<PuzzlePiece>();
        return piece;
    }

    public void OpenMenu()
    {
        Player.instance.ChangeToBoxing();
        actions.Enable();
        menuOpen = true;
    }

    void OnCancel(InputAction.CallbackContext context)
    {
        if(onHand != null)
        {
            GameObject newBox = GameObject.Instantiate(boxesPrefabs[(int)onHand.pieceType]);
            newBox.transform.localScale = mapTiles.GetScale();
            Player.instance.characterMovement.PlayerGrab(newBox);
            Destroy(onHand.gameObject);
            onHand = null;
        }
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
                    positionFloat = grabbed.currentPosition;
                    FillTiles(grabbed.currentPosition.x, grabbed.currentPosition.y, grabbed, null);
                    UpdateCursorPosition();
                }
            }
        }
        else
        {
            if(onHand == null && positionFloat.x >= tileSystem.size.x)
            {
                grabbed.transform.position = offPosition.position;
                onHand = grabbed;
                grabbed = null; 
                AudioManager.instance.PlaySound("Put");
            }
            else if(CheckPositionAvailableWithPiece(currentX,currentY, grabbed))
            {
                FillTiles(currentX, currentY, grabbed, grabbed.gameObject);
                grabbed.currentPosition = new Vector2Int(currentX, currentY);
                grabbed.transform.position = cursor.position - offsetWhenGrabbing;
                grabbed = null;
                AudioManager.instance.PlaySound("Put");
                
            }
        }
        UpdateCursorPosition();
        UpdatePorcentage();
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
                
                if(configuration.validSlot[i,j] == true && tileSystem.GetTile(currentX,currentY) != null)
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
                if(currentY < 0 || currentY >= tileSystem.size.y || configuration.validSlot[i,j] == false)
                    continue;
                
                tileSystem.SetTile(value,currentX,currentY);
            }
        }
    }

    protected void UpdatePorcentage()
    {
        float total = tileSystem.size.x * tileSystem.size.y;
        int counter = 0;
        for (int i = 0; i < tileSystem.busyCells.Length; i++)
        {
            for (int j = 0; j < tileSystem.busyCells[i].Length; j++)
            {
                if(tileSystem.busyCells[i][j] != null)
                    counter++;
            }
        }

        float pct = counter/total;
        slider.value = pct;
        sliderBackground.value = Player.instance.gameParameters.fillPorcentage;
        canDeliver = pct > Player.instance.gameParameters.fillPorcentage;
        canPack.SetActive(canDeliver);
    }

    void OnRotateClock(InputAction.CallbackContext context)
    {
        if(grabbed != null)
        {
            grabbed.RotateClockwise();
            AudioManager.instance.PlaySound("ChangeDirection");
        }
    }

    void OnRotateAntiClock(InputAction.CallbackContext context)
    {
        if(grabbed != null)
        {
            grabbed.RotateAnticlockwise();
            AudioManager.instance.PlaySound("ChangeDirection");
        }
    }

    void OnPack(InputAction.CallbackContext context)
    {
        if(canDeliver && onHand == null && grabbed == null)
        {
            UpdatePorcentage();
            GameObject newBox = GameObject.Instantiate(boxesPrefabs[(int)Box.Pieces.Delivery]);
            newBox.transform.localScale = mapTiles.GetScale();
            Box box = newBox.GetComponent<Box>();
            float t = Mathf.InverseLerp(Player.instance.gameParameters.fillPorcentage,1,slider.value);
            box.points = Mathf.Lerp(Player.instance.gameParameters.minPoints,Player.instance.gameParameters.minPoints,t);
            Player.instance.characterMovement.PlayerGrab(newBox);

            ClearBoard();
            CloseMenu();
            UpdatePorcentage();
        }
    }

    protected void ClearBoard()
    {
        for (int i = 0; i < tileSystem.size.x; i++)
        {
            for (int j = 0; j < tileSystem.size.y; j++)
            {
                if(tileSystem.busyCells[i][j] != null)
                {
                    DestroyImmediate(tileSystem.busyCells[i][j]);
                    tileSystem.busyCells[i][j] = null;
                }
            }
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

        if(grabbed != null)
        {
            grabbed.transform.position = cursor.position;
        }

        openCursor.SetActive(grabbed == null);
        closedCursor.SetActive(grabbed != null);
    }

}


