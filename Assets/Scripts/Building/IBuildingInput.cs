namespace Assets.Scripts.Building
{
    public interface IBuildingInput
    {
        event System.Action OnRotateLeft;
        event System.Action OnRotateRight;
        event System.Action OnCancelBuild;
        event System.Action OnConfirmBuild;
    }
}