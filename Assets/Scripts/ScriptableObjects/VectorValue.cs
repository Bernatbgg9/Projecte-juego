using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class VectorValue : ScriptableObject //,ISerializationCallbackReceiver
{
    public Vector2 spawnValue;
    public Vector2 firstRoomValue;

    /*public void OnAfterDeserialize()
    {
        initialValue = defaultValue;
    }

    public void OnBeforeSerialize() 
    {
    }*/
}
