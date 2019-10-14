using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalMagneticScript : MonoBehaviour
{
    private Rigidbody catched;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (catched && Mathf.Abs(catched.transform.position.x) < Mathf.Abs(transform.position.x))
        {
            Vector3 direction = (transform.position - catched.transform.position);
            float distance = Vector3.Distance(transform.position, catched.transform.position);
            catched.AddForce(direction * 75 / Mathf.Max(distance, 1), ForceMode.Force);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Asteroid")
        {
            Rigidbody asteroid = other.GetComponent<Rigidbody>();
            catched = asteroid;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        catched = null;
    }
}
