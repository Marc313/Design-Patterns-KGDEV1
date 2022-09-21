public class PreviousVariantCommand : IReversibleCommand<CharacterCustomizable>
{
    public void Execute(CharacterCustomizable customizable)
    {
        customizable.PreviousVariants();
    }

    public void Undo(CharacterCustomizable customizable)
    {
        customizable.NextVariants();
    }
}
