using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeCounter {
	
    public class TimeConter : MonoBehaviour {

        public int intTimer;
        public bool isTimerEnabled;

        /// <summary>
        /// Display the timer with the proper format
        /// </summary>
        public void DisplayTimer(int intTimer, TMPro.TextMeshProUGUI tmpTimer) {
            int intMinutes = intTimer / 60;
            int intSeconds = intTimer % 60;

            string strMinutes = ((intMinutes < 10) ? ("0" + intMinutes) : (intMinutes.ToString()));
            string strSeconds = ((intSeconds < 10) ? ("0" + intSeconds) : (intSeconds.ToString()));
            tmpTimer.text = strMinutes + ":" + strSeconds;
        }


        public IEnumerator RunTimer(TMPro.TextMeshProUGUI tmpTimer) {
            while ((intTimer > -1) && (isTimerEnabled)) {
                yield return new WaitForSeconds(1);

                DisplayTimer(intTimer, tmpTimer);
                intTimer--;
            }
        }

    }
}
