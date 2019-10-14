using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{

    public AudioClip sound;
    public float soundVolume = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Asteroid")
        {
            PlayClip(sound, soundVolume);
            //Rigidbody asteroid = other.GetComponent<Rigidbody>();
            //Vector3 direction = (transform.position - asteroid.transform.position).normalized;
            //Debug.Log(direction);
            //asteroid.AddForce(new Vector3(10, 0, 0) * 1, ForceMode.VelocityChange);
            //asteroid.AddForce(direction * 1, ForceMode.Force);
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
