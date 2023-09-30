using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragMovement : MonoBehaviour
{
    public float dragSpeed;
    public float deadzone;
    public float dragRadius;

    private Rigidbody2D body;
    private bool dragging = false;
    private Vector3 dragPosition = Vector3.zero;
    private Vector3 dragDirection = Vector3.zero; // The direction in which we are going to move the ingredient.
    private Vector3 mousePosition = Vector3.zero;
    private Vector3 prevMousePosition = Vector3.zero;
    private Vector3 mouseVel = Vector3.zero;


    private float dTime;
    // Start is called before the first frame update
    void Start()
    {
        dragPosition = transform.position;
        mousePosition = Input.mousePosition;
        prevMousePosition = mousePosition;
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MouseVel();
        Drag();
    }

    private void OnPlayerDrag() {
        // We now just need to make usre it only grabs the object if click ON the ingredient.
        if (dragging) {
            dragging = !dragging;
            body.gravityScale = 1;
        }
        else if (Physics2D.OverlapCircle(mousePosition, dragRadius) == gameObject.GetComponent<Collider2D>())
        {
            body.WakeUp();
            body.gravityScale = 0;
            dragging = !dragging;
        }
       
    }
    private void MouseVel()
    {
        dTime = Time.deltaTime;
        prevMousePosition = mousePosition;
        mousePosition = Input.mousePosition; // We want to update this continously so that we can easily get a mouse velocity
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0;//needed to make sure the position is correct, we work on the z = 0 axis. Check later how to get rid of this using ScreenToWroldPoint, by adding like the z position of the camera.
        mouseVel = (mousePosition - prevMousePosition) / dTime;
    }

    private void Drag()
    {

        //We also want the dragging to be dependent on how fast you're moving the mouse
        //Maybe also not move if the magnitude of mousePos- drPos is too small?
        if (dragging)
        {
            dragPosition = transform.position;
            Vector3 delta = (mousePosition - dragPosition);

            if (delta.magnitude > deadzone)
            {
                dragDirection = delta.normalized;
                body.velocity = dragSpeed * dragDirection;
            }
            else
            {
                body.velocity = new Vector3(0,0,0);

            }

        }
    }
}
