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
    RectTransform _gameOverTargetPosition;
    [SerializeField]
    RectTransform _gameOverTitle;
    [SerializeField]
    RectTransform _tryAgainButtonRect;
    [SerializeField]
    RectTransform _tryAgainButtonTargetPosition;
    [SerializeField]
    Button _tryAgainButton;

    [Header("Level Complete UI")]
    [SerializeField]
    GameObject _levelCompleteUI;
    [SerializeField]
    RectTransform _levelCompleteTitle;
    [SerializeField]
    RectTransform _levelCompleteTitleTargetPosition;
    [SerializeField]
    RectTransform _borderScoreCombo;
    [SerializeField]
    RectTransform _borderScoreComboTargetPosition;
    [SerializeField]
    TextMeshProUGUI _winScreenScoreText;
    [SerializeField]
    TextMeshProUGUI _winScreenComboText;
    [SerializeField]
    RectTransform _nextLevelButtonRect;
    [SerializeField]
    RectTransform _nextLevelButtonTargetPosition;
    [SerializeField]
    Button _nextLevelButton;

    [Header("Gameplay UI")]
    [SerializeField]
    RectTransform _gameplayUI;
    [SerializeField]
    RectTransform _gameplayUITargetPosition;
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
    RectTransform _leftScreenLoad;
    [SerializeField]
    RectTransform _leftScreenLoadTargetPosition;
    [SerializeField]
    RectTransform _rightScreenLoad;
    [SerializeField]
    RectTransform _rightScreenLoadTargetPosition;
    [SerializeField]
    RectTransform _leftScreenLoadStartPosition;
    [SerializeField]
    RectTransform _rightScreenLoadStartPosition;

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
        DotweenUtils.MoveUIAndEnable(_leftScreenLoad, _leftScreenLoadTargetPosition, 1.5f);
        DotweenUtils.MoveUIAndEnable(_rightScreenLoad, _rightScreenLoadTargetPosition, 1.5f);
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

        DotweenUtils.MoveUIAndEnable(_leftScreenLoad, _leftScreenLoadStartPosition, 1.5f);
        DotweenUtils.MoveUIAndEnable(_rightScreenLoad, _rightScreenLoadStartPosition, 1.5f);

        yield return new WaitForSeconds(2f);
        LevelManager.instance.ReloadLevel();
    }
    IEnumerator LevelCompleteUI()
    {
        DotweenUtils.MoveUIAndDisable(_gameplayUI, _gameplayUITargetPosition, 0.5f);
        _levelCompleteUI.SetActive(true);

        DotweenUtils.MoveUIAndEnable(_levelCompleteTitle, _levelCompleteTitleTargetPosition, 1.5f);
        DotweenUtils.MoveUIAndEnable(_nextLevelButtonRect, _nextLevelButtonTargetPosition, 1.5f);
        DotweenUtils.ScoreComboUIFormSide(_borderScoreCombo, _borderScoreComboTargetPosition, 1.5f, _winScreenScoreText, _winScreenComboText);

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
        DotweenUtils.MoveUIAndDisable(_gameplayUI, _gameplayUITargetPosition, 0.5f);
        _gameOverUI.SetActive(true);
        DotweenUtils.MoveUIAndEnable(_gameOverTitle, _gameOverTargetPosition, 1.5f);
        DotweenUtils.MoveUIAndEnable(_tryAgainButtonRect, _tryAgainButtonTargetPosition, 1.5f);

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
