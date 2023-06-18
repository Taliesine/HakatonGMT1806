using UnityEngine;

public class LiftObject : MonoBehaviour
{
    [SerializeField] private float liftHeight = 1f; // Высота подъема объекта

    public void OnButtonClick()
    {
        // Получаем текущую позицию объекта
        Vector3 pos = transform.position;

        // Поднимаем объект на заданную высоту
        pos.y += liftHeight;

        // Устанавливаем новую позицию объекта
        transform.position = pos;
    }
}
