#if UNITY_EDITOR 
using UnityEditor;
#endif 

[CustomEditor(typeof(GameObjectDestroyReaction))]
public class GameObjectDestroyReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel()
    {
        return "GameObject Destroy Reaction";
    }
}