using UnityEngine.SceneManagement;
using UnityEngine.Assertions;
using UnityEngine.UI;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused
    {
        get;
        private set;
    }

    [SerializeField]
    private GameObject playerHealth;

    [SerializeField]
    private Button resumeButton;

    [SerializeField]
    private Button quitButton;

    private void Awake()
    {
        Paused = false;
        Assert.IsNotNull(playerHealth);
        Assert.IsNotNull(resumeButton);
        Assert.IsNotNull(quitButton);
    }

    private void Start()
    {
        resumeButton.onClick.AddListener(UnPauseGame);
        quitButton.onClick.AddListener(Quit);
        resumeButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        resumeButton.onClick.RemoveListener(UnPauseGame);
        quitButton.onClick.RemoveListener(Quit);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                UnPauseGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Paused = true;
        playerHealth.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void UnPauseGame()
    {
        Paused = false;
        playerHealth.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt(PlayerPrefConstants.Level, 1);
        PlayerPrefs.SetInt(PlayerPrefConstants.Health, -1);
        SceneManager.LoadScene(0);
    }
}
