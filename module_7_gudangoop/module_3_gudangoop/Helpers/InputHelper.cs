using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using module_3_gudangoop.Models; // Pastikan namespace ini benar untuk kelas Barang dan StokNegatifException

namespace module_3_gudangoop.Helpers
{
    public static class InputHelper
    {
        public static int AmbilStokValid()
        {
            while (true)
            {
                Console.Write("Jumlah Stok: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int stok))
                {
                    if (stok >= 0)
                    {
                        return stok;
                    }
                    else
                    {
                        Console.WriteLine("Stok tidak boleh negatif.");
                    }
                }
                else
                {
                    Console.WriteLine("Input harus berupa angka!");
                }
            }
        }

        public static Barang AmbilInputBarang()
        {
            Console.Write("Kode: ");
            string kode = Console.ReadLine();
            Console.Write("Nama: ");
            string nama = Console.ReadLine();
            int stok = AmbilStokValid();
            Console.Write("Kategori: ");
            string kategori = Console.ReadLine();

            // Konstruktor Barang akan menangani validasi stok (StokNegatifException dari Modul 6)
            return new Barang(kode, nama, stok, kategori);
        }
    }
}