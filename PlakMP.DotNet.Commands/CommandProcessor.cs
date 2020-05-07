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

        public void Register<T>() => Register(typeof(T));

        public void Register(Type type)
            => commandTypes.Add(Activator.CreateInstance(type));

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

            method.Invoke(typeInstance, parameters.ToArray());
        }
    }
}
