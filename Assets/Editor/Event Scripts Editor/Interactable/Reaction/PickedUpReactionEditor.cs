#if UNITY_EDITOR 
using UnityEditor;
#endif 

[CustomEditor(typeof(PickedUpItemReaction))]
public class PickedUpItemReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel()
    {
        return "Picked Up Item Reaction";
    }
}
