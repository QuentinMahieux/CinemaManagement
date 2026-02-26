using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlateFood : DefaultFood
{
    [Header("Plate Food")]
    public List<Recipe> listFoodToRecipe = new List<Recipe>();

    protected override void Start()
    {
        base.Start();
        foreach (var food in listFoodToRecipe)
        {
            food.inPlate = false;
            food.foodPrefab.SetActive(false);
        }
    }
}
[Serializable]
public class Recipe
{
    public FoodData foodData;
    public GameObject foodPrefab;
    public bool inPlate;

}