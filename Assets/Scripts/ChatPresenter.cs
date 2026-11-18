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

    public override YarnTask OnDialogueStartedAsync()
    {
        return YarnTask.CompletedTask;
    }

    public override YarnTask OnDialogueCompleteAsync()
    {
        return YarnTask.CompletedTask;
    }

    public override async YarnTask RunLineAsync(LocalizedLine line, LineCancellationToken token)
    {
        // check who is talking
        if (line.Metadata.Contains("pensee")) return;
        if (line.CharacterName == "Narrateur") return;

        // create a new chat bubble 
        ChatBubble bubble = Instantiate(bubblePrefab, chatContent);
        string message = line.TextWithoutCharacterName.Text;

        // check what color and content to display based on who is talking
        if (line.CharacterName == "Enfant")
        {
            bubble.SetupChatBubble(accountName, message, enfantColor);
        }
        else
        {
            bubble.SetupChatBubble(accountName, message, hildaColor);
        }

        // 
        Canvas.ForceUpdateCanvases(); // to recalculate as soon as the bubble is created instead of right after          
        chatScroll.verticalNormalizedPosition = 0f; // to go allllll the way down 

        // wait for a click 
        await YarnTask.WaitUntilCanceled(token.NextContentToken).SuppressCancellationThrow();
    }

}