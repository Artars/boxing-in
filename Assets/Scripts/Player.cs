using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Player : MonoBehaviour
{
    public static Player instance;

    public Transform cameraTransform;
    public CharacterMovement characterMovement;
    public Transform cameraPosPlaying;
    public Transform cameraPosBoxing;

    void Start()
    {
        instance = this;
    }

    public void ChangeToBoxing()
    {
        characterMovement.DisableMovement();
        cameraTransform.position = cameraPosBoxing.position;
        cameraTransform.rotation = cameraPosBoxing.rotation;
    }

    public void ChangeToGame()
    {
        characterMovement.EnableMovement();
        cameraTransform.position = cameraPosPlaying.position;
        cameraTransform.rotation = cameraPosPlaying.rotation;
    }
}
