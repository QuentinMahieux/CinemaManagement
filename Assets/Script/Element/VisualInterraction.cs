using Unity.VisualScripting;
using UnityEngine;

public class VisualInterraction : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    private Material[] originalMaterials;
    private bool isGlow;
    
    [Header("Storage Settings")]
    public bool isStorage = false;
    public FoodData foodDataKeep;
    

    void Start()
    {
        originalMaterials =  meshRenderer.materials;
    }
    
    public void ActiveOutLine()
    {
        if (isGlow) { return; }
        isGlow = true;
        
        Material[] curentMaterials = meshRenderer.materials;
        Material[] newMaterials = new Material[curentMaterials.Length + 1];
        for (int i = 0; i < curentMaterials.Length; i++)
        {
            newMaterials[i] = curentMaterials[i];
        }
        newMaterials[curentMaterials.Length] = PlayerInteraction.instance.OutLineMaterial;
        meshRenderer.materials = newMaterials;
    }

    public void DesactiveOutLine()
    {
        isGlow = false;
        meshRenderer.materials = originalMaterials;
    }

    public FoodData GetFoodData()
    {
        if (isStorage)
        {
            return foodDataKeep;
        }
        return null;
    }
}
