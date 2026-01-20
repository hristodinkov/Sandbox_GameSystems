using UnityEngine;

public class CocktailData : MonoBehaviour
{
    public DrinkEffectType[] effects;

    public void SetEffects(DrinkEffectType[] newEffects)
    {
        effects = newEffects;
    }
}
