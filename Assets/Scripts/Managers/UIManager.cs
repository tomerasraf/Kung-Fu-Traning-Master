using TMPro;
using UnityEngine;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Chances Text")]
    [SerializeField]
    private TextMeshProUGUI[] chancesTexts;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateResetChances()
    {
        for (int i = 0; i < chancesTexts.Length; i++)
        {
            DotweenUtils.ReversePopoutScale(chancesTexts[i].transform, 0.5f, 0f);       
        }
    }

    public void UpdateChancesText()
    {
        DotweenUtils.ScalePopout(chancesTexts[GameManager.instance.Chances].transform, 0.5f, 1f);
        chancesTexts[GameManager.instance.Chances].gameObject.SetActive(true);
    }
}
