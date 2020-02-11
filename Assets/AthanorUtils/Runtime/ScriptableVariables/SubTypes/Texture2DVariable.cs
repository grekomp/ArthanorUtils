using UnityEngine;
[CreateAssetMenu(menuName = "Scriptable Variables/Texture2D")]
public class Texture2DVariable : ScriptableVariable<Texture2D> {
    public static Texture2DVariable New(Texture2D value = default) {
        var createdVariable = CreateInstance<Texture2DVariable>();
        createdVariable.Value = value;
        return createdVariable;
    }
}
