public class PreviousVariantCommand : IReversibleCommand
{
    CharacterCustomizable customizable;

    public PreviousVariantCommand(CharacterCustomizable _customizable)
    {
        customizable = _customizable;
    }

    public void Execute()
    {
        customizable.PreviousVariants();
    }

    public void Undo()
    {
        customizable.NextVariants(false);
    }
}
