using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    FirstPersonCamera firstPersonCamera;
    PlayerMovement playerMovement;
    PlayerActions playerAction;

    // Start is called before the first frame update
    void Start()
    {
        firstPersonCamera = GetComponent<FirstPersonCamera>();
        playerMovement = GetComponent<PlayerMovement>();
        playerAction = GetComponent<PlayerActions>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleCameraInput();
        HandleMoveInput();
        HandleActionInput();
    }

    void HandleCameraInput()
    {
        firstPersonCamera.AddXAxisInput(Input.GetAxis("Mouse Y") * Time.deltaTime);
        firstPersonCamera.AddYAxisInput(Input.GetAxis("Mouse X") * Time.deltaTime);
    }
    void HandleMoveInput()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float rightInput = Input.GetAxis("Horizontal");

        playerMovement.AddMoveInput(forwardInput, rightInput);
    }
    void HandleActionInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerAction.TryInteract();
        }
    }
}
