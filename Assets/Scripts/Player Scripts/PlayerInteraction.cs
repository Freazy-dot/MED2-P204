using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private IHighlightable _highlightInteractable;

    public float InteractionRayOffset = 3f; //The offset of the interaction ray
    public float rayDistance = 10f; //The distance of the ray

    Transform playerCamera; //Reference to the camera

    public void Awake()
    {
        playerCamera = GameObject.FindWithTag("PCCamera").GetComponent<Camera>().transform;
    }

public void Update()
{
    Ray ray = new Ray(transform.position + new Vector3(0f, InteractionRayOffset, 0f), playerCamera.transform.forward);
    RaycastHit hit;

    IHighlightable highlightable = null;
    if (!Physics.Raycast(ray, out hit, rayDistance)) {
        return;
    }

    highlightable = hit.collider.gameObject.GetComponent<IHighlightable>();

    if (_highlightInteractable as MonoBehaviour != null && _highlightInteractable != highlightable) {
        _highlightInteractable.OnLookAway();
    }

    if (highlightable != null) {
        highlightable.OnLookAt();
    }

    _highlightInteractable = highlightable;
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
