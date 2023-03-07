using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Game Over UI")]
    [SerializeField]
    GameObject _gameOverUI;
    [SerializeField]
    RectTransform _gameOverTitle;
    [SerializeField]
    RectTransform _tryAgainButtonRect;
    [SerializeField]
    Button _tryAgainButton;

    [Header("Level Complete UI")]
    [SerializeField]
    GameObject _levelCompleteUI;
    [SerializeField]
    RectTransform _levelCompleteTitle;
    [SerializeField]
    RectTransform _borderScoreCombo;
    [SerializeField]
    TextMeshProUGUI _winScreenScoreText;
    [SerializeField]
    TextMeshProUGUI _winScreenComboText;
    [SerializeField]
    RectTransform _nextLevelButtonRect;
    [SerializeField]
    Button _nextLevelButton;

    [Header("Gameplay UI")]
    [SerializeField]
    RectTransform _gameplayUI;
    [SerializeField]
    Image _LevelSlider;
    [SerializeField]
    TextMeshProUGUI _currentLevelText;
    [SerializeField]
    TextMeshProUGUI _nextLevelText;

    [Header("Chances Text")]
    [SerializeField]
    TextMeshProUGUI[] _chancesTexts;

    [Header("Score & Combo")]
    [SerializeField]
    TextMeshProUGUI _score;
    [SerializeField]
    TextMeshProUGUI _combo;

    [Header("Triggers")]
    [SerializeField]
    RectTransform _leftTrigger;
    [SerializeField]
    RectTransform _rightTrigger;

    [Header("Tutorial")]
    [SerializeField]
    GameObject _tutorialUI;

    [Header("Screen Load")]
    [SerializeField]
    GameObject _screenLoadUI;
    [SerializeField]
    RectTransform _LeftScreenLoad;
    [SerializeField]
    RectTransform _RightScreenLoad;

    private void Awake()
    {
       Instance = this;
    }

    private void OnEnable()
    {
        LevelManager.LevelComplete += LevelComplete;
        GameManager.OnGameOver += OnGameOver;
    }

    private void OnDisable()
    {
        LevelManager.LevelComplete -= LevelComplete;
        GameManager.OnGameOver -= OnGameOver;
    }

    private void Start()
    {
        LoadScreenOpen();
    }

    void LoadScreenOpen()
    {
        if(LevelManager.instance.Level == 1)
        {
            _tutorialUI.SetActive(true);
        }

        _screenLoadUI.SetActive(true);
        DotweenUtils.MoveUIAndEnable(_LeftScreenLoad, 3000, 1.5f);
        DotweenUtils.MoveUIAndEnable(_RightScreenLoad, -3000, 1.5f);
    }

    public void LoadScreenClose()
    {
        StartCoroutine(ScreenClose());
    }
   
    void OnGameOver()
    {
        StartCoroutine(GameOverUI());
    }
    void LevelComplete()
    {
        StartCoroutine(LevelCompleteUI());
    }

    public void DisableTutorial()
    {
        _tutorialUI.SetActive(false);
        ObjectSpawnerManager.instance.StartSpawning();
    }

    IEnumerator ScreenClose()
    {
        _tryAgainButton.enabled = false;
        _nextLevelButton.enabled = false;

        DotweenUtils.MoveUIAndEnable(_LeftScreenLoad, -3000, 1.5f);
        DotweenUtils.MoveUIAndEnable(_RightScreenLoad, 3000, 1.5f);

        yield return new WaitForSeconds(2f);
        LevelManager.instance.ReloadLevel();
    }
    IEnumerator LevelCompleteUI()
    {
        DotweenUtils.MoveUIAndDisable(_gameplayUI, 450, 0.5f);
        _levelCompleteUI.SetActive(true);

        DotweenUtils.MoveUIAndEnable(_levelCompleteTitle, -750, 1.5f);
        DotweenUtils.MoveUIAndEnable(_nextLevelButtonRect, 850, 1.5f);
        DotweenUtils.ScoreComboUIFormSide(_borderScoreCombo, 1450, 1.5f, _winScreenScoreText, _winScreenComboText);

        _leftTrigger.gameObject.SetActive(false);
        _rightTrigger.gameObject.SetActive(false);

        UIManager.Instance.UpdateLevelText(LevelManager.instance.Level);

        yield return new WaitForSeconds(0.5f);

        foreach (var chance in _chancesTexts)
        {
            DotweenUtils.ReversePopoutScale(chance.transform, 1f, 0);
        }

        yield return null;
    }
    IEnumerator GameOverUI()
    {
        DotweenUtils.MoveUIAndDisable(_gameplayUI, 450, 0.5f);
        _gameOverUI.SetActive(true);
        DotweenUtils.MoveUIAndEnable(_gameOverTitle, -750, 1.5f);
        DotweenUtils.MoveUIAndEnable(_tryAgainButtonRect, 1000, 1.5f);

        _leftTrigger.gameObject.SetActive(false);
        _rightTrigger.gameObject.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        foreach (var chance in _chancesTexts)
        {
            DotweenUtils.ReversePopoutScale(chance.transform, 1f, 0);
        }

        yield return null;
    }

    public void UpdateLevelText(int level)
    {
        _currentLevelText.text = level.ToString();
        _nextLevelText.text = (level + 1).ToString();
    }

    public void UpdateLevelSlider(float value, float maxValue)
    {
        _LevelSlider.fillAmount = value / maxValue;
    }

    public void UpdateScore()
    {
        _score.text = ScoreAndCombo.instance.Score.ToString();
    }

    public void UpdateCombo(Transform brokenObjectTransform)
    {
        if (ScoreAndCombo.instance.PlayerHits >= 5)
        {
            Vector3 worldPosition = brokenObjectTransform.position;
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);
            _combo.text = ScoreAndCombo.instance.Combo.ToString() + "X";
            DotweenUtils.MoveUpFadeOut(_combo, 0.5f, screenPosition);
        }
    }

    public void UpdateResetChances()
    {
        for (int i = 0; i < _chancesTexts.Length; i++)
        {
            DotweenUtils.ReversePopoutScale(_chancesTexts[i].transform, 0.5f, 0f);
        }
    }

    public void UpdateChancesText()
    {
        DotweenUtils.ScalePopout(_chancesTexts[GameManager.instance.Chances].transform, 0.5f, 1f);
        _chancesTexts[GameManager.instance.Chances].gameObject.SetActive(true);
    }
}
