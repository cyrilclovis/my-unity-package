public interface IInteractable
{

    bool MultipleUse { get; }
    bool IsInteractable { get; }

    string TooltipMessage { get; }


    void OnInteract();
}
