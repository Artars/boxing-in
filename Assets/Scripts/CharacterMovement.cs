using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class CharacterMovement : MonoBehaviour
{

    public bool startsPlaying = false;
    Controls actions;
    public float rotationSmoothness = 2;
    public float speed = 1;
    public float checkDistance = .1f;
    public float offsetCheck = .5f;
    public float grabSize = .5f;

    public TileSystem tileSystem;

    protected Rigidbody rgbd;

    public GameObject playerGrabbing;

    [Header("Box representation")]
    public MeshFilter boxMesh;
    public Mesh[] boxMeshes;

    public GameObject[] playerModels;



    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        actions = new Controls();
        rgbd = GetComponent<Rigidbody>();
        SubscribeControls();
        SetPlayerModel(-1);

        if(startsPlaying)
            EnableMovement();
    }

    public void SetPlayerModel(int index)
    {
        for (int i = 0; i < playerModels.Length; i++)
        {
            if(playerModels != null)
                playerModels[i].SetActive(i == index);
        }
    }    

    public void DisableMovement()
    {
        actions.Disable();
    }

    public void EnableMovement()
    {
        actions.Enable();
        SetPlayerModel(0);
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
                ( (interactable.InteractionType == InteractionType.BusyHand) == (playerGrabbing != null) || interactable.InteractionType == InteractionType.Any) )
                {
                    interactable.TryToInteract(this);
                    found = true;
                    break;
                }
            }
        } 
        // Try to release
        if(!found && playerGrabbing != null)
        {
            int x,y;
            GameObject hasSomethingInFront = tileSystem.GetCellInFront(transform.position, transform.forward, out x, out y);

            if(tileSystem.InsideRange(x,y) && hasSomethingInFront == null)
            {
                Vector3 pos = tileSystem.GetCenterOfCell(x,y);
                playerGrabbing.transform.position = pos;
                playerGrabbing.SetActive(true);
                tileSystem.SetTile(playerGrabbing, x,y);
                Box box = playerGrabbing.GetComponent<Box>();
                if(box)
                {
                    box.currentX = x;
                    box.currentY = y;
                }

                playerGrabbing = null;
                boxMesh.gameObject.SetActive(false);
                SetPlayerModel(0);
            }

        }
    }

    public void PlayerGrab(GameObject target)
    {
        playerGrabbing = target;

        if(target != null)
        {
            target.SetActive(false);
            Box box = target.GetComponent<Box>();
            if(box)
            {
                boxMesh.gameObject.SetActive(true);
                boxMesh.mesh = boxMeshes[(int)box.pieceType];

                if(box.currentX != -1)
                {
                    tileSystem.SetTile(null, box.currentX, box.currentY);
                }
            }

            AudioManager.instance.PlaySound("GrabBox");
        }
        else
        {
            boxMesh.gameObject.SetActive(false);
        }

        SetPlayerModel((playerGrabbing == null) ? 0 : 1);
    }
}
