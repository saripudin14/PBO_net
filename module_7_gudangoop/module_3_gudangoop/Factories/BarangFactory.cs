using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using module_3_gudangoop.Models; // Pastikan ini mengarah ke tempat class Barang berada

namespace module_3_gudangoop.Factories
{
    // Karena di bab7.pdf disebutkan BarangFactory adalah static class,
    // kita gunakan static class.
    public static class BarangFactory
    {
        // Method static untuk membuat barang berdasarkan tipe
        public static Barang BuatBarang(string tipe)
        {
            if (tipe == "Elektronik")
            {
                return new Barang("ELK001", "Scanner", 10, "Elektronik");
            }
            else if (tipe == "Makanan")
            {
                return new Barang("MAK001", "Susu", 50, "Minuman");
            }
            else
            {
                // Default atau tipe umum
                return new Barang("GEN001", "Barang Umum", 20, "Umum");
            }
        }

        // Contoh method lain, misalnya jika ingin membuat barang dengan parameter
        public static Barang BuatBarang(string kode, string nama, int stok, string kategori)
        {
            // Konstruktor Barang akan menangani validasi (misalnya StokNegatifException dari Modul 6)
            return new Barang(kode, nama, stok, kategori);
        }
    }
}