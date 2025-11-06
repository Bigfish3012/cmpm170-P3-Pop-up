using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PopupWindow : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    [SerializeField] private Button closeButton;

    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector2 dragOffset;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayRandomErrorSound();
        }
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

    public void OnPointerDown(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, eventData.pressEventCamera, out var localPoint);
        dragOffset = rectTransform.anchoredPosition - localPoint;
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, eventData.pressEventCamera, out var localPoint);
        rectTransform.anchoredPosition = localPoint + dragOffset;
    }
}
