using System;

namespace PlakMP.DotNet.Commands
{
    /// <summary>
    /// PlakMP player command
    /// </summary>
    public class PlayerCommandAttribute : Attribute
    {
        public string ActualName { get; set; }

        /// <summary>
        /// PlakMP player command
        /// </summary>
        /// <param name="actualName">Use different command name for processing.<br/>If <see cref="null"/> uses default name processing/></param>
        public PlayerCommandAttribute(string actualName = null)
        {
            ActualName = actualName;
        }
    }
}
