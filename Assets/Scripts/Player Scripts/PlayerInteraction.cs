using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Transform _highlight;

    public float InteractionRayOffset = 3f; //The offset of the interaction ray
    public float rayDistance = 10f; //The distance of the ray

    Transform playerCamera; //Reference to the camera

    public void Awake()
    {
        playerCamera = GameObject.FindWithTag("PCCamera").GetComponent<Camera>().transform;
    }

    public void Update()
    {
    /*    // Create a ray that starts at the player's position and points in the direction the camera is facing
        Ray ray = new Ray(transform.position + new Vector3(0f, InteractionRayOffset, 0f), playerCamera.transform.forward);
        RaycastHit hit;
    
        // Perform the raycast with a range of rayDistance units
        if (Physics.Raycast(ray, out hit, rayDistance)) {
            // Check if the object hit has the IInteractable component
            IInteractable interactable = hit.collider.gameObject.GetComponent<IInteractable>();
            if (interactable != null) {
                // The object hit is interactable, highlight it
                Outline outline = hit.collider.gameObject.GetComponent<Outline>();
                if (outline == null) {
                    // If the object does not have an Outline component, add one
                    outline = hit.collider.gameObject.AddComponent<Outline>();
                }
                outline.enabled = true;
                // Update _highlight to the current object
                _highlight = hit.collider.gameObject.transform;
            }
        }
    
        // If the ray does not hit an interactable object, unhighlight the previous object
        if (_highlight != null && (_highlight != hit.collider?.gameObject || hit.collider.gameObject.GetComponent<IInteractable>() == null)) {
            Outline outline = _highlight.GetComponent<Outline>();
            if (outline != null) {
                outline.enabled = false;
            }
            _highlight = null;
        } */
    } 

    public void HandleInteraction()
    {
        // Create a ray that starts at the player's position and points in the direction the camera is facing
        Ray ray = new Ray(transform.position + new Vector3(0f, InteractionRayOffset, 0f), playerCamera.transform.forward);
        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit, rayDistance)) {
            Debug.Log("Interaction ray hit nothing");
            return;
        }

        // Check if the object hit has the IInteractable component
        IInteractable interactable = hit.collider.gameObject.GetComponent<IInteractable>();
        if (interactable == null) {
            Debug.LogWarning("No IInteractable component found on object");
            return;
        }

        // Interact with the object
        interactable.Interact(this.gameObject);
    }
}
