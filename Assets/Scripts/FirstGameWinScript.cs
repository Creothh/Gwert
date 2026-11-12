using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstGameWinScript : MonoBehaviour
{
    public List<Image> winImages = new List<Image>();

    public void WinCondition()
    {
        for(int i = 0; i < winImages.Count; i++)
        {
            if (winImages[i].transform.GetSiblingIndex() != 0)
            {
                return;
            }
        }

        Debug.Log("win");
    }

}
