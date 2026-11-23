using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;

public class DialogueCommands : MonoBehaviour
{
    [SerializeField] DialogueRunner dialogueRunner;
    [SerializeField] AppWindow appWindow;
    [SerializeField] ChatPresenter chatPresenter;
    [SerializeField] Sprite[] drawings; 

    void Awake()
    {
        dialogueRunner.AddCommandHandler("ferme_fenetre", appWindow.CloseWindow);
        dialogueRunner.AddCommandHandler("relance_logiciel", appWindow.OpenWindow);
        dialogueRunner.AddCommandHandler<string>("affiche_dessin", ShowDrawing);
    }

    void ShowDrawing(string drawingName)
    {
        foreach (Sprite drawing in drawings)
        {

            if (drawing.name == drawingName)
            {
                chatPresenter.AddDrawing(drawing);
                return;
            }
        }

        // si on arrive ici, aucun dessin n'a ce nom
        Debug.LogWarning("Dessin introuvable : " + drawingName);
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            dialogueRunner.RequestNextLine();
        }
    }
}
