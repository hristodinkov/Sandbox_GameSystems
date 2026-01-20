using UnityEngine;

public class DrinkMixer : MonoBehaviour
{
    public DrinkPairEffectDatabase database;

    public DrinkEffectType[] Mix(DrinkType d1, DrinkType d2, DrinkType d3)
    {
        return new DrinkEffectType[]
        {
            database.GetEffect(d1, d2),
            database.GetEffect(d2, d3),
            database.GetEffect(d1, d3)
        };
    }
}
