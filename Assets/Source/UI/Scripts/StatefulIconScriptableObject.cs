using System;
using UnityEngine;

[Serializable]
public class IconState{
    public Sprite sprite;
    public Color tint = Color.black;    
}

[CreateAssetMenu(fileName = "StatefulIconScriptableObject", menuName = "StatefulIconScriptableObject", order = 0)]
public class StatefulIconScriptableObject : ScriptableObject {
    public IconState normal_state;
    public IconState active_state;
    public IconState disabled_state;
    
}