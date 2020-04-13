using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Namespace that contains all the functions that deal with time
/// </summary>
namespace TimeCounting {
	
    public class TimeCounter : MonoBehaviour {

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

        /// <summary>
        /// Run the timer continuosly until it zeroes
        /// </summary>
        /// <param name="tmpTimer"></param>
        /// <returns></returns>
        public IEnumerator RunTimer(TMPro.TextMeshProUGUI tmpTimer) {
            while ((intTimer > -1) && (isTimerEnabled)) {
                yield return new WaitForSeconds(1);

                DisplayTimer(intTimer, tmpTimer);
                intTimer--;
            }
        }

    }
}
