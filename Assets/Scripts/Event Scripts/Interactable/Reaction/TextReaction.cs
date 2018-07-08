using UnityEngine;

public class TextReaction : DelayedReaction
{
    public string dialogue;
    public string characterName;
    public Sprite characterImage;


    //private TextManager textManager;


    protected override void SpecificInit()
    {
       // textManager = FindObjectOfType<TextManager> ();
    }


    protected override void ImmediateReaction()
    {
        //textManager.DisplayMessage (message, textColor, delay);
        FSLocator.textDisplayer.Say(dialogue, characterName);
        FSLocator.characterDisplayer.DrawImage(characterImage, characterName);
    }
}