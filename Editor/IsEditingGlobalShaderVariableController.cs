using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class IsEditingGlobalShaderVariableController
{
    static IsEditingGlobalShaderVariableController()
    {
        EditorApplication.playModeStateChanged += PlayModeStateUpdated;
				Shader.SetGlobalInteger("_ISEDITING", 1);
    }

    private static void PlayModeStateUpdated(PlayModeStateChange change)
    {
        switch (change)
        {
            case PlayModeStateChange.EnteredEditMode:
                Shader.SetGlobalInteger("_ISEDITING", 1);
                break;
            case PlayModeStateChange.ExitingEditMode:
                Shader.SetGlobalInteger("_ISEDITING", 0);
                break;
            case PlayModeStateChange.EnteredPlayMode:
                Shader.SetGlobalInteger("_ISEDITING", 0);
                break;
            case PlayModeStateChange.ExitingPlayMode:
                Shader.SetGlobalInteger("_ISEDITING", 1);
                break;
            default:
                break;
        }
    }
}