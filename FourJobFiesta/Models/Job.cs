using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourJobFiesta.Models
{
    public class Job
    {
        public string Name { get; set; }
        public string[] Tags { get; set; }

        public Job(string name)
        {
            Name = name;
            Tags = new string[0];
        }

        public Job(string name, string tag)
        {
            Name = name;
            Tags = new[] { tag };
        }

        public Job(string name, string[] tags)
        {
            Name = name;
            Tags = tags;
        }
    }
}
