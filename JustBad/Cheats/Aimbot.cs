using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _1v1CheatFramework
{
    internal class Aimbot : MonoBehaviour // MonoBehaviour is a base class that many Unity scripts derive from.
    {
        private Animator aimbot_Animator; // The animator variable which will be used to get the bone position for the enemy for our aimbot hack.

        public static List<PlayerController> enemies = new List<PlayerController>(); // our list to hold the enemies inside of.
        public void Start()
        {
            StartCoroutine(FindEntites()); // Start the coroutine, basically its something that repeats every specified amount of time, useful for finding players etc.
        }

        private IEnumerator FindEntites()
        {
            while (true)
            {
                Visuals.oldMaterials.Clear(); // Clear the list inside the old material class to free up space of the old materials and make room for the new players materials.

                enemies.Clear();
                foreach (PlayerController player in FindObjectsOfType<PlayerController>()) // Find Object(s) by type, if your only finding one object e.g. the servers game manager you would likely use FindObjectOfType since it is only one thing you are finding.
                {
                    if (!player.IsMine()) // player.IsMine() has brackets at the end because it is a method, if it was a field e.g. there is a boolean value inside the PlayerController class, you would use something like "if (!player.teamBoolValue)".
                    {                     // btw inside an if statement something like this "if (player.isMine())" would only execute code if player.IsMine() method returns true, if you put an exclamation mark like i did, it only continues with the if statement if the player.IsMine() returns false.

                        enemies.Add(player); // if the enemy returns false for the player.IsMine() method call then we add them to our enemy list.
                    }    
                }

                yield return new WaitForSeconds(3f); // Once the loop of players has been completed our list will have all our enemies inside of it, this code waits 3 seconds until completion, then it repeats the coroutine from the top, clearing the enemies list and finding new players.
            }
        }
        public void Update() // Update is called every frame
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                List<PlayerController> enemyList = (from x in enemies orderby Vector3.Distance(x.transform.position, PlayerController.LFNGIIPNIDN.transform.position) select x).ToList<PlayerController>(); // Organise the list by the closest player. The closest player will be the first PlayerController in the list.

                PlayerController playerController = enemyList.FirstOrDefault<PlayerController>(); // Retrive the first PlayerController in the list, in our case it is the closest player already! This is thanks to the simple, one line list organisation above.

                aimbot_Animator = playerController.GetComponent<Animator>(); // Get the animator component of the closest player, GetComponent can be used to get the component that is attached to a game object, e.g. PlayerController.GetComponent<HealthManager>();
                                                                             // The animator component is used for movement and animations, in most games you can grab the animator straight from a player/entity by using GetComponent<>();

                Transform enemyBone = aimbot_Animator.GetBoneTransform(HumanBodyBones.Head); // Here we use the human body bones enumerator to get the transform for the head of the enemy player! Really as simple as that, in order to get access to this enumerator you have to reference Unity Animation module in your project

                Vector3 enemyPosition_Vector3 = enemyBone.transform.position; // get the vector3 x, y, z position of the enemies head by using transform.position on the enemies head bone transform we just got

                Vector3 enemyPosition_World2Screen = Camera.main.WorldToScreenPoint(enemyPosition_Vector3); // Convert the vector3 x, y, z coordinates of the enemy into a set of World To Screen coordinates! This pretty much just makes the coordinates for our pc screen, instead of the 3d world of the game.

                bool isVisible = !Utils.VisibleCheck(Camera.main.transform.position, enemyPosition_Vector3 + new Vector3(0, 1.2f, 0)); // Perform a raycast (shooting an invisible object towards an enemy, if we hit them, they are visible to our local player).

                if (enemyPosition_World2Screen.z > 0) // If the world to screen position of the enemy is greater than 0 on the z axis then we can aim at them because they are on our screen!
                {
                    if (isVisible)
                    {
                        Camera mainCamera = Camera.main;
                        mainCamera.transform.LookAt(enemyPosition_Vector3);
                    }
                }
            }
        }
    }
}
