using System;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public static PlayerHand instance;
    
    public Transform hand;
    public GameObject actualFoodPrefab;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("There is more than one PlayerHand in scene!");
            Destroy(this);
        }
    }

    public void TakeFood(FoodData food)
    {
        if (!actualFoodPrefab)
        {
            GameObject foodPrefab = Instantiate(food.prefab, Vector3.zero ,Quaternion.identity, hand);
            foodPrefab.transform.localPosition = Vector3.zero;
            actualFoodPrefab = foodPrefab;
        }
    }
}
