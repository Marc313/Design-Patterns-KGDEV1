public class NextVariantCommand : IReversibleCommand<CharacterCustomizable>
{
    public void Execute(CharacterCustomizable customizable)
    {
        customizable.NextVariants();
    }

    public void Undo(CharacterCustomizable customizable)
    {
        customizable.PreviousVariants();
    }
}
