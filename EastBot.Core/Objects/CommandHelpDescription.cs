using System;
using System.Collections.Generic;
using System.Text;

namespace EastBot.Core.Object
{
    public class CommandHelpDescription
    {
        public CommandHelpDescription(string command, string description)
        {
            Command = command;
            Description = description;
        }

        public string Command { get; set; }
        public string Description { get; set; }
    }
}
