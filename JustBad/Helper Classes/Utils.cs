using UnityEngine;

namespace _1v1CheatFramework
{
    // Its always a great idea to organise different classes for different things, in this case i made a Utils class! This will hold my functions etc, you can also make different classes and even folders for
    // things like rendering and even different cheat categories.

    internal class Utils : MonoBehaviour // MonoBehaviour is a base class that many Unity scripts derive from.
    {
        public static bool VisibleCheck(Vector3 raycastOrigin, Vector3 targetPosition) // Our function to perform a visiblity check in game, raycastOrigin is where we are in game, this could be our vector3 world position or even Camera.main positon. 
        {                                                                              // The target position parameter is where we are shooting the raycast too.

            Vector3 direction = targetPosition - raycastOrigin; // Calculate the direction of the raycast.

            float maxDistance = direction.magnitude * 0.9f; // The max distance the raycast should check for collisions.

            return Physics.Raycast(new Ray(raycastOrigin, direction), maxDistance, PlayerController.LFNGIIPNIDN.AIACBMLLLFE.FEEHLHAFIMC, QueryTriggerInteraction.UseGlobal); // PlayerController.LFNGIIPNIDN.AIACBMLLLFE.FEEHLHAFIMC is a thing called a layer mask, in short it is pretty much a way for us to filter out anything 
                                                                                                                                                                             // the raycast hits that is not that layermask.
        }

        public static Color RainbowEffect() // simple rainbow effect function, pretty cool.
        {
            float time = Time.time;
            Color color = Color.HSVToRGB(time % 1f, 1f, 1f);
            return color;
        }
    }
}
