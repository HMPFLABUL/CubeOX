using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonsMenager : MonoBehaviour {

    private Button button;
    private Text buttonText;
    void OnEnable()
    {
        button = this.gameObject.GetComponent<Button>();
        buttonText = button.GetComponentInChildren<Text>();
        buttonText.text = " ";
        button.onClick.AddListener(() => { OnClick(); });
    }
    void FixedUpdate()
    {
        if (GameData.buttonsLock)
            button.interactable = false;
        else
            button.interactable = true;

        if (GameData.clearBoard)
        {
            buttonText.text = " ";
            buttonText.color = Color.black;
            
        }

    }

	public void OnClick()
    {
        if (GameData.actPlayer==0)
        {
            if(buttonText.text == " ")
            {
                buttonText.text = GameData.playerOneSign;
               // GameData.actPlayer = 1;
                Marked();                            
            }              
         }
        else if(GameData.actPlayer == 1)
        {
            if (buttonText.text == " ")
            {
                buttonText.text = GameData.playerTwoSign;

               // if (GameData.trio)
               // //    GameData.actPlayer = 2;
               // else
                //    GameData.actPlayer = 0;
                Marked();
            }
        }
        else
        {
            if (buttonText.text ==" ")
            {
                buttonText.text = GameData.playerThreeSign;
               // GameData.actPlayer = 0;
                Marked();
            }
        }
       

    }
    private void Marked()
    {
        GameData.buttonsLock = true;
        GameData.arrowsLock = false;      
    }
}
