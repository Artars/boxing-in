using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Box : MonoBehaviour, IInteractable
{
    public enum Pieces
    {
        Z = 0, L, I, J, S, O, T, Delivery
    }
    
    public Pieces pieceType;

    public InteractionType InteractionType => InteractionType.EmptyHand;
    public MeshRenderer bottom;
    public Color bottomColor;

    public int currentX = -1;
    public int currentY = -1;

    public float points = 0;

    void Start()
    {
        SetBottomColor(bottomColor);
    }

    public void SetBottomColor(Color color)
    {
        bottomColor = color;
        MaterialPropertyBlock block = new MaterialPropertyBlock();
        bottom.GetPropertyBlock(block);
        block.SetColor("_BaseColor", color);
        bottom.SetPropertyBlock(block);
    }

    public void TryToInteract(CharacterMovement character)
    {
        character.PlayerGrab(gameObject);
    }
}
