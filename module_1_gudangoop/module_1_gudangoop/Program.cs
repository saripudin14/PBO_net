using Modul1_GudangOOP.Models;

class Program
{
    static void Main(string[] args)
    {
        Barang barang1 = new Barang("B001", "Laptop", 10, "Elektronik");
        Barang barang2 = new Barang("B002", "Kursi", 25, "Furnitur");
        Console.WriteLine("Informasi Barang 1:");
        barang1.TampilkanInfo();
        Console.WriteLine("\nInformasi Barang 2:");
        barang2.TampilkanInfo();

        Barang b3 = new Barang();
        Console.Write("\nMasukan Nama Barang:");
        b3.NamaBarang = Console.ReadLine();

        Console.Write("Masukan Kode Barang:");
        b3.KodeBarang = Console.ReadLine();

        Console.Write("Masukan Jumlah Stok:");
        b3.JumlahStok = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Masukan Kategori:");
        b3.Kategori = Console.ReadLine() ?? "Umum";

        Console.WriteLine("\nInformasi Barang 3:");
        Console.WriteLine("======================");
        b3.TampilkanInfo();
    }


}