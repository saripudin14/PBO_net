using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module_3_gudangoop.Models
{
    public interface IPeriksaKadaluarsa
    {
        DateTime TanggalKadaluarsa { get; set; }
        bool ApakahKadaluarsa();
    }
}
