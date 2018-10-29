using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Text.RegularExpressions;

public class GameEventGUI:EditorWindow {

    bool showPosition = true;

    public int intValue = 0;
    public int intValue1 = 0;
    public int intValue2 = 0;

    [MenuItem("Window/GameEventGUI")]
    public static void ShowWindow() {
        EditorWindow.GetWindow(typeof(GameEventGUI));
    }

    void OnGUI() {
        GUILayout.BeginVertical("Box");
        EditorStyles.label.fontStyle = FontStyle.Bold;
        showPosition = EditorGUILayout.Foldout(showPosition, "Parameters");
        EditorStyles.label.fontStyle = FontStyle.Normal;
        if(showPosition) {
            GUILayout.Label("Int", EditorStyles.boldLabel);
            GUILayout.BeginHorizontal();
            EditorGUIUtility.labelWidth = 30;
            intValue = EditorGUILayout.IntField("int 0", intValue, GUILayout.ExpandWidth(false));
            intValue1 = EditorGUILayout.IntField("int 1", intValue1, GUILayout.ExpandWidth(false));
            intValue2 = EditorGUILayout.IntField("int 2", intValue2, GUILayout.ExpandWidth(false));
            GUILayout.Space(15);
            if(GUILayout.Button("Reset values")) {
                Reset();
            }
        }
        GUILayout.EndVertical();

        GUILayout.BeginVertical("Box");

        GameEvent[] gameEvents = GetAllInstances<GameEvent>();

        foreach(GameEvent gameEvent in gameEvents) {
            string name = gameEvent.name;
            name = name.Replace("Event", "");

            string pattern = "([a-z?])[_ ]?([A-Z])";

            name = Regex.Replace(name, pattern, "$1 $2");

            if(GUILayout.Button(name)) {
                EventMessage message = new EventMessage(null);
                gameEvent.Fire(new EventMessage(null));
            }
        }

        GUILayout.EndVertical();
    }

    void Reset() {

    }
    
    public static T[] GetAllInstances<T>() where T : ScriptableObject {
        //FindAssets uses tags check documentation for more info
        string[] guids = AssetDatabase.FindAssets("t:"+ typeof(T).Name);

        T[] a = new T[guids.Length];
        for(int i = 0;i < guids.Length; i++) {
            string path = AssetDatabase.GUIDToAssetPath(guids[i]);
            a[i] = AssetDatabase.LoadAssetAtPath<T>(path);
        }

        return a;
    }
}