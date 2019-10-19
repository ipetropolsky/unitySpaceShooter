using UnityEngine;

public class AsteroidEmitterScript : MonoBehaviour
{
    public GameObject[] asteroids;
    public float asteroidDelay;

    private float nextAsteroidTime = -1;

    void Update()
    {
        if (Time.time > nextAsteroidTime)
        {
            float deltaX = Random.Range(-17, 17);
            int asteroidNumber = Random.Range(0, asteroids.Length);
            Instantiate(
                asteroids[asteroidNumber],
                new Vector3(transform.position.x + deltaX, transform.position.y, transform.position.z),
                Quaternion.identity
            );
            nextAsteroidTime = Time.time + asteroidDelay;
        }
    }
}
