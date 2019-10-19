using UnityEngine;

public class BoundaryScript : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
