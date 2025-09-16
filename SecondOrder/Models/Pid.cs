namespace SecondOrder.Models;

public struct Pid
{
    public double Kp { get; set; } // Kp
    public double Ki { get; set; } // Ki
    public double Kd { get; set; } // Kd
    public double KAw { get; set; }
    public double T_C { get; set; }
    public double T { get; set; }
    public double Max { get; set; }
    public double Min { get; set; }
    public double MaxRate { get; set; }
    public double Integral { get; set; }
    public double PreviousError { get; set; }
    public double PreviousDerivative { get; set; }
    public double PreviousSaturatedCommand { get; set; }
    public double PreviousCommand { get; set; }
}
