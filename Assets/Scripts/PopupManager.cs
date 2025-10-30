using UnityEngine;

public class PopupManager : MonoBehaviour
{
    [SerializeField] private GameObject popupPrefab;
    [SerializeField] private Transform popupParent;

    [SerializeField] private float spawnInterval = 1f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnPopup), spawnInterval, spawnInterval);
    }

    private void SpawnPopup()
    {
        // 1. Safety check
        if (popupPrefab == null)
        {
            Debug.LogWarning("PopupManager: popupPrefab is not assigned!");
            return;
        }

        // 2. Decide which UI parent to use
        //    (prefer the one you dragged in Inspector, otherwise use this object)
        Transform chosenParent = popupParent != null ? popupParent : transform;

        // We need a RectTransform because we're doing UI positioning
        RectTransform parentRect = chosenParent as RectTransform;
        if (parentRect == null)
        {
            Debug.LogWarning("PopupManager: parent does not have a RectTransform!");
            return;
        }

        // 3. Create the popup as a child of the parent
        GameObject popupGO = Instantiate(popupPrefab, parentRect);
        RectTransform popupRect = popupGO.GetComponent<RectTransform>();

        // 4. Get the size of the parent (the area we can spawn in)
        float parentWidth = parentRect.rect.width;
        float parentHeight = parentRect.rect.height;

        // 5. Pick a random position inside that area
        float randomX = Random.Range(-parentWidth / 2f, parentWidth / 2f);
        float randomY = Random.Range(-parentHeight / 2f, parentHeight / 2f);
        Vector2 randomPosition = new Vector2(randomX, randomY);

        // 6. Move the popup there
        popupRect.anchoredPosition = randomPosition;
    }


}
