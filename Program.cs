using MethodDecorator.Fody.Interfaces;
using System;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.Encodings.Web;

namespace loggertest
{
    class Program
    {
        static void Main(string[] args)
        {
            testfody tester = new testfody();
            tester.examplemethod();
            tester.exceptionfunction();
        }
    }


    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Assembly | AttributeTargets.Module)]
    public class LoggableAttribute : Attribute,  IMethodDecorator
    {
        private MethodBase _method;
        public void Init(object instance, MethodBase method, object[] args)
        {
            _method = method;
        }
        public void OnEntry()
        {
            Console.WriteLine("\tEntering method " + _method.Name);
        }

        public void OnExit()
        {
            Console.WriteLine("\tExiting method " +_method.Name);
        }

        public void OnException(Exception exception)
        {
            Console.WriteLine("\tException thrown: " + exception.Message);
        }
    }


    class testfody
    {

        [Loggable]
        public void examplemethod()
        {
            Console.WriteLine("\t.............Inside the method");
        }

        [Loggable]
        public void exceptionfunction()
        {
            throw new NullReferenceException();
        }
    }

}
