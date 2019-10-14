using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WFXExplosionScript : MonoBehaviour
{
    public float speed = 1;
    private ParticleSystem ps;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        var main = ps.main;
        main.simulationSpeed = speed;
    }
}
