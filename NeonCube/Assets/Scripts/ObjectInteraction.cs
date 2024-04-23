using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public Vector3 targetSize; // Целевые размеры объекта
    public Transform[] targetPositions; // Массив целевых позиций объекта
    private int currentPositionIndex = 0; // Индекс текущей позиции в массиве

    void Update()
    {
        // Проверяем нажатие на объект
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                // Проверяем, что объект был нажат
                if (hit.collider.gameObject == gameObject)
                {
                    ChangeSize();
                    MoveToNextPosition();
                }
            }
        }
    }

    void ChangeSize()
    {
        // Изменяем размер объекта
        transform.localScale = targetSize;
    }

    void MoveToNextPosition()
    {
        // Перемещаем объект в следующую позицию, если таковая имеется
        if (currentPositionIndex < targetPositions.Length)
        {
            // Проверяем, занята ли следующая позиция
            Collider[] colliders = Physics.OverlapSphere(targetPositions[currentPositionIndex].position, 0.1f);
            if (colliders.Length == 0)
            {
                transform.position = targetPositions[currentPositionIndex].position;
                currentPositionIndex++;
            }
            else
            {
                Debug.Log("Следующая позиция занята!");
            }
        }
        else
        {
            Debug.Log("Все позиции заняты!");
        }
    }
}
