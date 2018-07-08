using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    public static QuestUI instance;
    public string[] mainquset;
    public string[] subquest;
    public Text mainquesttext;
    public Text subquesttext;

    private void Start()
    {
        instance = this;
        ChangeQuestContent(0, 0);
    }



    public void ChangeQuestContent (int main, int sub)
    {
        mainquesttext.text = mainquset[main];
        subquesttext.text = subquest[sub];
	}
}
