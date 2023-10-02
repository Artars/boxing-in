using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryBooth : MonoBehaviour, IInteractable
{
    public InteractionType InteractionType => InteractionType.BusyHand;

    public void TryToInteract(CharacterMovement character)
    {

        Box box = character.playerGrabbing.GetComponent<Box>();

        if(box.pieceType == Box.Pieces.Delivery)
        {
            Player.instance.AddPoints(box.points);
            character.PlayerGrab(null);
            Destroy(box.gameObject);
            AudioManager.instance.PlaySound("BoxDelivered");
        }
    }

}
