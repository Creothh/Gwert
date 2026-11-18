using System.Linq;
using TMPro;
using UnityEngine;
using Yarn.Unity;

public class ThoughtsPresenter : DialoguePresenterBase
{

    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] TMP_Text thinkerName;
    [SerializeField] TMP_Text thoughtText;


    public override YarnTask OnDialogueCompleteAsync()
    {
        canvasGroup.alpha = 0;
        return YarnTask.CompletedTask;
    }

    public override YarnTask OnDialogueStartedAsync()
    {
        canvasGroup.alpha = 0;
        return YarnTask.CompletedTask;
    }

    public override async YarnTask RunLineAsync(LocalizedLine line, LineCancellationToken token)
    {
        if (!line.Metadata.Contains("pensee")) return;

        thinkerName.text = line.CharacterName; // who is thinking 
        thoughtText.text = line.TextWithoutCharacterName.Text; 

        canvasGroup.alpha = 1;
        await YarnTask.WaitUntilCanceled(token.NextContentToken).SuppressCancellationThrow();
        canvasGroup.alpha = 0; // so they don't stack lol
    }

}
