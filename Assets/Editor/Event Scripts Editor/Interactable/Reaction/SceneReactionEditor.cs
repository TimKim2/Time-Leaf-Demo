#if UNITY_EDITOR 
using UnityEditor;
#endif 

[CustomEditor (typeof (SceneReaction))]
public class SceneReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel ()
    {
        return "Scene Reaction";
    }
}
