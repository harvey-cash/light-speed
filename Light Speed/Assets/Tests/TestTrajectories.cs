using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestTrajectories
    {
        // A Test behaves as an ordinary method
        [Test]
        public void DeltaVAffectsTrajectory()
        {
            int timeNow = 0;
            Trajectory trajectoryNow = null;
            Vector3 dV = Vector3.one;

            Trajectory trajectoryNew = Trajectory.Manoeuvre(timeNow, trajectoryNow, dV);

            Assert.AreNotEqual(trajectoryNew, trajectoryNow);
        }
    }
}
