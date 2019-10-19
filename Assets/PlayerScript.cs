using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public float tiltX, tiltZ;
    public float xMin, xMax, zMin, zMax;
    public GameObject lazerShot;
    public Transform headGun;
    public float shotDelay;
    public float shotVelocity;
    public GameObject explosion;
    
    private Rigidbody player;
    private float nextShotTime;
    private GameControllerScript gameController;

    void Start()
    {
        player = GetComponent<Rigidbody>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();
    }

    void Update()
    {
        if (gameController.gameOver || gameController.gamePaused) {
            return;
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        player.velocity = new Vector3(moveX, 0, moveZ) * speed;
        
        player.rotation = Quaternion.Euler(player.velocity.z * tiltX, 0, -player.velocity.x * tiltZ);
        float x = Mathf.Clamp(player.position.x, xMin, xMax);
        float z = Mathf.Clamp(player.position.z, zMin, zMax);
        player.position = new Vector3(x, 0, z);

        if (Time.time > nextShotTime && (Input.GetButton("Fire1") || Input.GetKeyDown(KeyCode.Space)))
        {
            GameObject shot = Instantiate(lazerShot, headGun.position, Quaternion.identity);
            shot.GetComponent<Rigidbody>().velocity = player.velocity * shotVelocity;
            nextShotTime = Time.time + shotDelay;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Asteroid")
        {
            GameObject explosionInstance = Instantiate(explosion, transform.position, Quaternion.identity);
            explosionInstance.GetComponent<Rigidbody>().velocity = player.velocity / 10;
            explosionInstance.transform.localScale = new Vector3(20, 20, 20);
            Destroy(other.gameObject);
            Destroy(gameObject);

            gameController.GameOver();
        }
    }

}
