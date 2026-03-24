using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactibles : MonoBehaviour
{
    [SerializeField] private string interactionText = "I'm object...";

    public UnityEvent OnInteract = new UnityEvent();
    public HoldItem heldItem;

    void Start()
    {
        heldItem = GetComponent<HoldItem>();
    }
    public string GetInteractionText()
    {
        return interactionText;
    }
    public void Interact()
    {
        OnInteract.Invoke();
    }
}
