using UnityEngine;
using UnityEngine.UI;

public class PopupWindow : MonoBehaviour
{
    [SerializeField] private Button closeButton;

    void Awake()
    {
        if (closeButton != null)
        {
            closeButton.onClick.AddListener(Close);
        }
    }

    public void Close()
    {
        if (Score.Instance != null)
        {
            Score.Instance.AddScore(1);
        }
        Destroy(gameObject);
    }
}
