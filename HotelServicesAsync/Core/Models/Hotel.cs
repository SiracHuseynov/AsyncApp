using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Hotel
    {
        private static int _id;
        public int Id { get; set; }
        public string Name { get; set; }

        public Hotel(string name)
        {
            _id++;
            Id = _id;
            Name = name;
        }

        public override string ToString()
        {
            return $"Id: {Id}; Name: {Name}";
        }

    }
}
