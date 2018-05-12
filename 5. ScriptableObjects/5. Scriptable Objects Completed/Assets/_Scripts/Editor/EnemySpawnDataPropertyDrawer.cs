using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(EnemySpawnData))]
public class EnemySpawnDataPropertyDrawer : PropertyDrawer {

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
		EditorGUI.BeginProperty(position, label, property);
		int indent = EditorGUI.indentLevel;
		EditorGUI.indentLevel = 0;

		float prefabRectWidthPercent = .75f;
		Rect prefabRect = new Rect(position.x, position.y, position.width * prefabRectWidthPercent, position.height);
		Rect secondsRect = new Rect(position.x + position.width * prefabRectWidthPercent, position.y, position.width * (1 - prefabRectWidthPercent), position.height);

		EditorGUI.PropertyField(prefabRect, property.FindPropertyRelative("enemyPrefab"));
		EditorGUI.PropertyField(secondsRect, property.FindPropertyRelative("spawnTime"), GUIContent.none);

		EditorGUI.indentLevel = indent;
		EditorGUI.EndProperty();
	}
}