

using P04_WildFarm.IO.Interfaces;
using P04_WildFarm.IO;
using P04_WildFarm.Core;
IReader reader = new ConsoleReader();
IWriter writer = new ConsoleWriter();
Engine engine = new(reader, writer);
engine.Run();