using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jint.Temp
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new Jint.JintEngine();
            engine.SetDebugMode(true);

            engine.Run(@"

var obj = {
    name : 'foo',
    friend: function() {
        return { name: 'buddy' }
    }
};
obj.friend( obj.name ).name;
            ");
        }
    }
}
