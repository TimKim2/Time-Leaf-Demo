#if UNITY_EDITOR 
using UnityEditor;
#endif 

[CustomEditor(typeof(SkipReaction))]
public class SkipReactionEditior : ReactionEditor
{
	protected override string GetFoldoutLabel()
	{
		return "Skip Reaction";
	}
}