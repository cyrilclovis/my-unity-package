using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cursor = UnityEngine.Cursor;

public class ExaminatorInteractable : InteractableBase
{
    public GameObject offset; // Offset pour l'examen
    public bool isExamining = false; // Statut d'examen
    private Vector3 lastMousePosition; // Dernière position de la souris

    private Transform examinedObject; // Objet actuellement examiné

    // Cette méthode est maintenant utilisée pour interagir avec l'objet
    public override void OnInteract()
    {
        // Si on interagit avec l'objet, on démarre l'examen
        Debug.Log("[EXAMEN] Interaction commencée");

        // Enregistrer l'objet que l'on va examiner
        examinedObject = this.transform;

        isExamining = true; // Marque l'objet comme étant en examen
        Examine(); // Appelle la méthode Examine pour commencer
        StartExamination(); // Démarre l'examen visuel
    }

    void Update()
    {
        // Si l'objet est en cours d'examen, appelle Examine chaque frame
        if (isExamining)
        {
            Examine();
        }
    }

    void StartExamination()
    {
        lastMousePosition = Input.mousePosition;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void StopExamination()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Examine()
    {
        if (examinedObject != null)
        {
            // EN examen, soit tu continue le mouevment, soit tu  te fais évaluer !!
            // Utiliser un facteur de lerp plus grand pour un déplacement plus rapide
            float moveSpeed = 0.5f;  // Augmente cette valeur pour accélérer le mouvement
            examinedObject.position = Vector3.Lerp(examinedObject.position, offset.transform.position, moveSpeed * Time.deltaTime);

            Vector3 deltaMouse = Input.mousePosition - lastMousePosition;
            float rotationSpeed = 0.8f;
            examinedObject.Rotate(deltaMouse.x * rotationSpeed * Vector3.up, Space.World);
            examinedObject.Rotate(deltaMouse.y * rotationSpeed * Vector3.left, Space.World);
            lastMousePosition = Input.mousePosition;
        }
    }


    // Méthode pour vérifier l'état de l'examen
    public bool getIsExamining()
    {
        return isExamining;
    }

    // Si besoin de sortir de l'examen, tu peux appeler cette méthode
    public void ExitExamination()
    {
        StopExamination();
        isExamining = false;
    }
}
