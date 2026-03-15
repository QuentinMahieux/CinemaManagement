using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform exit;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            other.transform.position = exit.position;
        }
    }
}
