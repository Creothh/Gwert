using UnityEngine;

public class AppWindow : MonoBehaviour
{

    public GameObject windowPrefab;
    public void OpenWindow()
    {
        windowPrefab.SetActive(true);
        transform.SetAsLastSibling(); // pour qu'elle soit bien en premier plan
    }

    public void CloseWindow()
    {
        windowPrefab.SetActive(false);
    }

}
