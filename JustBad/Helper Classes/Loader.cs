using UnityEngine;

namespace _1v1CheatFramework
{
    public class Loader : MonoBehaviour // MonoBehaviour is a base class that many Unity scripts derive from.
    {
        public static GameObject loadObject; // The loader GameObject for our cheat.

        public static void Init() // Method for loading the cheat with sharp mono injector
        {
            loadObject = new GameObject();

            loadObject.AddComponent<Aimbot>(); // Add our other .cs files as components to the loader gameobject
            loadObject.AddComponent<Utils>(); 
            loadObject.AddComponent<ModifyingFields>();
            loadObject.AddComponent<Visuals>();

            DontDestroyOnLoad(loadObject); // Dont destroy our loader game object on scene change/load
        }

        public static void Unload() // A simple method to destroy our cheat (uninject).
        {
            Destroy(loadObject);
        }
    }
}
