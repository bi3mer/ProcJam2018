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

    private void Awake()
    {
        Paused = false;
        Assert.IsNotNull(playerHealth);
        Assert.IsNotNull(resumeButton);
    }

    private void Start()
    {
        resumeButton.onClick.AddListener(UnPauseGame);
        resumeButton.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        resumeButton.onClick.RemoveListener(UnPauseGame);
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
        Time.timeScale = 0;
    }

    public void UnPauseGame()
    {
        Paused = false;
        playerHealth.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
