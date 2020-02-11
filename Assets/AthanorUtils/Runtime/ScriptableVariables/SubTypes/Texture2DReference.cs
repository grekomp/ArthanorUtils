using System;
using UnityEngine;
[Serializable]
public class Texture2DReference : ScriptableVariableReference<Texture2D, Texture2DVariable> {
    public Texture2DReference() : base() { }
    public Texture2DReference(Texture2D value) : base(value) { }
    public Texture2DReference(Texture2DVariable variable) : base(variable) { }
}
