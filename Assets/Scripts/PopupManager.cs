using UnityEngine;
using System.Collections; 
using System.Collections.Generic;

public class PopupManager : MonoBehaviour
{
    [SerializeField] private GameObject[] popupPrefabs;
    [SerializeField] private Transform popupParent;

    [SerializeField] private float startInterval = 2f;
    [SerializeField] private float minInterval = 0.5f;
    [SerializeField] private float intervalStep = 0.3f;

    private void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        float currentInterval = startInterval;
        while (true)
        {
            yield return new WaitForSeconds(currentInterval);
            SpawnPopup();
            currentInterval = Mathf.Max(minInterval, currentInterval - intervalStep);
        }
    }

    private void SpawnPopup()
    {
        if (popupPrefabs == null || popupPrefabs.Length == 0)
        {
            Debug.LogWarning("PopupManager: popupPrefab is not assigned!");
            return;
        }
        GameObject chosenPrefab = popupPrefabs[Random.Range(0, popupPrefabs.Length)];

        Transform chosenParent;
        if (popupParent != null)
        {
            chosenParent = popupParent;
        }
        else
        {
            chosenParent = transform;
        }
        RectTransform parentRect = chosenParent as RectTransform;
        if (parentRect == null)
        {
            Debug.LogWarning("PopupManager: parent does not have a RectTransform!");
            return;
        }

        GameObject popupGO = Instantiate(chosenPrefab, parentRect);
        RectTransform popupRect = popupGO.GetComponent<RectTransform>();

        // Make sure it draws on top
        popupGO.transform.SetAsLastSibling();

        float parentWidth = parentRect.rect.width;
        float parentHeight = parentRect.rect.height;

        // Popup size
        float popupWidth = popupRect.rect.width;
        float popupHeight = popupRect.rect.height;

        // Keep full window inside the parent bounds
        float xMin = -parentWidth / 2f + popupWidth / 2f;
        float xMax =  parentWidth / 2f - popupWidth / 2f;
        float yMin = -parentHeight / 2f + popupHeight / 2f;
        float yMax =  parentHeight / 2f - popupHeight / 2f;

        float randomX = Random.Range(xMin, xMax);
        float randomY = Random.Range(yMin, yMax);

        popupRect.anchoredPosition = new Vector2(randomX, randomY);
    }

}
