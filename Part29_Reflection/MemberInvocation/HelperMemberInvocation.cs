using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part29_Reflection.MemberInvocation
{
    public class HelperMemberInvocation
    {
        public static void DisplayInvocation(string[] args)
        {
            CommandLineInfo commandLine = new();
            if (!CommandLineHandler.TryParse(args, commandLine, out string? errorMessage))
            {
                Console.WriteLine(errorMessage);
                DisplayHelp();
            }
            else if (commandLine.Help || string.IsNullOrWhiteSpace(commandLine.Out))
            {
                DisplayHelp();
            }
            else
            {
                if (commandLine.Priority !=
                    ProcessPriorityClass.Normal)
                {
                    // Change thread priority
                }
                // ...
            }

            Console.WriteLine($"Last result of command Line Info is Out: {commandLine.Out} -Help: {commandLine.Help} - Priority: {commandLine.Priority}");
        }

        public static void DisplayHelp()
        {
            // Display the command-line help.
            Console.WriteLine(
                "Compress.exe /Out:< file name > /Help "
                + "/Priority:RealTime | High | "
                + "AboveNormal | Normal | BelowNormal | Idle");

        }
    }
}
