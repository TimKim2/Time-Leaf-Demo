using System.Collections;
#if UNITY_EDITOR 
using UnityEditor;
#endif 

[CustomEditor(typeof(MiniMapReaction))]
public class MiniMapReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel()
    {
        return "MiniMap Reaction";
    }
}

