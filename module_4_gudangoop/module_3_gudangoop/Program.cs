using module_3_gudangoop.Models;

ItemGudang item1 = new BarangKimia("KIM001", "Asam Sulfat");
ItemGudang item2 = new BarangMakanan("MAK001", "Susu Kental",
DateTime.Parse("2023-12-01"));
item1.CetakInfo();
Console.WriteLine(item1.EvaluasiResiko());
item2.CetakInfo();
Console.WriteLine(item2.EvaluasiResiko());
if (item2 is IPeriksaKadaluarsa periksa)
{
    Console.WriteLine(periksa.ApakahKadaluarsa() ? "Kadaluarsa" : "Masih berlaku");
}