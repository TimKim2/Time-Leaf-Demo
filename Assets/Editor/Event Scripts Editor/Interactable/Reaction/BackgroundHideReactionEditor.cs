#if UNITY_EDITOR 
using UnityEditor;
#endif 

[CustomEditor(typeof(BackgroundHideReaction))]
public class BackgroundHideReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel()
    {
        return "Background Hide Reaction";
    }
}