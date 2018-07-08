using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pushed_Bag : MonoBehaviour {
    public enum ButtonState
    {
        BagButtonON = 0 ,
        ClueButtonON = 1 
    }

    public static ButtonState buttonState = ButtonState.BagButtonON ;
    public GameObject bagPanel;
    public GameObject cluePanel;
    public Button bagButton;
    public Button clueButton;


    ColorBlock color_bag;
    ColorBlock color_clue;

    Color color_gray = new Color((float)180/255, (float)180 /255, (float)180 /255);
    Color color_white = new Color(1,1,1);

    private void Start()
    {
        cluePanel.SetActive(false);
        bagPanel.SetActive(true);

        color_bag = bagButton.colors;
        color_clue = clueButton.colors;

        color_bag.normalColor = color_gray;
        color_clue.normalColor = color_white;
        bagButton.colors = color_bag;
        clueButton.colors = color_clue;

      //  Inventory.instance.AddItem(1);
    }


    public void Pushed()
    {
        if (gameObject.name == "Bag")
        {
            if (buttonState == ButtonState.BagButtonON)
            {
            //    Debug.Log("ButtonState = " + buttonState );
            } // bag 이 켜져있는데 눌렸 bag이 눌렸다면 아무일도 일어나지 않는다. 
            else
            {
           //     Debug.Log("pushed!  2 ");
                color_bag.normalColor = color_gray;
                color_clue.normalColor = color_white;
                bagButton.colors = color_bag;
                clueButton.colors = color_clue;

                bagPanel.SetActive(true);
                cluePanel.SetActive(false);                

                buttonState = ButtonState.BagButtonON; 
            }
        }
        else
        {
            if (buttonState == ButtonState.BagButtonON)   
            {
                color_bag.normalColor = color_white;
                color_clue.normalColor = color_gray;
                bagButton.colors = color_bag;
                clueButton.colors = color_clue;

                bagPanel.SetActive(false);
                cluePanel.SetActive(true);
                
                buttonState = ButtonState.ClueButtonON; 
            } 
        }
    }
}
