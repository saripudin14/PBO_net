using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using module_3_gudangoop.Models; // Pastikan namespace ini benar untuk kelas Barang

namespace module_3_gudangoop.Interfaces
{
    // Interfaces harus didefinisikan dengan kata kunci 'interface', bukan 'class'
    public interface IBarangPrinter
    {
        // Definisikan method yang harus diimplementasikan oleh class lain
        void Cetak(Barang barang);
    }
}