using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RecipeTriggerBar : MonoBehaviour
{
   
    public DrinkMixer mixer;            // Drag your DrinkMixer here
    public Spawner spawner; // assign in inspector
        
    public float reactionTime = 1f;                            // Global reaction time for any recipe
    public bool autoDestroy = true;                            // Should objects be destroyed after recipe trigger?

    private readonly HashSet<Collider> collidersInTrigger = new HashSet<Collider>();
    private readonly HashSet<Collider> lockedColliders = new HashSet<Collider>(); // Colliders that cannot be reused until they exit and re-enter

    private float timer = 0f;                                  // Global reaction timer
    private List<Collider> activeColliders = new List<Collider>(); // Colliders used in the matched recipe

    private void OnTriggerEnter(Collider other)
    {
        if (other == null || other.gameObject == null) return;
        collidersInTrigger.Add(other);

        // If collider was previously locked, unlock it now (fresh entry)
        lockedColliders.Remove(other);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == null || other.gameObject == null) return;

        collidersInTrigger.Remove(other);
        lockedColliders.Remove(other); // leaving the zone always clears lock

        //ResetReaction(); // reset recipe if ingredients leave
    }

    private void Update()
    {
        if (collidersInTrigger.Count == 3) 
        { 
            TryMakeCocktail(); 
        }
        //        if (collidersInTrigger.Count == 0)
        //        {
        //            ResetReaction();
        //            return;
        //        }

        //        If no recipe is active, or if the active one no longer matches, find the best match
        //        if (activeRecipe == null || !RecipeMatches(activeRecipe, out _))
        //        {
        //            FindBestMatch();
        //        }

        //        If a recipe is active, process timer
        //        if (activeRecipe != null && RecipeMatches(activeRecipe, out List<Collider> usedAgain))
        //        {
        //            timer += Time.deltaTime;

        //            if (timer >= reactionTime)
        //            {
        //                Trigger recipe event
        //               activeRecipe.onRecipeMatched?.Invoke();

        //                if (autoDestroy)
        //                {
        //                     Destroy the used objects
        //                    foreach (var col in activeColliders)
        //                    {
        //                        if (col != null && col.gameObject != null)
        //                            Destroy(col.gameObject);
        //}
        //                }
        //                else
        //{
        //    Lock the used objects until they leave and re - enter
        //                    foreach (var col in activeColliders)
        //    {
        //        lockedColliders.Add(col);
        //    }
        //}

        //ResetReaction(); // Reset so it won’t trigger repeatedly
        //            }
        //        }
        //        else
        //{
        //    ResetReaction();
        //}
    }

    private void TryMakeCocktail()
    {
        // Convert colliders → DrinkItems
        List<DrinkItem> drinks = new List<DrinkItem>();

        foreach (var col in collidersInTrigger)
        {
            DrinkItem item = col.GetComponent<DrinkItem>();
            if (item != null)
                drinks.Add(item);
        }

        // Only proceed if exactly 3 valid drinks
        if (drinks.Count != 3)
            return;

        // Mix effects
        DrinkEffectType[] effects = mixer.Mix(
            drinks[0].type,
            drinks[1].type,
            drinks[2].type
        );

        // Spawn cocktail with effects
        GameObject cocktail = spawner.SpawnWithEffects(effects);

        // Destroy old drinks
        foreach (var drink in drinks)
            Destroy(drink.gameObject);

        // Clear trigger
        collidersInTrigger.Clear();

        Debug.Log("Cocktail created with effects: " + string.Join(", ", effects));
    }


    //private void ResetReaction()
    //{
    //    activeRecipe = null;
    //    activeColliders.Clear();
    //    timer = 0f;
    //}

    //private void FindBestMatch()
    //{
    //    Recipe best = null;
    //    List<Collider> bestColliders = null;
    //    int bestCount = -1;

    //    foreach (var recipe in recipes)
    //    {
    //        if (RecipeMatches(recipe, out List<Collider> usedColliders))
    //        {
    //            int count = recipe.ingredients.Count;
    //            if (count > bestCount)
    //            {
    //                best = recipe;
    //                bestColliders = usedColliders;
    //                bestCount = count;
    //            }
    //        }
    //    }

    //    if (best != null)
    //    {
    //        activeRecipe = best;
    //        activeColliders = bestColliders;
    //        timer = 0f; // start reaction timer
    //    }
    //}



    public void SpawnCocktailFromRecipe()
    {
        if (activeColliders.Count != 3)
        {
            Debug.LogError("RecipeTriggerBar expected exactly 3 ingredients.");
            return;
        }

        // Convert colliders → DrinkTypes
        DrinkItem d1 = activeColliders[0].GetComponent<DrinkItem>();
        DrinkItem d2 = activeColliders[1].GetComponent<DrinkItem>();
        DrinkItem d3 = activeColliders[2].GetComponent<DrinkItem>();

        if (d1 == null || d2 == null || d3 == null)
        {
            Debug.LogError("One or more objects do not have a DrinkItem component.");
            return;
        }

        DrinkEffectType[] effects = mixer.Mix(d1.type, d2.type, d3.type);

        // Spawn cocktail with effects
        GameObject cocktail = spawner.SpawnWithEffects(effects);

        Debug.Log("Spawned cocktail with effects: " + string.Join(", ", effects));
    }


    //private bool RecipeMatches(Recipe recipe, out List<Collider> usedColliders)
    //{
    //    List<Collider> available = new List<Collider>(collidersInTrigger);
    //    usedColliders = new List<Collider>();

    //    foreach (var ingredient in recipe.ingredients)
    //    {
    //        string target = ingredient.ToLowerInvariant();
    //        bool found = false;

    //        for (int i = 0; i < available.Count; i++)
    //        {
    //            var col = available[i];
    //            if (col != null && col.gameObject != null &&
    //                !lockedColliders.Contains(col) && // skip locked colliders
    //                col.gameObject.name.Equals(target, StringComparison.OrdinalIgnoreCase))
    //            {
    //                usedColliders.Add(col);
    //                available.RemoveAt(i); // consume this collider
    //                found = true;
    //                break;
    //            }
    //        }

    //        if (!found)
    //            return false; // missing ingredient
    //    }

    //    return true;
    //}
}
