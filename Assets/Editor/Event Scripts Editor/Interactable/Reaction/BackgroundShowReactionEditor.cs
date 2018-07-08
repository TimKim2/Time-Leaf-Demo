#if UNITY_EDITOR 
using UnityEditor;
#endif 

[CustomEditor(typeof(BackgroundShowReaction))]
public class BackgroundShowReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel()
    {
        return "Background Show Reaction";
    }
}
