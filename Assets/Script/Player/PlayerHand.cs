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
    
    public void TakeFood(VisualInterraction food)
    {
        if (actualFood)
        {
            return;
        }

        food.gameObject.transform.SetParent(hand);
        food.gameObject.transform.localPosition = Vector3.zero;
            
        food.foodDataKeep.boxCollider.enabled = false;
        PlayerHand.instance.actualFood = food.foodDataKeep;
        
        food.foodDataKeep.rb.linearVelocity = Vector3.zero;
        food.foodDataKeep.rb.angularVelocity = Vector3.zero;
        food.foodDataKeep.rb.useGravity = false;
        food.foodDataKeep.rb.constraints = RigidbodyConstraints.FreezeAll;
            

    }
}
