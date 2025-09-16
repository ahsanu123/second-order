using SecondOrder.Models;

namespace SecondOrder.ExtensionMethods;

public static class PidExtensionMethod
{
    public static double Step(this Pid pid, double measurement, double setpoint)
    {
        // csharpier-ignore-start
        double error = setpoint - measurement;

        pid.Integral += pid.Ki * error * pid.T + pid.KAw * (pid.PreviousSaturatedCommand - pid.PreviousCommand) * pid.T;

        double derivativeFilter = (error - pid.PreviousError + pid.T_C * pid.PreviousDerivative) / (pid.T + pid.T_C);

        pid.PreviousError = error;
        pid.PreviousDerivative = derivativeFilter;

        double command = pid.Kp * error + pid.Integral + pid.Kd * derivativeFilter;

        pid.PreviousCommand = command;

        double saturatedCommand;

        if (command > pid.Max) saturatedCommand = pid.Max;
        else if (command < pid.Min) saturatedCommand = pid.Min;
        else saturatedCommand = command;

        double maxPreviouseSaturatedCommand = pid.PreviousSaturatedCommand + pid.MaxRate * pid.T;
        double minPreviouseSaturatedCommand = pid.PreviousSaturatedCommand - pid.MaxRate * pid.T;

        if (saturatedCommand > maxPreviouseSaturatedCommand)
            saturatedCommand = maxPreviouseSaturatedCommand;

        else if (saturatedCommand < minPreviouseSaturatedCommand)
            saturatedCommand = minPreviouseSaturatedCommand;

        pid.PreviousSaturatedCommand = saturatedCommand;

        return saturatedCommand;
        // csharpier-ignore-stop
    }
}
