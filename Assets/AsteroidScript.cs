using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public float minSpeed, maxSpeed;
    public float minRotation, maxRotation;
    public float minScale, maxScale;
    public GameObject explosion;
    public AudioClip[] sounds;

    private Rigidbody asteroid;
    private float scale = 1;

    void Start()
    {
        asteroid = GetComponent<Rigidbody>();
        asteroid.velocity = Vector3.back * Random.Range(minSpeed, maxSpeed);
        asteroid.angularVelocity = Random.insideUnitSphere * Random.Range(minRotation, maxRotation);
        scale = Random.Range(minScale, maxScale);
        transform.localScale = new Vector3(scale, scale, scale);
        asteroid.mass *= scale * scale * scale;
    }

    void Update()
    {
        asteroid.position = new Vector3(asteroid.position.x, 0, asteroid.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            int soundNumber = Random.Range(0, sounds.Length);
            PlayClip(sounds[soundNumber], 0.9f * scale);
        }
        //if (collision.gameObject.tag == "Player")
        //{
        //    GameObject explosionInstance = Instantiate(explosion, transform.position, Quaternion.identity);
        //    explosionInstance.GetComponent<Rigidbody>().velocity = asteroid.velocity / 3;
        //    explosionInstance.transform.localScale = new Vector3(scale, scale, scale) * 5;
        //    Destroy(gameObject);
        //}
    }

    void PlayClip(AudioClip audioClip, float volume)
    {
        GameObject tmpGameObject = new GameObject();
        AudioSource audioSource = tmpGameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();
        Destroy(tmpGameObject, audioSource.clip.length);
    }
}
