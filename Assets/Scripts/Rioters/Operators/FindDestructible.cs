using System;
using FluidHTN;
using FluidHTN.Operators;
using UnityEngine;

namespace Rioters.Operators {
    public class FindDestructible : IOperator {

        public TaskStatus Update(IContext ctx) {
            if ( ctx is RioterHTNContext c ) {
                Destructible _closest = null;
                float _closestDist = float.PositiveInfinity;
                foreach ( Destructible destructible in c.destructiblesInRange ) {
                    if ( _closest == null ) {
                        _closest = destructible;
                        continue;
                    }

                    float dist = Vector3.Distance(destructible.transform.position, c.Position);
                    if ( dist < _closestDist ) {
                        _closestDist = dist;
                        _closest = destructible;
                    }
                }

                if (_closest != null) {
                    c.CurrentTarget = _closest;
                    return TaskStatus.Success;
                }
                return TaskStatus.Failure;
            }

            return TaskStatus.Failure;
        }


        public void Stop(IContext ctx) { }

    }
}