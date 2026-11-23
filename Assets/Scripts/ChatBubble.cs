using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChatBubble : MonoBehaviour
{

    [SerializeField] TMP_Text nameTag;
    [SerializeField] TMP_Text messageText;

    [SerializeField] Image drawingImage;


    public void SetupChatBubble(string speakerName, string speakerMessage, Color messageColor)
    {
        nameTag.text = speakerName;
        messageText.text = speakerMessage;
        messageText.color = messageColor;

        messageText.gameObject.SetActive(true);   
        drawingImage.gameObject.SetActive(false);
    }

    public void SetupDrawing(string speakerName, Sprite drawing)
    {
        nameTag.text = speakerName;
        drawingImage.sprite = drawing;             

        drawingImage.gameObject.SetActive(true);   
        messageText.gameObject.SetActive(false);
    }

}
