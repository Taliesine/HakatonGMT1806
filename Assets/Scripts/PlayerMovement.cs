using UnityEngine;

public class FlyingController : MonoBehaviour
{
    public float speed = 10.0f; // скорость передвижени€ по ос€м X и Z
    public float height = 2.0f; // высота полета при нажатии клавиши ѕробел
    public float liftSpeed = 10.0f; // скорость подъема

    private CharacterController controller;
    private Vector3 motion;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // передвижение по оси X и Z
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0.0f, vertical);
        moveDirection = Camera.main.transform.TransformDirection(moveDirection);
        moveDirection.y = 0.0f;
        moveDirection.Normalize();
        moveDirection *= speed;

        // измен€ем высоту персонажа при нажатии клавиши ѕробел
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

        // суммируем движение по всем ос€м
        moveDirection += motion;

        // передвижение персонажа
        controller.Move(moveDirection * Time.deltaTime);
    }
}
