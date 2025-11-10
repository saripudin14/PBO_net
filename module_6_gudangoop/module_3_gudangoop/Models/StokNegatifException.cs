using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module_3_gudangoop.Models
{
    public class StokNegatifException : Exception
    {
        public StokNegatifException(string pesan) : base(pesan) { }
    }
}
