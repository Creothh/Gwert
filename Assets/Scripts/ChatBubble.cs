using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChatBubble : MonoBehaviour
{

    [SerializeField] TMP_Text nameTag;
    [SerializeField] TMP_Text messageText;

    [SerializeField] Sprite drawingImage; 

    public void SetupChatBubble(string speakerName, string speakerMessage, Color messageColor)
    {
        nameTag.text = speakerName;
        messageText.text = speakerMessage;
        messageText.color = messageColor;

    }

}
