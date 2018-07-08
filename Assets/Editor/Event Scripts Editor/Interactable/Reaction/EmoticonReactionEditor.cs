#if UNITY_EDITOR 
using UnityEditor;
#endif 

[CustomEditor(typeof(EmoticonReaction))]
public class EmoticonReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel()
    {
        return "Emoticon Reaction";
    }
}
