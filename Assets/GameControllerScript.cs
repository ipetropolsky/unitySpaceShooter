using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
    public bool gamePaused;
    public bool gameOver;
    public GameObject menuUI;
    private float unlockPlayerTime;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameController");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        } else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void Start()
    {
        InitialSetup();
    }

    public void Update()
    {
        if (!gameOver && Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                HideMenu();
            } else
            {
                ShowMenu();
            }
        }
        if (gamePaused && Input.GetKeyDown(KeyCode.Return))
        {
            ReloadScene();
        }
    }

    public void GameOver()
    {
        gameOver = true;
        StartCoroutine(ShowMenuCoroutine(3));
    }

    public void ShowMenu()
    {
        gamePaused = true;
        menuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void HideMenu()
    {
        gamePaused = false;
        menuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    private IEnumerator ShowMenuCoroutine(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        ShowMenu();
    }

    public void ReloadScene()
    {
        InitialSetup();
        SceneManager.LoadScene("Field");
    }

    public void InitialSetup()
    {
        HideMenu();
        gameOver = false;
        unlockPlayerTime = Time.time + 2;
    }
}
