using System;
using UnityEngine;

public class FoodCuite : DefaultFood
{
    [Header("Cooking Food")]
    public MeshRenderer meshRenderer;
    public GameObject newFoodPrefab;

    public float timeToHot;
    public float actualTimeToHot;
    [SerializeField] private bool isCooking;

    void OnEnable()
    {
        isCooking = false;
    }
    
    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        if (collision.gameObject.CompareTag("Baking Tray"))
        {
            isCooking = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (isCooking && !other.gameObject.CompareTag("Baking Tray"))
        {
            isCooking = false;
        }
    }

    void Update()
    {
        if (!isCooking)
        {
            return;
        }
        actualTimeToHot += Time.deltaTime;
        if (actualTimeToHot > timeToHot)
        { 
            Instantiate(newFoodPrefab, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
        
    }
}
