using TMPro;
using UnityEngine;

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

    public void UpdateChancesText()
    {
        chancesTexts[GameManager.instance.Chances].gameObject.SetActive(true);
    }
}
