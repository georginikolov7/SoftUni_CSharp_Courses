using Log4U.Core.Appenders;
using Log4U.Core.Appenders.Interfaces;
using Log4U.Core.Enums;
using Log4U.Core.IO;
using Log4U.Core.Layouts;



var simpleLayout = new SimpleLayout();
var consoleAppender = new ConsoleAppender(simpleLayout);
consoleAppender.ReportLevel = ReportLevel.Error;
ILogFile file = new LogFile();
IAppender fileAppender = new FileAppender(simpleLayout, file);
var logger = new Log4U.Core.Loggers.Logger(consoleAppender,fileAppender);

logger.Info("3/31/2015 5:33:07 PM", "Everything seems fine");
logger.Warning("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent");
logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
logger.Critical("3/31/2015 5:33:07 PM", "No connection string found in App.config");
logger.Fatal("3/31/2015 5:33:07 PM", "mscorlib.dll does not respond");
