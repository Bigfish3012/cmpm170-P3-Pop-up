using UnityEngine;
using UnityEngine.EventSystems;

public class RunAwayButton : MonoBehaviour, IPointerEnterHandler
{
    [Header("Where the button is allowed to move")]
    public RectTransform moveArea;

    [Header("Run-away behaviour")]
    public int maxRuns = 3;
    [Range(0f, 1f)]
    public float runChance = 0.7f;
    public float padding = 10f;

    private RectTransform rect;
    private int runsUsed = 0;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();

        if (moveArea == null)
            moveArea = rect.parent as RectTransform;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (runsUsed >= maxRuns)
            return;

        if (Random.value > runChance)
            return;

        runsUsed++;

        if (moveArea == null) return;

        float areaW = moveArea.rect.width;
        float areaH = moveArea.rect.height;
        float btnW = rect.rect.width;
        float btnH = rect.rect.height;

        float xMin = -areaW / 2f + btnW / 2f + padding;
        float xMax =  areaW / 2f - btnW / 2f - padding;
        float yMin = -areaH / 2f + btnH / 2f + padding;
        float yMax =  areaH / 2f - btnH / 2f - padding;

        float newX = Random.Range(xMin, xMax);
        float newY = Random.Range(yMin, yMax);

        rect.anchoredPosition = new Vector2(newX, newY);
    }
}
