using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // ���������������� ����
    public float mouseSensitivity = 100f;

    // ���������� ��� �������� �������� ��������� ������ �� ��� X � Y
    private float xRotation = 0f;
    private float yRotation = 0f;

    // ����, �����������, ��������� �� ������� ���������� �������
    private bool allowMouseControl = true;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // ��� ������� ������� ESC ���� ��������� ��������� �������
            allowMouseControl = false;
        }
        else if (Input.GetMouseButtonDown(0) && !allowMouseControl)
        {
            // ���� ���� ������ ����� ������ ���� � ���� �� ��������� �������, �� ���� �������� �� ���������
            if (!IsMouseOverUI())
            {
                allowMouseControl = true;
            }
        }

        if (allowMouseControl)
        {
            // �������� ������� �������� �������� ����
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            // ��������� �������� �������� ������ �� ��� X � Y, ��������� �������� ����
            xRotation -= mouseY;
            yRotation += mouseX;

            // ������������ ������ ������ �� ��� Z �� 0
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        }
    }

    private bool IsMouseOverUI()
    {
        // �������� ������� ����� ����
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        // �������� ������ �������� ��� ���������� ����
        var hits = Physics2D.RaycastAll(mousePosition, Vector2.zero);

        // ���������, ��������� �� ���� �� ���� �� ��� ������ Panel
        foreach (var hit in hits)
        {
            if (hit.collider.CompareTag("Panel"))
            {
                return true;
            }
        }

        return false;
    }
}
