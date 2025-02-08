using UnityEngine;

public class NumberGeneratorInteractable : InteractableBase
{
    override
    public void OnInteract()
    {
        base.OnInteract();
        Debug.Log(Random.Range(0, 100));
    }
}
