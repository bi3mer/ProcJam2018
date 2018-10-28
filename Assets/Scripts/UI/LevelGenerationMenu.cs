using UnityEngine.SceneManagement;
using UnityEngine.Assertions;
using UnityEngine.UI;
using UnityEngine;

public class LevelGenerationMenu : MonoBehaviour
{
    [SerializeField]
    private Button backButton;

    private void Awake()
    {
        Assert.IsNotNull(backButton);
    }

    private void Start()
    {
        backButton.onClick.AddListener(BackToMenu);   
    }

    private void OnDestroy()
    {
        backButton.onClick.RemoveListener(BackToMenu);
    }

    private void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
