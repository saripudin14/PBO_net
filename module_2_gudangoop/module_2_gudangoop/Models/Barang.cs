namespace Modul2_GudangOOP.Models
{
    public class Barang
    {
        public string KodeBarang;

        private string namaBarang;

        public string NamaBarang
        {
            get => namaBarang;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Nama barang tidak boleh kosong.");
                }

                if (value.Length > 15)
                {
                    throw new ArgumentException("Nama barang tidak boleh lebih dari 15 karakter.");
                }

                namaBarang = value;
            }
        }

        private int jumlahStok;

        public int JumlahStok
        {
            get => jumlahStok;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Jumlah stok tidak boleh negatif.");
                }
                jumlahStok = value;
            }
        }

        public string Kategori { get; set; }

        public string Status => JumlahStok > 50 ? "Aman" : "Perlu Reorder";

        public Barang(string kode, string nama, int stok, string kategori)
        {
            KodeBarang = kode;
            this.NamaBarang = nama;
            this.JumlahStok = stok;
            this.Kategori = kategori;
        }

        public Barang()
        {
            KodeBarang = "Unknown";
            this.NamaBarang = "Unknown";
            this.JumlahStok = 0;
            this.Kategori = "Umum";
        }

        public void TampilkanInfo()
        {
            Console.WriteLine($"Kode Barang : {KodeBarang}");
            Console.WriteLine($"Nama Barang : {NamaBarang}");
            Console.WriteLine($"Jumlah Stok : {JumlahStok}");
            Console.WriteLine($"Kategori    : {Kategori}");
            Console.WriteLine($"Status      : {Status}");
        }
    }
}