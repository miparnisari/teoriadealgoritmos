using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using TP2.Model;

namespace TP2
{
    public class ScenarioFileReader : BaseScenarioReader
    {
        private string filepath;

        public ScenarioFileReader(string filepath)
        {
            this.filepath = filepath;
        }

        public override Stream Stream
        {
            get { return File.OpenRead(this.filepath); }
        }

    }
}
