using UnityEditor;
using UnityEngine;

public static class DrinkDatabaseAutoFill
{
    [MenuItem("Bartender/Fill Drink Database")]
    public static void FillDatabase()
    {
        var db = Selection.activeObject as DrinkPairEffectDatabase;

        if (db == null)
        {
            Debug.LogError("Select a DrinkPairEffectDatabase asset first.");
            return;
        }

        db.combinations = new DrinkPairEffect[]
        {
            new DrinkPairEffect { drinkA = DrinkType.Beer, drinkB = DrinkType.Vodka, effect = DrinkEffectType.Helicopter },
            new DrinkPairEffect { drinkA = DrinkType.Beer, drinkB = DrinkType.Rakia, effect = DrinkEffectType.Chicken },
            new DrinkPairEffect { drinkA = DrinkType.Beer, drinkB = DrinkType.OrangeJuice, effect = DrinkEffectType.Fart },
            new DrinkPairEffect { drinkA = DrinkType.Beer, drinkB = DrinkType.GingerTonic, effect = DrinkEffectType.Nothing },
            new DrinkPairEffect { drinkA = DrinkType.Beer, drinkB = DrinkType.Jager, effect = DrinkEffectType.IceCube },
            new DrinkPairEffect { drinkA = DrinkType.Beer, drinkB = DrinkType.BeastBrew, effect = DrinkEffectType.FireBreath },
            new DrinkPairEffect { drinkA = DrinkType.Beer, drinkB = DrinkType.PixiBrew, effect = DrinkEffectType.Shrink },
            new DrinkPairEffect { drinkA = DrinkType.Beer, drinkB = DrinkType.AngelBrew, effect = DrinkEffectType.Chicken },

            new DrinkPairEffect { drinkA = DrinkType.Vodka, drinkB = DrinkType.Rakia, effect = DrinkEffectType.FireBreath },
            new DrinkPairEffect { drinkA = DrinkType.Vodka, drinkB = DrinkType.OrangeJuice, effect = DrinkEffectType.Helicopter },
            new DrinkPairEffect { drinkA = DrinkType.Vodka, drinkB = DrinkType.GingerTonic, effect = DrinkEffectType.Shrink },
            new DrinkPairEffect { drinkA = DrinkType.Vodka, drinkB = DrinkType.Jager, effect = DrinkEffectType.FireBreath },
            new DrinkPairEffect { drinkA = DrinkType.Vodka, drinkB = DrinkType.BeastBrew, effect = DrinkEffectType.Fart },
            new DrinkPairEffect { drinkA = DrinkType.Vodka, drinkB = DrinkType.PixiBrew, effect = DrinkEffectType.Chicken },
            new DrinkPairEffect { drinkA = DrinkType.Vodka, drinkB = DrinkType.AngelBrew, effect = DrinkEffectType.Hiccup },

            new DrinkPairEffect { drinkA = DrinkType.Rakia, drinkB = DrinkType.OrangeJuice, effect = DrinkEffectType.Nothing },
            new DrinkPairEffect { drinkA = DrinkType.Rakia, drinkB = DrinkType.GingerTonic, effect = DrinkEffectType.Hiccup },
            new DrinkPairEffect { drinkA = DrinkType.Rakia, drinkB = DrinkType.Jager, effect = DrinkEffectType.IceCube },
            new DrinkPairEffect { drinkA = DrinkType.Rakia, drinkB = DrinkType.BeastBrew, effect = DrinkEffectType.Fart },
            new DrinkPairEffect { drinkA = DrinkType.Rakia, drinkB = DrinkType.PixiBrew, effect = DrinkEffectType.Shrink },
            new DrinkPairEffect { drinkA = DrinkType.Rakia, drinkB = DrinkType.AngelBrew, effect = DrinkEffectType.Chicken },

            new DrinkPairEffect { drinkA = DrinkType.OrangeJuice, drinkB = DrinkType.GingerTonic, effect = DrinkEffectType.FireBreath },
            new DrinkPairEffect { drinkA = DrinkType.OrangeJuice, drinkB = DrinkType.Jager, effect = DrinkEffectType.Helicopter },
            new DrinkPairEffect { drinkA = DrinkType.OrangeJuice, drinkB = DrinkType.BeastBrew, effect = DrinkEffectType.IceCube },
            new DrinkPairEffect { drinkA = DrinkType.OrangeJuice, drinkB = DrinkType.PixiBrew, effect = DrinkEffectType.Nothing },
            new DrinkPairEffect { drinkA = DrinkType.OrangeJuice, drinkB = DrinkType.AngelBrew, effect = DrinkEffectType.Chicken },

            new DrinkPairEffect { drinkA = DrinkType.GingerTonic, drinkB = DrinkType.Jager, effect = DrinkEffectType.FireBreath },
            new DrinkPairEffect { drinkA = DrinkType.GingerTonic, drinkB = DrinkType.BeastBrew, effect = DrinkEffectType.Helicopter },
            new DrinkPairEffect { drinkA = DrinkType.GingerTonic, drinkB = DrinkType.PixiBrew, effect = DrinkEffectType.Hiccup },
            new DrinkPairEffect { drinkA = DrinkType.GingerTonic, drinkB = DrinkType.AngelBrew, effect = DrinkEffectType.Nothing },

            new DrinkPairEffect { drinkA = DrinkType.Jager, drinkB = DrinkType.BeastBrew, effect = DrinkEffectType.IceCube },
            new DrinkPairEffect { drinkA = DrinkType.Jager, drinkB = DrinkType.PixiBrew, effect = DrinkEffectType.Nothing },
            new DrinkPairEffect { drinkA = DrinkType.Jager, drinkB = DrinkType.AngelBrew, effect = DrinkEffectType.Shrink },

            new DrinkPairEffect { drinkA = DrinkType.BeastBrew, drinkB = DrinkType.PixiBrew, effect = DrinkEffectType.Hiccup },
            new DrinkPairEffect { drinkA = DrinkType.BeastBrew, drinkB = DrinkType.AngelBrew, effect = DrinkEffectType.Helicopter },

            new DrinkPairEffect { drinkA = DrinkType.PixiBrew, drinkB = DrinkType.AngelBrew, effect = DrinkEffectType.Chicken }
        };

        EditorUtility.SetDirty(db);
        AssetDatabase.SaveAssets();

        Debug.Log("Drink database filled successfully!");
    }
}
