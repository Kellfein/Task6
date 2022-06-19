using System;

namespace Task6
{
    struct Employee
    {
        public uint Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public byte Age { get; set; }
        public byte Height { get; set; }
        public DateTime Birthday { get; set; }
        public string Birthplace { get; set; }

        public string Print()
        {
            return $"{Id}#{Date}#{Name}#{Age}#" +
                $"{Height}#{Birthday}#{Birthplace}";
                
        }

    }
}
