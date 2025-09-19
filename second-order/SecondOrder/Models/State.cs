namespace SecondOrder.Models;

public struct State
{
    public double Mass { get; set; }
    public double KDamping { get; set; }
    public double ForceMax { get; set; }
    public double ForceMin { get; set; }
    public double TimeStep { get; set; }
    public double Velocity { get; set; }
    public double Position { get; set; }
}
