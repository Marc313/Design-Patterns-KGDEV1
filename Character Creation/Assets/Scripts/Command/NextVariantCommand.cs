public class NextVariantCommand : IReversibleCommand
{
    private CharacterCustomizable customizable;

    public NextVariantCommand(CharacterCustomizable _customizable)
    {
        customizable = _customizable;
    }

    public void Execute()
    {
        customizable.NextVariants();
    }

    public void Undo()
    {
        customizable.PreviousVariants(false);
    }
}