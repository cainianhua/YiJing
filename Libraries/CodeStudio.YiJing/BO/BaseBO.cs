using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Reflection;

namespace CodeStudio.YiJing.BO
{
    public abstract class BaseBO
    {
        private static readonly string type = ConfigurationManager.AppSettings["DataProvider"] ?? "Sql";
        //private static readonly string path = "TheKnot.Games.LittleQuiz";
        private static readonly string path = Assembly.GetExecutingAssembly().FullName.Split(',')[0];
        private static string classpath = "{0}.Data.{1}.{2}Provider";

        protected virtual object CreateProvider(string name) {
            //Assembly.GetExecutingAssembly().GetName().Name
            return Assembly.Load(path).CreateInstance(String.Format(classpath, path, type, name));
        }
    }
}
