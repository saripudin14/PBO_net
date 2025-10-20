namespace Modul1_GudangOOP.Models;
public class Barang
{
    public string KodeBarang;
    public string NamaBarang;
    public int JumlahStok;
    public string Kategori;
    public Barang(string kode, string nama, int stok, string kategori)
    {
        KodeBarang = kode;
        NamaBarang = nama;
        JumlahStok = stok;
        Kategori = kategori;
    }

    public void TampilkanInfo()
    {
        Console.WriteLine($"Kode Barang: {KodeBarang}");
        Console.WriteLine($"Nama Barang: {NamaBarang}");
        Console.WriteLine($"Jumlah Stok: {JumlahStok}");
        Console.WriteLine($"Kategori: {Kategori}");
    }

    public Barang() {
        KodeBarang = "UNKNOWN";
        NamaBarang = "UNKNOW";
        JumlahStok = 0;
        Kategori = "Umum"; 
    }

}

