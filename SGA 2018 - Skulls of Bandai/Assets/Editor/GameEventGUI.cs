using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Text.RegularExpressions;

public class GameEventGUI:EditorWindow {

    bool showPosition = true;

    public int intValue = 0;
    public int intValue1 = 0;
    public int intValue2 = 0;
    public float floatValue = 0;
    public float floatValue1 =0;
    public float floatValue2 = 0;
    public bool boolValue = false;
    public bool boolValue1 = false;
    public bool boolValue2 = false;
    public string stringValue = "";
    public string stringValue1 = "";
    public string stringValue2 = "";

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
            GUILayout.EndHorizontal();
            GUILayout.Space(15);
            GUILayout.Label("Float", EditorStyles.boldLabel);
            GUILayout.BeginHorizontal();
            EditorGUIUtility.labelWidth = 40;
            floatValue = EditorGUILayout.FloatField("float 0", floatValue, GUILayout.ExpandWidth(false));
            floatValue1 = EditorGUILayout.FloatField("float 1", floatValue1, GUILayout.ExpandWidth(false));
            floatValue2 = EditorGUILayout.FloatField("float 2", floatValue2, GUILayout.ExpandWidth(false));
            GUILayout.EndHorizontal();
            GUILayout.Space(15);
            GUILayout.Label("Bool", EditorStyles.boldLabel);
            GUILayout.BeginHorizontal();
            EditorGUIUtility.labelWidth = 40;
            boolValue = EditorGUILayout.Toggle("bool 0", boolValue);
            boolValue1 = EditorGUILayout.Toggle("bool 1", boolValue1);
            boolValue2 = EditorGUILayout.Toggle("bool 2", boolValue2);
            GUILayout.EndHorizontal();
            GUILayout.Space(15);
            GUILayout.Label("String", EditorStyles.boldLabel);
            EditorGUIUtility.labelWidth = 40;
            stringValue = EditorGUILayout.TextField("string 0", stringValue);
            stringValue1 = EditorGUILayout.TextField("string 1", stringValue1);
            stringValue2 = EditorGUILayout.TextField("string 2", stringValue2);
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
                GameEventMessage message = new GameEventMessage(null);
                gameEvent.Fire(new GameEventMessage(null));
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