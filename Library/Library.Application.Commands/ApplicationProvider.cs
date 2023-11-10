
using System.Reflection;


namespace Library.Application.Commands
{
    public static class ApplicationCommandProvider
    {
        public static Assembly CommandsAssembly => Assembly.GetExecutingAssembly();
    }
}
