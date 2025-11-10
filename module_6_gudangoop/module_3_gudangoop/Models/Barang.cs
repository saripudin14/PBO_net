using System;

namespace module_3_gudangoop.Models
{
    public class Barang
    {
        private string kodeBarang;
        private string namaBarang;
        private int jumlahStok;
        private string kategori;

        public Barang(string kode, string nama, int stok, string kategori)
        {
            KodeBarang = kode;
            NamaBarang = nama;
            JumlahStok = stok; // Akan memicu validasi
            Kategori = kategori;
        }

        public Barang() { } // Konstruktor default

        public string KodeBarang
        {
            get => kodeBarang;
            set => kodeBarang = value;
        }

        public string NamaBarang
        {
            get => namaBarang;
            set => namaBarang = value;
        }

        public int JumlahStok
        {
            get => jumlahStok;
            set
            {
                if (value < 0)
                    throw new StokNegatifException("Jumlah stok tidak boleh negatif.");
                jumlahStok = value;
            }
        }

        public string Kategori
        {
            get => kategori;
            set => kategori = value;
        }

        public virtual void TampilkanInfo()
        {
            Console.WriteLine($"Kode: {KodeBarang}, Nama: {NamaBarang}, Stok: {JumlahStok}, Kategori: {Kategori}");
        }
    }
}