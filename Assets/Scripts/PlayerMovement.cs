using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;
    public float moveSpeed = 5f;
    private Vector3 moveDirection;
    public float crouch = 1;
    public GameObject playerModel;

    public Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection.Normalize();
        moveDirection.y = -1f;

        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (crouch == 1)
            {
                //mainCamera.transform.position -= new Vector3(0f, 0.5f, 0f);
                //crouch--;
                moveSpeed = 1;
            }
            gameObject.transform.localScale = new Vector3(0.7f, 0.6f, 0.7f);
            // characterController.height = 1.5f;
        }
        else
        {
            moveSpeed = 2f;
            gameObject.transform.localScale = new Vector3(0.7f, 0.83039f, 0.7f);
            // characterController.height = 2f;
        }
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void AddMoveInput(float forwardInput, float rightInput)
    {
        Vector3 forward = mainCamera.transform.forward;
        Vector3 right = mainCamera.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        moveDirection = (forwardInput * forward) + (rightInput * right);
    }

}
