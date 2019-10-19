using UnityEngine;

public class GoalMagneticScript : MonoBehaviour
{
    private Rigidbody catched;
    private float decreasing = 0.99f;
    private GameControllerScript gameController;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();
    }

    void Update()
    {
        if (catched && Mathf.Abs(catched.transform.position.x) < Mathf.Abs(transform.position.x) && !gameController.gamePaused && !gameController.gameOver)
        {
            Vector3 direction = (transform.position - catched.transform.position);
            float distance = Mathf.Max(Vector3.Distance(transform.position, catched.transform.position), 1f);
            catched.AddForce(direction * 75 / distance, ForceMode.Force);
            catched.transform.localScale *= decreasing;
            catched.mass *= decreasing;
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
