using UnityEngine;

public class CustomerEffectController : MonoBehaviour
{
    public bool fireBreath;
    public bool shrink;
    public bool chicken;
    public bool iceCube;
    public bool hiccup;
    public bool helicopter;
    public bool fart;

    public void ApplyEffects(DrinkEffectType[] effects)
    {
        foreach (var effect in effects)
        {
            switch (effect)
            {
                case DrinkEffectType.FireBreath: fireBreath = true; break;
                case DrinkEffectType.Shrink: shrink = true; break;
                case DrinkEffectType.Chicken: chicken = true; break;
                case DrinkEffectType.IceCube: iceCube = true; break;
                case DrinkEffectType.Hiccup: hiccup = true; break;
                case DrinkEffectType.Helicopter: helicopter = true; break;
                case DrinkEffectType.Fart: fart = true; break;
            }
        }
    }
}
