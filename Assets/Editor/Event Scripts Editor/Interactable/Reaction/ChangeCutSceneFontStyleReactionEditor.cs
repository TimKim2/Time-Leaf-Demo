#if UNITY_EDITOR 
using UnityEditor;
#endif 

[CustomEditor(typeof(ChangeCutSceneFontStyleReaction))]
public class ChangeCutSceneFontStyleReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel()
    {
        return "Change CutScene Text FontStyle Reaction";
    }
}
