using UnityEngine;

public class LiftObject : MonoBehaviour
{
    [SerializeField] private float liftHeight = 1f; // ������ ������� �������

    public void OnButtonClick()
    {
        // �������� ������� ������� �������
        Vector3 pos = transform.position;

        // ��������� ������ �� �������� ������
        pos.y += liftHeight;

        // ������������� ����� ������� �������
        transform.position = pos;
    }
}
