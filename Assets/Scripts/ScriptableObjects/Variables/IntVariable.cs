using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Int")]
public class IntVariable : ScriptableObject, ISerializationCallbackReceiver
{
    public int initialValue;

    [NonSerialized]
    public int Value;

    public void OnBeforeSerialize()
    {
    }

    public void OnAfterDeserialize()
    {
        Value = initialValue;
    }
}
