using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewUniverse : MonoBehaviour
{
    Universe universe = new Universe();

    [SerializeField]
    public ViewProbe viewProbe;

    // Start is called before the first frame update
    void Start()
    {
        Probe probe = new Probe(1, new Trajectory());
        viewProbe.Init(probe);
    }

    // Update is called once per frame
    void Update()
    {
        // Progress the universe at a chosen rate
        universe.Tick(Time.deltaTime);
    }
}
