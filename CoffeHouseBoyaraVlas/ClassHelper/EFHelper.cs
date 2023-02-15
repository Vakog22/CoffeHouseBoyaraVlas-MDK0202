using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CoffeHouseBoyaraVlas.DB;

namespace CoffeHouseBoyaraVlas.ClassHelper
{
    public class EFHelper
    {
        public static Entities Context { get; } = new Entities();

    }
}
