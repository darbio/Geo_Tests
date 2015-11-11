using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Model
{
    using Geo;

    public class MapSheet
    {
        public string Name { get; set; }

        public int Number { get; set; }

        public string Scale { get; set; }

        public string AMGZone { get; set; }

        public Envelope Envelope { get; set; }
    }
}
