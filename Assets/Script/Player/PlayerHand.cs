using System;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public static PlayerHand instance;
    
    public Transform hand;
    public DefaultFood actualFood;

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

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && actualFood)
        {
            actualFood.ThrowFood();
        }
    }
    
    public void TakeFood(FoodData food)
    {
        if (actualFood)
        {
            return;
        }
        VisualInterraction elementReInstanciate = null;

        for (int i = 0; i < SaveObjetManager.instance.listVisualInterraction.Count; i++)
        {
            if (SaveObjetManager.instance.listVisualInterraction[i].foodDataKeep.foodData == food)
            {
                elementReInstanciate = SaveObjetManager.instance.listVisualInterraction[i];
                SaveObjetManager.instance.listVisualInterraction.RemoveAt(i);
                break;
            }
        }
        
        if (!elementReInstanciate)
        {
            GameObject foodPrefab = Instantiate(food.prefab, Vector3.zero ,Quaternion.identity, hand);
            foodPrefab.transform.localPosition = Vector3.zero;
        }
        else
        {
            elementReInstanciate.gameObject.SetActive(true);
            elementReInstanciate.gameObject.transform.SetParent(hand);
            elementReInstanciate.gameObject.transform.localPosition = Vector3.zero;
            
            elementReInstanciate.foodDataKeep.boxCollider.enabled = false;
            PlayerHand.instance.actualFood = elementReInstanciate.foodDataKeep;
        
            elementReInstanciate.foodDataKeep.rb.linearVelocity = Vector3.zero;
            elementReInstanciate.foodDataKeep.rb.angularVelocity = Vector3.zero;
            elementReInstanciate.foodDataKeep.rb.useGravity = false;
            elementReInstanciate.foodDataKeep.rb.constraints = RigidbodyConstraints.FreezeAll;
            

        }
    }
}
