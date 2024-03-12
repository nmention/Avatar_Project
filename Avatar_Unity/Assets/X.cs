using UnityEngine;
using UnityEditor;

public class ExtractBoneNames : MonoBehaviour
{
    // Path to the FBX model file relative to the "Assets" folder
    public string fbxModelPath = "Models/girl_nonPBR.fbx";

    void Start()
    {
        // Construct the full asset path
        string fullAssetPath = "Assets/" + fbxModelPath;

        // Load the model from the specified path
        GameObject model = (GameObject)AssetDatabase.LoadAssetAtPath(fullAssetPath, typeof(GameObject));

        if (model == null)
        {
            Debug.LogError("Failed to load model from path: " + fullAssetPath);
            return;
        }

        // Get the model's animation rig
        AnimationClip[] clips = AnimationUtility.GetAnimationClips(model);
        if (clips.Length == 0)
        {
            Debug.LogError("No animation clips found in the model.");
            return;
        }

        ModelImporter modelImporter = (ModelImporter)AssetImporter.GetAtPath(fullAssetPath);

        // Get the bone names from the model importer
        string[] boneNames = modelImporter.transformPaths;

        // Print the bone names
        foreach (string boneName in boneNames)
        {
            Debug.Log("Bone Name: " + boneName);
        }
    }
}
