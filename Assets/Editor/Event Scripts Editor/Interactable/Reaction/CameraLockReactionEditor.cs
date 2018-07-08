#if UNITY_EDITOR 
using UnityEditor;
#endif 

[CustomEditor(typeof(CameraLockReaction))]
public class CameraLockReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel()
    {
        return "Camera Lock Reaction";
    }
}
