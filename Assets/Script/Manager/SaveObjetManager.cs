using System.Collections.Generic;
using UnityEngine;

public class SaveObjetManager : MonoBehaviour
{
    public static SaveObjetManager instance;

    // List<VisualInterraction> listVisualInterraction;
    
    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("There is more than one SaveObjetManager in scene");
            Destroy(gameObject);
        }
    }
    
}
