using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(LevelGenerator))]
public class LevelGenerationMenu : MonoBehaviour
{
    [SerializeField]
    private Button backButton;

    [SerializeField]
    private Slider widthSlider;

    [SerializeField]
    private Slider heightSlider;

    [SerializeField]
    private Dropdown algChoosingDropDown;

    [SerializeField]
    private Toggle keepCellsWithoutNeighboringDeadCells;

    [SerializeField]
    private Button runButton;

    private LevelGenerator levelGenerator;

    private void Awake()
    {
        levelGenerator = GetComponent<LevelGenerator>();

        Assert.IsNotNull(levelGenerator);
        Assert.IsNotNull(backButton);
        Assert.IsNotNull(widthSlider);
        Assert.IsNotNull(heightSlider);
        Assert.IsNotNull(algChoosingDropDown);
        Assert.IsNotNull(keepCellsWithoutNeighboringDeadCells);
        Assert.IsNotNull(runButton);
    }

    private void Start()
    {
        backButton.onClick.AddListener(BackToMenu);
        runButton.onClick.AddListener(GenerateLevel);

        List<NoiseType> noiseTypes = EnumUtility.ToList<NoiseType>();
        int count = noiseTypes.Count;
        for (int i = 0; i < count; ++i)
        {
            algChoosingDropDown.options.Add(new Dropdown.OptionData(noiseTypes[i].ToString()));
        }
    }

    private void OnDestroy()
    {
        backButton.onClick.RemoveListener(BackToMenu);
        runButton.onClick.RemoveListener(GenerateLevel);
    }

    private void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void GenerateLevel()
    {
        NoiseType noise = NoiseType.NoNoise;

        // @note: this is inneficient and bad, but i'm running out of time
        string agorithmType = algChoosingDropDown.options[algChoosingDropDown.value].text;

        List<NoiseType> noiseTypes = EnumUtility.ToList<NoiseType>();
        int count = noiseTypes.Count;
        for (int i = 0; i < count; ++i)
        {
            if (noiseTypes[i].ToString().Equals(agorithmType))
            {
                noise = noiseTypes[i];
                Debug.Log(noise);
            }
        }

        levelGenerator.GenerateMaze(
            1,
            (int)widthSlider.value,
            (int)heightSlider.value,
            noise,
            keepCellsWithoutNeighboringDeadCells.isOn);
    }
}
