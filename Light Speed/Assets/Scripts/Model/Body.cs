using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Body {

    int mass;
    public readonly int id;
    public readonly Trajectory trajectory;

    public Body(int m, Trajectory t) {
        id = Universe.UniqueID();
        mass = m;
        trajectory = t;
    }

}
