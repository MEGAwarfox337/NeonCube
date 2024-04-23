using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public Vector3 targetSize; // ������� ������� �������
    public Transform[] targetPositions; // ������ ������� ������� �������
    private int currentPositionIndex = 0; // ������ ������� ������� � �������

    void Update()
    {
        // ��������� ������� �� ������
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                // ���������, ��� ������ ��� �����
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
        // �������� ������ �������
        transform.localScale = targetSize;
    }

    void MoveToNextPosition()
    {
        // ���������� ������ � ��������� �������, ���� ������� �������
        if (currentPositionIndex < targetPositions.Length)
        {
            // ���������, ������ �� ��������� �������
            Collider[] colliders = Physics.OverlapSphere(targetPositions[currentPositionIndex].position, 0.1f);
            if (colliders.Length == 0)
            {
                transform.position = targetPositions[currentPositionIndex].position;
                currentPositionIndex++;
            }
            else
            {
                Debug.Log("��������� ������� ������!");
            }
        }
        else
        {
            Debug.Log("��� ������� ������!");
        }
    }
}
