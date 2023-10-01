using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class CharacterMovement : MonoBehaviour
{
    Controls actions;
    public float rotationSmoothness = 2;
    public float speed = 1;
    public float checkDistance = .1f;
    public float offsetCheck = .5f;
    public float grabSize = .5f;

    public TileSystem tileSystem;

    protected Rigidbody rgbd;

    protected GameObject playerGrabbing;



    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        actions = new Controls();
        actions.Enable();
        rgbd = GetComponent<Rigidbody>();
        SubscribeControls();
    }
    

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        Move(Time.fixedDeltaTime);
    }

    void SubscribeControls()
    {
        actions.Gameplay.Pick.performed += OnPressGrab;
    }

    void Move(float deltaTime)
    {
        Vector3 direction = new Vector3(actions.Gameplay.MoveX.ReadValue<float>(),0,actions.Gameplay.MoveY.ReadValue<float>());

        if(direction.sqrMagnitude > .1f)
        {
            direction.Normalize();
            //Rotate to direction
            Quaternion directionAsQuat = Quaternion.LookRotation(direction, Vector3.up);
            rgbd.MoveRotation(Quaternion.Lerp(rgbd.rotation, directionAsQuat, deltaTime * rotationSmoothness ));

            //Physics check
            if(!Physics.Raycast(transform.position + direction.normalized * offsetCheck,direction, checkDistance))
            {
                rgbd.MovePosition(rgbd.position + direction * speed * deltaTime);
            }
        }
    }

    RaycastHit[] buffer = new RaycastHit[32];

    void OnPressGrab(InputAction.CallbackContext context)
    {
        Ray ray = new Ray(transform.position + transform.forward * offsetCheck, transform.forward);
        //Try to get box
        int count = Physics.SphereCastNonAlloc(ray, grabSize, buffer, grabSize);
        bool found = false;
        for (int i = 0; i < count; i++)
        {
            if(buffer[i].collider.tag == "Box")
            {
                IInteractable interactable = buffer[i].collider.GetComponentInParent<IInteractable>();
                if(interactable != null && 
                ( (interactable.InteractionType == InteractionType.BusyHand) == (playerGrabbing != null) ) )
                {
                    interactable.TryToInteract(this);
                    found = true;
                    break;
                }
            }
        } 
        if(!found && playerGrabbing != null)
        {
            int x,y;
            GameObject hasSomethingInFront = tileSystem.GetCellInFront(transform.position, transform.forward, out x, out y);
            if(!hasSomethingInFront)
            {
                Vector3 pos = tileSystem.GetCenterOfCell(x,y);
                playerGrabbing.transform.position = pos;
                playerGrabbing.SetActive(true);
                playerGrabbing = null;
            }

        }
    }

    public void PlayerGrab(GameObject target)
    {
        playerGrabbing = target;
        target.SetActive(false);
    }
}
