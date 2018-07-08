#if UNITY_EDITOR 
using UnityEditor;
#endif 
using UnityEngine;

[CustomEditor(typeof(ChoiceReaction))]
public class ChoiceReactionEditor : ReactionEditor
{
    private SerializedProperty firstDialogueProperty;
    private SerializedProperty firstReactionCollectorProperty;
    private SerializedProperty firstChpaterProperty;
    private SerializedProperty secondDialogueProperty;
    private SerializedProperty secondReactionCollectorProperty;
    private SerializedProperty secondChpaterProperty;
    private SerializedProperty delayProperty;


    private const float messageGUILines = 3f;
    private const float areaWidthOffset = 19f;
    private const string firstDialogueName = "firstDialogue";
    private const string firstReactionCollectorName = "firstReactionCollection";
    private const string secondDialogueName = "secondDialogue";
    private const string secondReactionCollectorName = "secondReactionCollection";

    private const string textReactionPropDelayName = "delay";


    protected override void Init()
    {
        firstDialogueProperty = serializedObject.FindProperty(firstDialogueName);
        firstReactionCollectorProperty = serializedObject.FindProperty(firstReactionCollectorName);

        secondDialogueProperty = serializedObject.FindProperty(secondDialogueName);
        secondReactionCollectorProperty = serializedObject.FindProperty(secondReactionCollectorName);

        delayProperty = serializedObject.FindProperty(textReactionPropDelayName);
    }


    protected override void DrawReaction()
    {
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("First Dialogue", GUILayout.Width(EditorGUIUtility.labelWidth - areaWidthOffset));
        firstDialogueProperty.stringValue = EditorGUILayout.TextArea(firstDialogueProperty.stringValue, GUILayout.Height(EditorGUIUtility.singleLineHeight * messageGUILines));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.PropertyField(firstReactionCollectorProperty);

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Second Dialogue", GUILayout.Width(EditorGUIUtility.labelWidth - areaWidthOffset));
        secondDialogueProperty.stringValue = EditorGUILayout.TextArea(secondDialogueProperty.stringValue, GUILayout.Height(EditorGUIUtility.singleLineHeight * messageGUILines));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.PropertyField(secondReactionCollectorProperty);

        EditorGUILayout.PropertyField(delayProperty);
    }


    protected override string GetFoldoutLabel()
    {
        return "Choice Reaction";
    }
}
