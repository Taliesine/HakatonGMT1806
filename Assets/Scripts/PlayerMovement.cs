using UnityEngine;

public class FlyingController : MonoBehaviour
{
    public float speed = 10.0f; // �������� ������������ �� ���� X � Z
    public float height = 2.0f; // ������ ������ ��� ������� ������� ������
    public float liftSpeed = 10.0f; // �������� �������

    private CharacterController controller;
    private Vector3 motion;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // ������������ �� ��� X � Z
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0.0f, vertical);
        moveDirection = Camera.main.transform.TransformDirection(moveDirection);
        moveDirection.y = 0.0f;
        moveDirection.Normalize();
        moveDirection *= speed;

        // �������� ������ ��������� ��� ������� ������� ������
        if (Input.GetKey(KeyCode.Space))
        {
            motion.y += liftSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            motion.y -= liftSpeed * Time.deltaTime;
        }
        else
        {
            motion.y = 0.0f;
        }

        // ��������� �������� �� ���� ����
        moveDirection += motion;

        // ������������ ���������
        controller.Move(moveDirection * Time.deltaTime);
    }
}
