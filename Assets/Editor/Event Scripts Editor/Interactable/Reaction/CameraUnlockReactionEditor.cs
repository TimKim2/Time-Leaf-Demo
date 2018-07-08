#if UNITY_EDITOR 
using UnityEditor;
#endif 

[CustomEditor(typeof(CameraUnlockReaction))]
public class CameraUnlockReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel()
    {
        return "Camera Unlock Reaction";
    }
}
