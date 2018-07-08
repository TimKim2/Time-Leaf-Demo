#if UNITY_EDITOR 
using UnityEditor;
#endif 

[CustomEditor(typeof(ChangePlayerPositionReaction))]
public class ChangePlayerPositionReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel()
    {
        return "Change Player Position Reaction";
    }
}
