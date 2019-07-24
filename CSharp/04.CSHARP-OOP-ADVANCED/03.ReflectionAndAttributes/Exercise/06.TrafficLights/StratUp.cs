using System;
using System.Collections.Generic;
using System.Text;

public class StartUp
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        string startSignal = input[0];
        int countOfSignalChange = int.Parse(Console.ReadLine());
        TrafficLightsEnums startSignalEnum = (TrafficLightsEnums)Enum.Parse(typeof(TrafficLightsEnums), startSignal);
        int startSignalNum = (int)startSignalEnum;
        StringBuilder currentSignal = SignalSwitch(input);
        List<StringBuilder> signals = new List<StringBuilder>();

        for (int i = 0; i < countOfSignalChange; i++)
        {
            signals.Add(currentSignal);
            currentSignal = SignalSwitch(currentSignal.ToString().Split());
        }

        foreach (var line in signals)
        {
            Console.WriteLine(line.ToString().Trim());
        }
    }

    public static StringBuilder SignalSwitch(string[] signalsToSwitch)
    {
        StringBuilder sb = new StringBuilder();
        TrafficLightsEnums trafficLightsEnums;
        foreach (var signal in signalsToSwitch)
        {
            TrafficLightsEnums signalEnum = (TrafficLightsEnums)Enum.Parse(typeof(TrafficLightsEnums), signal);
            int currentSignalEnum = (int)signalEnum;
            int newSignalNum = (currentSignalEnum + 1) % 3;

            if (Enum.TryParse(newSignalNum.ToString(), out trafficLightsEnums))
            {
                sb.Append($"{trafficLightsEnums} ");
            }
        }
        string result = sb.ToString().Trim();
        sb.Clear();
        sb.Append(result);
        return sb;
    }
}

