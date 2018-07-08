using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCutSceneFontStyleReaction : DelayedReaction
{
    public Font font;
    public int fontSize;

    protected override void ImmediateReaction()
    {
        FSLocator.cutSceneTextDisplayer.ChangeCutSceneTextFontStyle(font, fontSize);
    }
}
