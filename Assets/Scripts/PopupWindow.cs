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

    void Start()
    {
        RandomizeCloseButtonCorner();
    }

    private void RandomizeCloseButtonCorner()
    {
        if (closeButton == null) return;
        RectTransform closeRect = closeButton.GetComponent<RectTransform>();
        int corner = Random.Range(0, 4);
        switch (corner)
        {
            case 0: //Top Left
                closeRect.anchorMin = new Vector2(0, 1);
                closeRect.anchorMax = new Vector2(0, 1);
                closeRect.pivot = new Vector2(0.5f, 0.5f);
                closeRect.anchoredPosition = new Vector2(22, -22);
                break;

            case 1: //Top Right
                closeRect.anchorMin = new Vector2(1, 1);
                closeRect.anchorMax = new Vector2(1, 1);
                closeRect.pivot = new Vector2(0.5f, 0.5f);
                closeRect.anchoredPosition = new Vector2(-22, -22);
                break;
        }
        closeRect.anchoredPosition += new Vector2(0, 3); //Add offset to fix button height placement
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