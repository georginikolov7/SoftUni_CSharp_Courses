

using P03_Raiding.Core;
using P03_Raiding.IO;
using P03_Raiding.IO.Interfaces;

IReader reader = new ConsoleReader();
IWriter writer = new ConsoleWriter();
Engine engine = new(reader, writer);
engine.Run();