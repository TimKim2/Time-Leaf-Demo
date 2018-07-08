using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackgroundTextFontStyleReaction : DelayedReaction
{
    public Font font;
    public int fontSize;

    protected override void ImmediateReaction()
    {
        FSLocator.backgroundDisplayer.ChangeBackgroundTextFontStyle(font, fontSize);
    }
}
