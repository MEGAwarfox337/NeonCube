using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DeactivateObjects : MonoBehaviour
{
    public List<GameObject> objectsToDeactivate;
    public GameObject gameOverText;

    private int currentIndex = 0;

    void Start()
    {
        gameOverText.gameObject.SetActive(false);
    }

    public void DeactivateNextObject()
    {
        if (currentIndex < objectsToDeactivate.Count)
        {
            objectsToDeactivate[currentIndex].SetActive(false);
            currentIndex++;

            if (currentIndex == objectsToDeactivate.Count)
            {
                ShowGameOverText();
            }
        }
    }

    void ShowGameOverText()
    {
        gameOverText.gameObject.SetActive(true);
    }
}
