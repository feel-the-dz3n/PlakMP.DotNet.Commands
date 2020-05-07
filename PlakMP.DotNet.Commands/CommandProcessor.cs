using PlakMP.DotNet.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PlakMP.DotNet.Commands
{
    public class CommandProcessor
    {
        private List<object> commandTypes = new List<object>();
        private List<ITypeConverter> converters = new List<ITypeConverter>();

        /// <summary>
        /// Register converter or commands type
        /// </summary>
        public void Register<T>() => Register(typeof(T));

        /// <summary>
        /// Register converter or commands type
        /// </summary>
        public void Register(Type type)
        {
            if (type.GetInterfaces().Contains(typeof(ITypeConverter)))
            {
                var instance = Activator.CreateInstance(type);
                converters.Add((ITypeConverter)instance);
            }
            else
            {
                commandTypes.Add(Activator.CreateInstance(type));
            }
        }

        public void ProcessCommand(IPlayer player, string command)
        {
            foreach (var instance in commandTypes)
            {
                var method = instance.GetType().GetMethods()
                    .FirstOrDefault(x => x.GetCustomAttributes(typeof(PlayerCommandAttribute), true).Length > 0);

                if (method != null)
                    ProcessMethod(player, command, method, instance);
            }
        }

        private void ProcessMethod(IPlayer player, string command, MethodInfo method, object typeInstance)
        {
            var parameters = new List<object>();

            // TODO: do here some convertation stuff
            var args = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var arg in method.GetParameters())
            {

            }

            method.Invoke(typeInstance, parameters.ToArray());
        }

        private object Convert<T>(T instance, string command)
        {
            var converter = converters.FirstOrDefault(x => x.InitialType == typeof(T));
            if (converter == null) return null;
            return converter.Convert(instance, command);
        }
    }
}
