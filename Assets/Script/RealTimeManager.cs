using UnityEngine;

public class RealTimeManager : MonoBehaviour
{
    public Transform globalLight;

    [Tooltip("Caucher pour activer le cycle jour/nuit en temps réel")]
    public bool isCycleActive = true;
    
    public float actualDate;
    public float sunStart = 6f;
    
    void Update()
    {
        if (isCycleActive)
        {
            actualDate = (float)System.DateTime.Now.Minute/60 + System.DateTime.Now.Hour;
        }
        else
        {
            actualDate = 13f;
        }
        globalLight.localRotation = Quaternion.Euler((actualDate - sunStart) * 15, 0, 0);
    }
}