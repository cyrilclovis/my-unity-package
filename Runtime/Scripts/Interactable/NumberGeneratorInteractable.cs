using UnityEngine;

public class NumberGeneratorInteractable : MonoBehaviour, IInteractable
{
    public void OnInteract()
    {
        Debug.Log(Random.Range(0, 100));
    }
}
