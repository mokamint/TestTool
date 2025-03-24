using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTool.DB
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Book { get; set; }
        public List<string> Category { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public List<string> Selection { get; set; }
        public string Difficulty { get; set; }
        public string IsUsed { get; set; }

        public Quiz()
        {
            Category = new List<string>();
            Selection = new List<string>();
        }
    }
}
