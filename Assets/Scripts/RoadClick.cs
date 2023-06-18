using UnityEngine;

public class ObjectClick : MonoBehaviour
{
    public GameObject panel;

    private void OnMouseDown()
    {
        if (panel != null)
        {
            panel.SetActive(true);
        }
    }
}
