
using System.Reflection;


namespace Library.Application.Queries
{
    public static class ApplicationQueryProvider
    {
        public static Assembly QueryAssembly => Assembly.GetExecutingAssembly();
    }
}
