using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class PasswordManager : MonoBehaviour
{

    // éléments d'inteface

    [SerializeField] TMP_InputField passwordText;
    [SerializeField] TMP_Text descriptionText;
    [SerializeField] GameObject passwordTooltip;

    [SerializeField] GameObject passwordScreen;

    // variables 

    string correctPassword = "Hilda"; // defini comme case sensitive mais à voir
    int currentErrorAmount = 0;
    int maxErrorAmount = 3;


    void Update()
    {
        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            CheckPassword();
        }
    }

    // fonctions définies pour pouvoir les assigner aux boutons dans l'inspector 
    public void CheckPassword()
    {
        if (passwordText.text == correctPassword)
        {

            Debug.Log("Correct Password"); // juste pendant qu'on fait les tests évidemment
            descriptionText.text = "Bienvenue";
            descriptionText.color = Color.green;
            passwordTooltip.SetActive(false);
            passwordScreen.SetActive(false);
            currentErrorAmount = 0;
        }
        else
        {
            descriptionText.text = "Mot de passe incorrect, réssayez";
            descriptionText.color = Color.red;
            currentErrorAmount++;
            Debug.Log("Mot de passe incorrect, réssayez");

            // reset l'input field !! Potentiel improvement : garder l'input field selectionné après l'erreur
            passwordText.text = "";

            if (currentErrorAmount == maxErrorAmount)
            {
                passwordTooltip.SetActive(true);
            }
            
           
        }
    }

    // Potentiel improvement : hide la tooltip quand on clique hors de la zone OU sur l'input field
    public void TriggerTooltip()
    {

        if (passwordTooltip.activeSelf == true)
        {
            passwordTooltip.SetActive(false);
        }
        else
        {
            passwordTooltip.SetActive(true);
        }
    }

    // Missing : la transition entre le passwordScreen et le loadingScreen (if any)

}
