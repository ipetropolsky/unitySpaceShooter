using UnityEngine;

public class PlayerGoalScript : MonoBehaviour
{

    public AudioClip sound;
    public float soundVolume = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Asteroid")
        {
            Rigidbody asteroid = other.gameObject.GetComponent<Rigidbody>();
            if (asteroid.transform.position.z > transform.position.z)
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
