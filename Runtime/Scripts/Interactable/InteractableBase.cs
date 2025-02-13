using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBase : MonoBehaviour, IInteractable
{
    #region Variables    
    [Space, Header("Interactable Settings")]

    [Space]
    [SerializeField] private bool multipleUse = false;
    [SerializeField] private bool isInteractable = true;

    [SerializeField] private string tooltipMessage = "interact";
    #endregion

    #region Properties    
    public bool MultipleUse => multipleUse;
    public bool IsInteractable => isInteractable;

    public string TooltipMessage => tooltipMessage;
    #endregion

    #region Methods
    public virtual void OnInteract() // IInterractable
    {
        Debug.Log("INTERACTED: " + gameObject.name);
    }
    #endregion
}