using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cursor = UnityEngine.Cursor;

public class ExaminatorInteractable : InteractableBase
{
    public GameObject offset; // Offset pour l'examen
    public bool isExamining = false; // Statut d'examen
    private Vector3 lastMousePosition; // Derni�re position de la souris

    private Transform examinedObject; // Objet actuellement examin�

    // Cette m�thode est maintenant utilis�e pour interagir avec l'objet
    public override void OnInteract()
    {
        // Si on interagit avec l'objet, on d�marre l'examen
        Debug.Log("[EXAMEN] Interaction commenc�e");

        // Enregistrer l'objet que l'on va examiner
        examinedObject = this.transform;

        isExamining = true; // Marque l'objet comme �tant en examen
        Examine(); // Appelle la m�thode Examine pour commencer
        StartExamination(); // D�marre l'examen visuel
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
            // EN examen, soit tu continue le mouevment, soit tu  te fais �valuer !!
            // Utiliser un facteur de lerp plus grand pour un d�placement plus rapide
            float moveSpeed = 0.5f;  // Augmente cette valeur pour acc�l�rer le mouvement
            examinedObject.position = Vector3.Lerp(examinedObject.position, offset.transform.position, moveSpeed * Time.deltaTime);

            Vector3 deltaMouse = Input.mousePosition - lastMousePosition;
            float rotationSpeed = 0.8f;
            examinedObject.Rotate(deltaMouse.x * rotationSpeed * Vector3.up, Space.World);
            examinedObject.Rotate(deltaMouse.y * rotationSpeed * Vector3.left, Space.World);
            lastMousePosition = Input.mousePosition;
        }
    }


    // M�thode pour v�rifier l'�tat de l'examen
    public bool getIsExamining()
    {
        return isExamining;
    }

    // Si besoin de sortir de l'examen, tu peux appeler cette m�thode
    public void ExitExamination()
    {
        StopExamination();
        isExamining = false;
    }
}
