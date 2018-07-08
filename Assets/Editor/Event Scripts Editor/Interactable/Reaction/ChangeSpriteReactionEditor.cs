#if UNITY_EDITOR 
using UnityEditor;
#endif 

[CustomEditor(typeof(ChangeSpriteReaction))]
public class ChangeSpriteReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel()
    {
        return "Change Sprite Reaction";
    }
}
