#if UNITY_EDITOR 
using UnityEditor;
#endif 

[CustomEditor(typeof(LostItemReaction))]
public class LostItemReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel ()
    {
        return "Lost Item Reaction";
    }
}
