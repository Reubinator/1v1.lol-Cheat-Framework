using System;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace _1v1CheatFramework
{
    internal class Visuals : MonoBehaviour
    {
        public static Dictionary<string, Material> oldMaterials = new Dictionary<string, Material>(); // Creates a dictionary that has a string for its key, and a material as its value. This will hold our enemies original materials which we can use to reset our chams.
        public static bool chamsToggle;

        public void OnGUI() // Everything visual i recommend to do under OnGUI(). MAKE SURE TO DO YOUR CHEAT MENU UNDER OnGUI(). OnGUI() gets called less than Update()
        {                   
            if (chamsToggle)
            {
                foreach (PlayerController enemy in Aimbot.enemies)
                {
                    foreach (SkinnedMeshRenderer enemyRenderer in enemy.GetComponentsInChildren<SkinnedMeshRenderer>()) // SkinnedMeshRenderer is our players model
                    {
                        if (!oldMaterials.ContainsKey(enemy.ECFNDIOEOMA.CIJLGLDLKBF)) // if the oldMaterials dictionary doesn't have the current players name in it then add them to the dictionary along with their materials so we can reset them later.
                        {
                            oldMaterials.Add(enemy.ECFNDIOEOMA.CIJLGLDLKBF, enemyRenderer.material);
                        }


                        if (!(enemyRenderer == null) && !(enemyRenderer.material == null) && !(enemyRenderer.material.shader == null) && !(enemyRenderer.material.GetColor("_Color") == Color.red)) // Check to see if we should render the chams.
                        {
                            enemyRenderer.material = new Material(Shader.Find("Hidden/Internal-Colored"))
                            {
                                hideFlags = (HideFlags.HideInHierarchy | HideFlags.DontSaveInEditor)
                            };
                            enemyRenderer.material.SetInt("_Cull", 0); // Sets which polygons the GPU should cull, based on the direction that they are facing relative to the camera. (This is how we get them to render through walls!)
                            enemyRenderer.material.SetInt("_ZWrite", 0); // Sets whether the depth buffer contents are updated during rendering. Normally, ZWrite is enabled for opaque objects and disabled for semi-transparent ones. (Dont expect you to know this)
                            enemyRenderer.material.SetInt("_ZTest", 8); // Sets the conditions under which geometry passes or fails depth testing. (Dont expect you to know this)

                            enemyRenderer.material.SetColor("_Color", Color.red); // Sets their color to red.
                        }
                    }
                }
            }
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.G)) // Check if the G key is pressed.
            {
                chamsToggle = !chamsToggle; // If the G key is pressed the chamsToggle boolean variable goes to either true/false until the key is pressed again. This creates a toggle like control
            }

            if (!chamsToggle) // If the chams toggle is set to false then run this code
            {
                foreach (PlayerController enemy in Aimbot.enemies)
                {
                    string enemyName = enemy.ECFNDIOEOMA.CIJLGLDLKBF; // enemy name field

                    foreach (var keyValuePair in oldMaterials) // A foreach loop for each variable in old materials. "keyValuePair" is just a name for the current variable in the foreach loop.
                    {
                        if (keyValuePair.Key.Contains(enemyName)) // if the current variable in the foreach loop that we just called keyValuePair has a key, which in this case when we assigned it was the players name then execute the code below.
                        {
                            foreach (SkinnedMeshRenderer enemyRenderer in enemy.GetComponentsInChildren<SkinnedMeshRenderer>()) // Get the skinned mesh renderer component of the player, this is pretty much the player model. Some skins might not use this and may use Renderer instead.
                            {
                                enemyRenderer.material = keyValuePair.Value; // Set the value of their material to the old one that they had that we stored in the dictionary along with their player name.
                            }
                        }
                    }
                }
            }
        }
    }
}
