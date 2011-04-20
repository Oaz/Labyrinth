using System;
using System.Diagnostics;

namespace Labyrinth
{
  public class Tools
  {
    public static void Assert<T>(bool condition, string format, params object[] parameters) where T:Exception
    {
      if(!condition)
        throw (Exception) Activator.CreateInstance(typeof(T), string.Format(format,parameters));
    }
  }
}


