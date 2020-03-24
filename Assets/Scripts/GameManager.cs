using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Camera mainCamera;

    // Update is called once per frame
    void Update() {
        Vector3 playerInput;

        if (Input.GetMouseButtonDown(0)) { // Computer input
            playerInput = Input.mousePosition;
        } else if (Input.touchCount > 0) { // Mobile device input
            playerInput = Input.GetTouch(0).position;
        } else {
            return;
        }

        // Cast a ray from the camera to the screen location
        Ray ray = mainCamera.ScreenPointToRay(playerInput);
        RaycastHit hit;

        // If there is a successful hit
        if (Physics.Raycast(ray, out hit, 100)) {
            // If you hit a destructable object, decrease its health
            if (hit.collider.gameObject.TryGetComponent(out Destructible destructable) && destructable.GetCanDestroy()) {
                destructable.DecreaseHealth();
            }
        }
    }

}
