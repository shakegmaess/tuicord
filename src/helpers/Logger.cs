namespace Logger
{
    public class Logger
    {
        public static void logString(string log, string appOpenTime, string logName = "log")
        {
            string logsPath = Path.Combine(AppContext.BaseDirectory, "logs");
            string finalFilePath = logsPath + "/" + logName + "_" + appOpenTime + ".log";
            if (Directory.Exists(logsPath) == false)
            {
                Directory.CreateDirectory(logsPath);
            }
            if (File.Exists(finalFilePath))
            {
                File.AppendAllText(finalFilePath, log.ToString());

            }
            else
            {
                File.WriteAllText(finalFilePath, log.ToString());
            }
        }
    }
}