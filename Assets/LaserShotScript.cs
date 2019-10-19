using UnityEngine;

public class LaserShotScript : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public GameObject explosion;
    public AudioClip clip;

    private float destroyTime;

    void Start()
    {
        Rigidbody shot = GetComponent<Rigidbody>();
        shot.velocity += Vector3.forward * speed;
        destroyTime = Time.time + lifeTime;
        PlayClip(clip, 0.1f);
    }

    private void Update()
    {
        if (Time.time > destroyTime)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Instantiate(explosion, contact.point, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    void PlayClip(AudioClip audioClip, float volume) {
        GameObject tmpGameObject = new GameObject();
        AudioSource audioSource = tmpGameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();
        Destroy(tmpGameObject, audioSource.clip.length);
    }
}
