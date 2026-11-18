using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;

public class PictoChatWindow : MonoBehaviour
{
    [SerializeField] DialogueRunner dialogueRunner;
    [SerializeField] string startNode = "Act1";
    [SerializeField] Button closeButton;
    bool hasStarted = false;

    // whenever we open the picto window
    void OnEnable()
    {
        // in case we decide that we want to be able to close the window mid dialogue mdr
        if (hasStarted == true)
        {
            return; // ferme la boca de la fonction
        }

        hasStarted = true;
        dialogueRunner.StartDialogue(startNode);
        closeButton.interactable = false; // pour pas sortir de la fenêtre avant la fin du dialogue 
    }

    public void AllowClosingWindow()
    {
        closeButton.interactable = true; 
    }
}