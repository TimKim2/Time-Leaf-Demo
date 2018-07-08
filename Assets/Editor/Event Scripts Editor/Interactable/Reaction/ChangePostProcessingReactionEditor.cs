#if UNITY_EDITOR 
using UnityEditor;
#endif 

[CustomEditor(typeof(ChangePostProcessingReaction))]
public class ChangePostProcessingReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel()
    {
        return "Change Post Processing Reaction";
    }
}
