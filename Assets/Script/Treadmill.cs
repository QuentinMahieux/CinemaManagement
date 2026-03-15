using UnityEngine;

public class Treadmill : MonoBehaviour
{
    public float forceMove = 4f;

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * forceMove);
        }
    }
}
