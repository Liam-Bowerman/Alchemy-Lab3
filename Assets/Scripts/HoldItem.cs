using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class HoldItem : MonoBehaviour
{
    public GameObject gameObject;
    public Interactibles interactible;
    public Transform parentObject;

    private float xAxis;
    private float yAxis;
    private float zAxis;

    public bool isHoldingItem = false;

    public float xAxisTurnRate = 10f;
    public float yAxisTurnRate = 10f;
    public float zAxisTurnRate = 10f;

    void Start()
    {
        interactible = GetComponent<Interactibles>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isHoldingItem = true;
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            isHoldingItem = false;
            gameObject.transform.SetParent(null);
            gameObject = null;
        }
        if (isHoldingItem == true)
        {
            if (gameObject)
            {
                gameObject.transform.SetParent(parentObject);
                gameObject.transform.position = parentObject.transform.position + (parentObject.transform.forward * 1.1f);
                Quaternion newRotation = Quaternion.Euler(xAxis, yAxis, zAxis);
                gameObject.transform.rotation = newRotation;
                float scrollDelta = Input.GetAxis("Mouse ScrollWheel");

                if (scrollDelta != 0f)
                {
                    // A positive value means scrolling up/forward
                    if (scrollDelta > 0f)
                    {
                        xAxis += 1 * xAxisTurnRate;
                        print("haha");
                    }
                    // A negative value means scrolling down/backward
                    else if (scrollDelta < 0f)
                    {
                        xAxis -= 1 * xAxisTurnRate;
                        print("ohhh");
                    }
                }
            }
        }    }
    public void AddXAxisInput(float input)
    {
        xAxis -= input * xAxisTurnRate;
        xAxis = Mathf.Clamp(xAxis, -90f, 90f);
    }
    public void AddYAxisInput(float input)
    {
        yAxis += input * yAxisTurnRate;
    }
    public void AddZAxisInput(float input)
    {
        zAxis += input * zAxisTurnRate;
    }

    public void GetGameObject()
    {

        gameObject = interactible.gameObject;
    }
}
