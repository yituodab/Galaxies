namespace Galaxies.Core.ModLoader;
public class Logger{
    public enum LogType{
        INFO,
        WARN,
        ERROR
    }
    public writeToConsole(LogType logType, object message){
        string loginfo = "[" + System.DataTime.Now.ToString("T") + "][" + logType.ToString() + "]";
        Console.WriteLine(loginfo + message.ToString());
    }
}