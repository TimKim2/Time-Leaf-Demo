#if UNITY_EDITOR 
using UnityEditor;
#endif 

[CustomEditor(typeof(BehaviourReaction))]
public class BehaviourReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel ()
    {
        return "Behaviour Reaction";
    }
}
