using System.Collections.Generic;

public static class Character
{
    private static Dictionary<CharacterCustomizable, Variant> charactureFeatures = new Dictionary<CharacterCustomizable, Variant>();

    public static void SaveFeature(CharacterCustomizable _custom, Variant _variant)
    {
        if (charactureFeatures.ContainsKey(_custom))
        {
            charactureFeatures[_custom] = _variant;
        }
        else
        {
            charactureFeatures.Add(_custom, _variant);
        }
    }

    public static void LoadFeatures()
    { 
        foreach(CharacterCustomizable cc in charactureFeatures.Keys)
        {
            Variant savedVariant = charactureFeatures[cc];
            cc.LoadVariant(savedVariant);
        }
    }
}
