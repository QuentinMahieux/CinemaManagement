using UnityEngine;

[CreateAssetMenu(fileName = "FoodData", menuName = "Scriptable Objects/FoodData")]
public class FoodData : ScriptableObject
{
    public string name;
    
    public GameObject prefab;
}
