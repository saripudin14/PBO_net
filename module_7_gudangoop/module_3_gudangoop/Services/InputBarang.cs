using System;
using module_3_gudangoop.Models; // Pastikan namespace ini benar untuk kelas Barang

namespace module_3_gudangoop.Services
{
    public class InputBarang
    {
        public Barang AmbilInput()
        {
            Console.Write("Kode: ");
            string kode = Console.ReadLine();
            Console.Write("Nama: ");
            string nama = Console.ReadLine();
            Console.Write("Stok: ");
            int stok = int.Parse(Console.ReadLine()); // Harusnya divalidasi, misalnya pakai InputHelper
            Console.Write("Kategori: ");
            string kategori = Console.ReadLine();

            // Konstruktor Barang akan menangani validasi stok (StokNegatifException dari Modul 6)
            return new Barang(kode, nama, stok, kategori);
        }
    }
}