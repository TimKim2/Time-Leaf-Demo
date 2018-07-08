#if UNITY_EDITOR 
using UnityEditor;
#endif 

[CustomEditor(typeof(CameraFollowReaction))]
public class CameraFollowReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel()
    {
        return "Camera Follow Reaction";
    }
}