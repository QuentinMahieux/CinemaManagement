using UnityEngine;

public class Package : DefaultFood
{
    [Header("Package Settings")]

    public int numberElementSpawn;
    public FoodData elementToSpawn;
    

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        
        float numberToInstantiate = numberElementSpawn;
        VisualInterraction elementReInstanciate = null;
        if (!collision.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < SaveObjetManager.instance.listVisualInterraction.Count; i++)
            {
                if (SaveObjetManager.instance.listVisualInterraction[i].foodDataKeep.foodData == elementToSpawn)
                {
                    elementReInstanciate = SaveObjetManager.instance.listVisualInterraction[i];
                    elementReInstanciate.transform.SetParent(transform);
                    elementReInstanciate.gameObject.SetActive(true);
                    elementReInstanciate.gameObject.transform.localPosition = Vector3.zero;
                    
                    Rigidbody rbInstance =  elementReInstanciate.GetComponent<Rigidbody>();
                    Vector3 randomDirection = Random.onUnitSphere;
                    rbInstance.AddForce(randomDirection * speed, ForceMode.Impulse);
                    
                    
                    SaveObjetManager.instance.listVisualInterraction.RemoveAt(i);
                    numberToInstantiate--;
                }
            }
        
            for (int i = 0; i < numberToInstantiate; i++)
            {
                GameObject foodPrefab = Instantiate(elementToSpawn.prefab, Vector3.zero ,Quaternion.identity, transform);
                foodPrefab.transform.localPosition = Vector3.zero;
                foodPrefab.transform.SetParent(null);
                
                Rigidbody rbInstance = foodPrefab.GetComponent<Rigidbody>();
                Vector3 randomDirection = Random.onUnitSphere;
                rbInstance.AddForce(randomDirection * speed, ForceMode.Impulse);
            }
            Destroy(gameObject);
        }
    }
}
