using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cursor = UnityEngine.Cursor;

public class ExaminatorInteractable : InteractableBase
{
    public float examinationHeight = 1.0f; // Hauteur à laquelle l'objet s'élève
    public bool isExamining = false; // Statut d'examen
    private Vector3 lastMousePosition; // Dernière position de la souris
    private Transform examinedObject; // Objet actuellement examiné
    private Vector3 originalPosition; // Position initiale de l'objet

    public override void OnInteract()
    {
        Debug.Log("[EXAMEN] Interaction commencée");
        examinedObject = this.transform;
        originalPosition = examinedObject.position;
        isExamining = true;
        Examine();
    }


    #region Environnement de l'examen

    public void BeginExamination()
    {
        isExamining = true;
        Examine();
    }

    // Appel à chaque update et permet donc la rotation de l'objet !!
    private void Examine()
    {
        MakeExaminedObjectHighEnough();
        RotateExaminedObjectOnMouseMovement();
    }

    // On met l'objet suffisamment haut pour que l'utilisateur puisse le voir sous toutes ces facettes lorsqu'il le tourne dans l'espace (sans qu'il y a de conflit avec le sol)
    private void MakeExaminedObjectHighEnough()
    {
        examinedObject.position = new Vector3(examinedObject.position.x, originalPosition.y + examinationHeight, examinedObject.position.z);
    }

    private void RotateExaminedObjectOnMouseMovement()
    {
        if (examinedObject != null)
        {
            Vector3 deltaMouse = Input.mousePosition - lastMousePosition;
            float rotationSpeed = 0.8f;
            examinedObject.Rotate(deltaMouse.x * rotationSpeed * Vector3.up, Space.World);
            examinedObject.Rotate(deltaMouse.y * rotationSpeed * Vector3.left, Space.World);
            lastMousePosition = Input.mousePosition;
        }
    }




    void Update()
    {
        if (isExamining)
        {
            Examine();
        }
    }

    #endregion


    void StopExamination()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        examinedObject.position = originalPosition; // Remet l'objet à sa position d'origine
    }


    public bool getIsExamining()
    {
        return isExamining;
    }

    public void ExitExamination()
    {
        StopExamination();
        isExamining = false;
    }
}
