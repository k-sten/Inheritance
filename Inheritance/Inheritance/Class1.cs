using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceNA20
{
    class Class1
    {
        public string Name { get; set; }
    }

    class Class2 : Class1
    {
        public int Age { get; set; }
    }

    sealed class Class3 : Class2
    {
        public string Adress { get; set; }
    }
}