using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(KSCoin))]
public sealed class KSCoinEditor : Editor
{
	public override void OnInspectorGUI ()
	{
		var coin = target as KSCoin;
		
		string fuckingString = EditorGUILayout.TextField("CharacterBuffer", coin._characterBuffer);
		string fuckingChara  = EditorGUILayout.TextField("CurrentCharactor", coin._currentCharacter);
		GUILayout.BeginHorizontal();
		if ( GUILayout.Button("Clear") )
		{
			coin.Clear();
		}
		
		if ( GUILayout.Button("Reset") )
		{
			coin.Reset();
		}
		GUILayout.EndVertical();
		
		coin._keepIntervalSec = EditorGUILayout.FloatField("KeppingIntervalSec", coin._keepIntervalSec);
		coin._pos = EditorGUILayout.Vector2Field("Pos", coin._pos);
		

	}
}
