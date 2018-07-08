#if UNITY_EDITOR 
using UnityEditor;
#endif 
using UnityEngine;
[CustomEditor(typeof(EventCallbackConditionReaction))]
public class EventCallbackConditionReactionEditor : ReactionEditor
{
    protected ConditionCollectionEditor[] subEditors;
    public EventCallbackConditionReaction interactableCallback;
    private SerializedProperty collectionsProperty;
    private SerializedProperty defaultReactionCollectionProperty;

    private const float collectionButtonWidth = 125f;
    private const string interactablePropConditionCollectionsName = "conditionCollections";
    private const string interactablePropDefaultReactionCollectionName = "defaultReactionCollection";

    void CheckAndCreateSubEditors(ConditionCollection[] subEditorTargets)
    {
        if (subEditors != null && subEditors.Length == subEditorTargets.Length)
            return;

        CleanupEditors();

        subEditors = new ConditionCollectionEditor[subEditorTargets.Length];

        for (int i = 0; i < subEditors.Length; i++)
        {
            subEditors[i] = CreateEditor(subEditorTargets[i]) as ConditionCollectionEditor;
            SubEditorSetup(subEditors[i]);
        }
    }


    void CleanupEditors()
    {
        if (subEditors == null)
            return;

        for (int i = 0; i < subEditors.Length; i++)
        {
            DestroyImmediate(subEditors[i]);
        }

        subEditors = null;
    }


    void SubEditorSetup(ConditionCollectionEditor editor)
    {
        editor.collectionsProperty = collectionsProperty;
    }


    protected override void Init()
    {
        interactableCallback = (EventCallbackConditionReaction)target;
        collectionsProperty = serializedObject.FindProperty(interactablePropConditionCollectionsName);
        defaultReactionCollectionProperty = serializedObject.FindProperty(interactablePropDefaultReactionCollectionName);

        CheckAndCreateSubEditors(interactableCallback.conditionCollections);
    }

    private void OnDisable()
    {
        CleanupEditors();
    }


    protected override void DrawReaction()
    {
        serializedObject.Update();

        CheckAndCreateSubEditors(interactableCallback.conditionCollections);

        for (int i = 0; i < subEditors.Length; i++)
        {
            subEditors[i].OnInspectorGUI();
            EditorGUILayout.Space();
        }

        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Add Collection", GUILayout.Width(collectionButtonWidth)))
        {
            ConditionCollection newCollection = ConditionCollectionEditor.CreateConditionCollection();
            collectionsProperty.AddToObjectArray(newCollection);
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();

        EditorGUILayout.PropertyField(defaultReactionCollectionProperty);


        serializedObject.ApplyModifiedProperties();
    }

    protected override string GetFoldoutLabel()
    {
        return "Event Callback Condition Reaction";
    }
}
