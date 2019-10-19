using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    public float lifeTime = 10;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
