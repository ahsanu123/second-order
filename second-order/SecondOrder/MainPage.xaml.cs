using SecondOrder.ExtensionMethods;
using SecondOrder.Models;

namespace SecondOrder;

public partial class MainPage : Page
{
    public MainPage()
    {
        this.InitializeComponent();
        var result = Simulate();
        var timeStep = 0.1;

        WinUIPlot1.Plot.Add.Signal(result[0].ToArray(), period: timeStep).LegendText = "time"; ;
        WinUIPlot1.Plot.Add.Signal(result[1].ToArray(), period: timeStep).LegendText = "setPoint";
        WinUIPlot1.Plot.Add.Signal(result[2].ToArray(), period: timeStep).LegendText = "command";
        WinUIPlot1.Plot.Add.Signal(result[3].ToArray(), period: timeStep).LegendText = "position";

        WinUIPlot1.Refresh();
    }

    public static List<List<double>> Simulate()
    {
        double position = 0;
        double command = 0;
        double timeStep = 0.1;
        double timeInSecond = 120;
        double length = timeInSecond / timeStep;

        double time = 0;
        double index = 0;
        double setPoint = 40;

        var simulatedData = new List<List<double>>{
          new List<double>(),
          new List<double>(),
          new List<double>(),
          new List<double>(),
          new List<double>(),
        };

        var pid = new Pid
        {
            Kp = 1,
            Ki = 0.1,
            Kd = 5,
            KAw = 0.1,
            T_C = 1,
            T = timeStep,
            Max = 100,
            Min = -100,
            MaxRate = 60,
            Integral = 0,
            PreviousError = 0,
            PreviousDerivative = 0,
            PreviousSaturatedCommand = 0,
            PreviousCommand = 0,
        };

        var state = new State
        {
            Mass = 10,
            KDamping = 0.5,
            ForceMax = 100,
            ForceMin = -100,
            TimeStep = timeStep,
            Velocity = 0,
            Position = 0,
        };

        while (index < length)
        {
            if (time > 60)
            {
                setPoint = 200;
            }

            command = pid.Step(measurement: position, setpoint: setPoint);
            position = state.Step(command);

            simulatedData[0].Add(time);
            simulatedData[1].Add(setPoint);
            simulatedData[2].Add(command);
            simulatedData[3].Add(position);

            time += timeStep;
            index++;
        }

        return simulatedData;
    }
}
