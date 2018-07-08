#if UNITY_EDITOR 
using UnityEditor;
#endif 

[CustomEditor(typeof(GameObjectReaction))]
public class GameObjectReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel ()
    {
        return "GameObject Reaction";
    }
}
