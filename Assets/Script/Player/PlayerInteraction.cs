using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public static PlayerInteraction instance;
    public float range = 5f;
    public Material OutLineMaterial;
    
    [SerializeField] private VisualInterraction lastInteraction;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("There is more than one PlayerInteraction in scene");
            Destroy(gameObject);
        }
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, range))
        {
            if (hit.transform.gameObject.CompareTag("Interactable"))
            {
                VisualInterraction newInteraction = hit.transform.gameObject.GetComponent<VisualInterraction>();
                if (newInteraction != lastInteraction && lastInteraction)
                {
                    lastInteraction.DesactiveOutLine();
                }
                lastInteraction = newInteraction;
                lastInteraction.ActiveOutLine();

                if (Input.GetMouseButtonDown(0))
                {
                    PlayerHand.instance.TakeFood(lastInteraction.GetFoodData());
                }
            }
            else if (lastInteraction)
            {
                lastInteraction.DesactiveOutLine();
                lastInteraction = null;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * range);
    }
}
