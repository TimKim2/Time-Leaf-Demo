using UnityEngine;

public class MiniMapReaction : DelayedReaction
{
    public int mapNum;
    public string str;
    public bool science = false;
    public bool rootTop = false;

    protected override void ImmediateReaction()
    {
        FSLocator.minimapMgr.miniMapNum = mapNum;
        FSLocator.minimapMgr.miniMapStr = str;

        if (science)
            FSLocator.minimapMgr.isSience = true;
        else
            FSLocator.minimapMgr.isSience = false;

        if (rootTop)
            FSLocator.minimapMgr.isRoofTop = true;
        else
            FSLocator.minimapMgr.isRoofTop = false;
    }
}
