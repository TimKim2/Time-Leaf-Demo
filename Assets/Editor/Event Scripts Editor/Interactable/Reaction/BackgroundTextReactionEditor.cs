using System.Collections;
#if UNITY_EDITOR 
using UnityEditor;
#endif 

[CustomEditor(typeof(BackgroundTextReaction))]
public class BackgroundTextReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel()
    {
        return "Background Text Reaction";
    }
}
