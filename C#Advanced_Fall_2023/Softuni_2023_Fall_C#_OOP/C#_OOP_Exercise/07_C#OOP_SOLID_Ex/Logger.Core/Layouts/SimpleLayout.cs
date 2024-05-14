using Log4U.Core.Layouts.Interfaces;

namespace Log4U.Core.Layouts
{
    public class SimpleLayout : ILayout
    {
        private const string SimpleFormat = "{0} - {1} - {2}";
        public string Format => SimpleFormat;
    }
}
