using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange;
    public float SphereRadius = 0.5f; // Rayon de la sphère pour le SphereCast

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.SphereCast(r, SphereRadius, out RaycastHit hitInfo, InteractRange))
            {

                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.OnInteract();
                }
            }
        }
    }
}
