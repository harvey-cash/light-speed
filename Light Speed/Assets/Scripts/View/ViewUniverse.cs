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
        viewProbe.probe = probe;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the next state of the simulation
        float time = universe.Tick(Time.deltaTime);

        // Set the position of monobehaviour objects
        viewProbe.UpdatePosition(time);
    }
}
