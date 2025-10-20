using Modul3_GudangOOP.Models;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- Contoh Polimorfisme Dasar ---");
        Barang b1 = new Barang("BRG001", "Peti Plastik", 80, "Kemasan");
        Barang b2 = new BarangElektronik("ELK001", "Handheld Scan", 10, "Elektronik", 25);

        b1.TampilkanInfo();
        Console.WriteLine();
        b2.TampilkanInfo();
        Console.WriteLine("====================================\n");

        Barang b3 = new Barang();
        Console.WriteLine("--- Masukkan Info Barang Baru (b3) ---");

        while (true)
        {
            try
            {
                Console.Write("Masukan Nama Barang (max 15 char): ");
                b3.NamaBarang = Console.ReadLine();
                break;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"ERROR: {ex.Message} Silakan coba lagi.");
            }
        }

        Console.Write("Masukan Kode Barang: ");
        b3.KodeBarang = Console.ReadLine();

        while (true)
        {
            try
            {
                Console.Write("Masukan Jumlah Stok (angka >= 0): ");
                b3.JumlahStok = int.Parse(Console.ReadLine() ?? "0");
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("ERROR: Input harus berupa angka. Silakan coba lagi.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"ERROR: {ex.Message} Silakan coba lagi.");
            }
        }

        Console.Write("Masukan Kategori: ");
        b3.Kategori = Console.ReadLine() ?? "Umum";

        Console.WriteLine("\n\n--- Daftar Semua Barang dari Array ---");

        Barang[] daftarBarang = new Barang[]
        {
            new Barang("BRG002", "Kotak Kayu", 30, "Kemasan"),
            new BarangElektronik("ELK002", "Printer Laser", 5, "Elektronik", 150),
            b3
        };

        foreach (var barang in daftarBarang)
        {
            barang.TampilkanInfo();
            Console.WriteLine("--------------------");
        }
    }
}

