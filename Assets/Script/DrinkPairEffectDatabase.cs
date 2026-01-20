using UnityEngine;

[System.Serializable]
public struct DrinkPairEffect
{
    public DrinkType drinkA;
    public DrinkType drinkB;
    public DrinkEffectType effect;
}

[CreateAssetMenu(fileName = "DrinkPairEffectDatabase", menuName = "Bartender/Drink Pair Effect Database")]
public class DrinkPairEffectDatabase : ScriptableObject
{
    public DrinkPairEffect[] combinations;

    public DrinkEffectType GetEffect(DrinkType a, DrinkType b) 
    { 
        foreach (var combo in combinations) 
        { 
            if ((combo.drinkA == a && combo.drinkB == b) || (combo.drinkA == b && combo.drinkB == a)) 
                return 
            combo.effect; 
        } 
        return DrinkEffectType.Nothing; 
    }
}
