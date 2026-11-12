using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public FirstGameWinScript firstGameWinScript;
    public void UpButton()
    {
        transform.GetChild(0).SetAsLastSibling();
        firstGameWinScript.WinCondition();
    }

    public void DownButton()
    {
        transform.GetChild(transform.childCount - 1).SetAsFirstSibling();
        firstGameWinScript.WinCondition();
    }

}
