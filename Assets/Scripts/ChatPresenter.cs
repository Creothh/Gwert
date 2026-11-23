using UnityEngine;
using Yarn.Unity;
using System.Linq;
using UnityEngine.UI;

public class ChatPresenter : DialoguePresenterBase
{
    [SerializeField] Transform chatContent;
    [SerializeField] ChatBubble bubblePrefab;
    [SerializeField] string accountName = "Marc Solis";
    [SerializeField] Color hildaColor = Color.black;
    [SerializeField] Color enfantColor = Color.blue;
    [SerializeField] ScrollRect chatScroll;

    bool justChose = false;

    [SerializeField] int answerDelay; 

    public override YarnTask OnDialogueStartedAsync()
    {
        return YarnTask.CompletedTask;
    }

    public override YarnTask OnDialogueCompleteAsync()
    {
        return YarnTask.CompletedTask;
    }


    public override YarnTask<DialogueOption> RunOptionsAsync(DialogueOption[] dialogueOptions, LineCancellationToken cancellationToken)
    {
        justChose = true;
        Debug.Log("CHOIX détecté !");
        return base.RunOptionsAsync(dialogueOptions, cancellationToken);
    }

    public override async YarnTask RunLineAsync(LocalizedLine line, LineCancellationToken token)
    {
        // check who is talking
        Debug.Log(line.CharacterName + " parle, justChose = " + justChose);
        if (line.Metadata.Contains("pensee")) return;
        if (line.CharacterName == "Narrateur") return;

        // create a new chat bubble 
        string message = line.TextWithoutCharacterName.Text;

        // wait, except right after a choice
        if (justChose == false) await YarnTask.Delay(answerDelay);
        justChose = false;

        // choose the color
        Color color = hildaColor;
        if (line.CharacterName == "Enfant") color = enfantColor;

        // create ONE bubble with that color
        ChatBubble bubble = Instantiate(bubblePrefab, chatContent);
        bubble.SetupChatBubble(accountName, message, color);

        // 
        Canvas.ForceUpdateCanvases(); // to recalculate as soon as the bubble is created instead of right after          
        chatScroll.verticalNormalizedPosition = 0f; // to go allllll the way down 


    }

    public void AddDrawing(Sprite drawing)
    {
        ChatBubble bubble = Instantiate(bubblePrefab, chatContent);
        bubble.SetupDrawing(accountName, drawing);

       
        Canvas.ForceUpdateCanvases();
        chatScroll.verticalNormalizedPosition = 0f;
    }

}
