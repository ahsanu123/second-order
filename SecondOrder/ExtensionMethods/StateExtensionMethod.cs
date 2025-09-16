using SecondOrder.Models;

namespace SecondOrder.ExtensionMethods;

public static class StateExtensionMethod
{
    public static double Step(this State state, double appliedForce)
    {
        double saturatedForce;
        double acceleration; // dv/dt

        if (appliedForce > state.ForceMax)
            saturatedForce = state.ForceMax;
        else if (appliedForce < state.ForceMin)
            saturatedForce = state.ForceMin;
        else
            saturatedForce = appliedForce;

        acceleration = (saturatedForce - state.KDamping * state.Velocity) / state.Mass;

        state.Velocity += acceleration * state.TimeStep;
        state.Position += state.Velocity * state.TimeStep;

        return state.Position;
    }
}
