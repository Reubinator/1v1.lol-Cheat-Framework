using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _1v1CheatFramework
{
    // This class is going to be for modifying and reading the value inside the games fields, this should show you the basic stuff.

    internal class ModifyingFields : MonoBehaviour
    {
        public static string lowestEnemyName;

        public void OnGUI()
        {
            GUIStyle textStyle = new GUIStyle();
            textStyle.normal.textColor = Utils.RainbowEffect();
            textStyle.fontStyle = FontStyle.Bold;

            GUI.Label(new Rect(0, 0, 150, 50), $"Lowest Enemies Name: {lowestEnemyName}", textStyle); // example of reading a value field and printing it on screen.
        }

        public void Update()
        {
            // This is just reading values, the next part moves on to writing values.

            PlayerHealth health = PlayerController.LFNGIIPNIDN.ABDABPEKBFM;
            int currentHealth = health.CHFPIGOLOOB; 
            int currentShield = health.OLLCMEJHPIL;

            List<PlayerController> enemyList = Aimbot.enemies.OrderBy(e => e.ABDABPEKBFM.CHFPIGOLOOB).ThenBy(e => e.ABDABPEKBFM.OLLCMEJHPIL).ToList(); // Organise the list by the lowest health & shield player.

            PlayerController lowestEnemy = enemyList.FirstOrDefault<PlayerController>(); // Retrive the first PlayerController in the list.


            lowestEnemyName = lowestEnemy.ECFNDIOEOMA.CIJLGLDLKBF; // The field CIJLGLDLKBF contains the players name string.


            // ************************************************************************************************************************************************************************************************** //

            // Changing values is easy asf in unity i mean its super easy! here is an example.

            PlayerController.LFNGIIPNIDN.AIACBMLLLFE.PFPIKMMEICB.SetCurrentMagazineAmount(30); // Since this is under Update() it we be called ever frame, therefore "freezing" our ammo amount at 30

        }
    }
}
