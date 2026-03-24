using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] private float maxDistance = 2f;
    [SerializeField] private Text interactableName;

    private Interactibles targetInteraction;
    public Camera mainCamera;
    
    void Update()
    {
        string interactionText = "";
        targetInteraction = null;
        Vector3 origin = mainCamera.transform.position;
        Vector3 direction = mainCamera.transform.forward;
        RaycastHit raycastHit = new RaycastHit();

        if (Physics.Raycast(origin, direction, out raycastHit, maxDistance))
        {
            targetInteraction = raycastHit.collider.gameObject.GetComponent<Interactibles>();
        }
        if (targetInteraction)
        {
            interactionText = targetInteraction.GetInteractionText();
        }
        SetInteractableNameText(interactionText);
    }
    private void SetInteractableNameText(string newText)
    {
        if (interactableName)
        {
            interactableName.text = newText;
        }
    }
    public void TryInteract()
    {
        if (targetInteraction)
        {
            targetInteraction.Interact();
        }
    }
}
