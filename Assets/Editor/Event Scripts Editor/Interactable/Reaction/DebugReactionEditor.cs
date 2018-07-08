#if UNITY_EDITOR 
using UnityEditor;
#endif 

[CustomEditor(typeof(DebugReaction))]
public class DebugReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel()
    {
        return "Debug Log Reaction";
    }
}
