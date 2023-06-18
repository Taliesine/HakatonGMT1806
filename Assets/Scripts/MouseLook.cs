using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // „увствительность мыши
    public float mouseSensitivity = 100f;

    // ѕеременные дл€ хранени€ текущего положени€ камеры по оси X и Y
    private float xRotation = 0f;
    private float yRotation = 0f;

    // ‘лаг, указывающий, разрешено ли мышиное управление камерой
    private bool allowMouseControl = true;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // при нажатии клавиши ESC мышь перестает управл€ть камерой
            allowMouseControl = false;
        }
        else if (Input.GetMouseButtonDown(0) && !allowMouseControl)
        {
            // если была нажата лева€ кнопка мыши и мышь не управл€ет камерой, то мышь начинает ее управл€ть
            if (!IsMouseOverUI())
            {
                allowMouseControl = true;
            }
        }

        if (allowMouseControl)
        {
            // ѕолучаем текущее значение движени€ мыши
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            // ќбновл€ем значени€ поворота камеры по оси X и Y, использу€ движение мыши
            xRotation -= mouseY;
            yRotation += mouseX;

            // ќграничиваем наклон камеры по оси Z до 0
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        }
    }

    private bool IsMouseOverUI()
    {
        // ѕолучаем позицию клика мыши
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        // ѕолучаем список объектов под указателем мыши
        var hits = Physics2D.RaycastAll(mousePosition, Vector2.zero);

        // ѕровер€ем, находитс€ ли хот€ бы один из них внутри Panel
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
