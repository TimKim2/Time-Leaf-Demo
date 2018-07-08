#if UNITY_EDITOR 
using UnityEditor;
#endif 

[CustomEditor(typeof(ChangePositionReaction))]
public class ChangePositionReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel()
    {
        return "Change Position Reaction";
    }
}
