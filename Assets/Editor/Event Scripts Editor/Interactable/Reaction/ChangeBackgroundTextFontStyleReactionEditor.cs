#if UNITY_EDITOR 
using UnityEditor;
#endif 

[CustomEditor(typeof(ChangeBackgroundTextFontStyleReaction))]
public class ChangeBackgroundTextFontStyleReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel()
    {
        return "Change Background Text FontStyle Reaction";
    }
}
