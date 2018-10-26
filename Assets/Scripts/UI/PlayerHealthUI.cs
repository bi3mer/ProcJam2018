using UnityEngine.Assertions;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField]
    private Healthful playerHealth;

    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();

        Assert.IsNotNull(playerHealth);
        Assert.IsNotNull(text);
    }

    private void Update()
    {
        text.text = $"{playerHealth.Health}/{playerHealth.MaxHealth}";
    }
}
