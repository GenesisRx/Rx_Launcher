﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RXPatchLib
{
    public class XdeltaPatchSystem
    {
        public string ExecutablePath;

        public XdeltaPatchSystem(string executablePath)
        {
            ExecutablePath = executablePath;
        }

        public async Task RunCommandAsync(params string[] arguments)
        {
            int exitCode = await ProcessEx.RunAsync(ExecutablePath, arguments);
            if (exitCode != 0)
            {
                throw new CommandExecutionException(ExecutablePath, arguments, exitCode);
            }
        }
    }

    public class XdeltaPatchSystemFactory
    {
        public static XdeltaPatchSystem X32 = new XdeltaPatchSystem("xdelta3-3.0.8.x86-32.exe");
        public static XdeltaPatchSystem X64 = new XdeltaPatchSystem("xdelta3-3.0.8.x86-64.exe");
        public static XdeltaPatchSystem Preferred = Environment.Is64BitOperatingSystem ? X64 : X32;
    }
}
