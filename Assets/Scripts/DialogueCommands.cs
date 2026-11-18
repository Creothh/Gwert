using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;

public class DialogueCommands : MonoBehaviour
{
    [SerializeField] DialogueRunner dialogueRunner;
    [SerializeField] AppWindow appWindow;

    void Awake()
    {
        dialogueRunner.AddCommandHandler("ferme_fenetre", appWindow.CloseWindow);
        dialogueRunner.AddCommandHandler("relance_logiciel", appWindow.OpenWindow);
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            dialogueRunner.RequestNextLine();
        }
    }
}
