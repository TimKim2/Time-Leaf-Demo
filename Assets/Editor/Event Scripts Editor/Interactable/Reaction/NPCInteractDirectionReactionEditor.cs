using System.Collections;
#if UNITY_EDITOR 
using UnityEditor;
#endif 

[CustomEditor(typeof(NPCInteractDirectionReaction))]
public class NPCInteractDirectionReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel()
    {
        return "NPC Interact Direction Reaction";
    }
}

