using Modul2_GudangOOP.Models;

class Program
{
    static void Main(string[] args)
    {
        Barang barang1 = new Barang("B001", "Laptop", 100, "Elektronik");
        Barang barang2 = new Barang("B002", "Kursi", 25, "Furnitur");
        Console.WriteLine("Informasi Barang 1:");
        barang1.TampilkanInfo();
        Console.WriteLine("\nInformasi Barang 2:");
        barang2.TampilkanInfo();

        Barang b3 = new Barang();
        Console.WriteLine("\n--- Masukkan Info Barang 3 ---");

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

        Console.WriteLine("\nInformasi Barang 3:");
        Console.WriteLine("======================");
        b3.TampilkanInfo();
    }
}