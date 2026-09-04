using UnityEngine;
using UnityEngine.UI;

public class BuffSelectUI : MonoBehaviour
{
    public GameObject panel;

    public void OpenBuffSelect()
    {
        panel.SetActive(true);

        Time.timeScale = 0f;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseBuffSelect()
    {
        panel.SetActive(false);

        Time.timeScale = 1f;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}