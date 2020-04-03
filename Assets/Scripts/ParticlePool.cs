using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePool : SingletonManager<ParticlePool> {

    public List<ParticleSystem> particleSystems = new List<ParticleSystem>();

}
