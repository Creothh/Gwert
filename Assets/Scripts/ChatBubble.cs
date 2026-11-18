using TMPro;
using UnityEngine;

public class ChatBubble : MonoBehaviour
{

    [SerializeField] TMP_Text nameTag;
    [SerializeField] TMP_Text messageText;

    public void SetupChatBubble(string speakerName, string speakerMessage, Color messageColor)
    {
        nameTag.text = speakerName;
        messageText.text = speakerMessage;
        messageText.color = messageColor; 

    }
       
}
