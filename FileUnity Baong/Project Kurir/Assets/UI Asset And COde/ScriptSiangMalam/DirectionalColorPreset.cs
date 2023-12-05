using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[System.Serializable]

[CreateAssetMenu ( fileName = "LightingPreset", menuName = "Scriptable/Lighting Preset", order = 1)]
public class DirectionalColorPreset : ScriptableObject
{
    [SerializeField] public Gradient AmbientColor;    
    [SerializeField] public Gradient DirectionalColor;
    [SerializeField] public Gradient FogColor;

    [SerializeField] public Gradient SkyColor;

    [SerializeField] public Gradient EquatorColor; 
}
