using UnityEngine;

public class GoalScript : MonoBehaviour
{

    public AudioClip sound;
    public float soundVolume = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Asteroid")
        {

            Rigidbody asteroid = other.gameObject.GetComponent<Rigidbody>();
            if (Mathf.Abs(asteroid.transform.position.x) < Mathf.Abs(transform.position.x))
            {
                PlayClip(sound, soundVolume);
            }
        }
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
