using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDefinition : MonoBehaviour {

    public string name_id = "default";
    public ParticleSystem particle;

    public void AttachSelf() {
        particle = this.gameObject.GetComponent<ParticleSystem>();
    }

}