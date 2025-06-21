namespace Algos;
class Program
{
    static string JoinArray(int[] array) =>
        string.Join(", ", array);

    static void Main()
    {
        Console.WriteLine("\"Oszd meg és Uralkodj\" algoritmusok");
        var felezoTomb = new int[] { 23, 213, 22, 54, 12, 23, 55 };
        var maxIndex = Algorithms.FelezoMaximumKivalasztas(felezoTomb, 0, felezoTomb.Length - 1);
        Console.WriteLine($"FelezőMaximumkiválasztás: {JoinArray(felezoTomb)} \n-> Max index: {maxIndex}\n");

        var osszefesulTomb = new int[] { 3, 2, 1, 4, 8, 6, 12, 10, 7, 9, 5, 14, 13, 11 };
        Console.WriteLine($"ÖssztefésülőRendezés: {JoinArray(osszefesulTomb)}");
        Algorithms.OsszefesuloRendezes(ref osszefesulTomb, 0, osszefesulTomb.Length - 1);
        Console.WriteLine($"-> rendezve: {JoinArray(osszefesulTomb)}\n");

        var gyorsTomb = new int[] { 3, 2, 1, 4, 8, 6, 12, 10, 7, 9, 5, 14, 13, 11 };
        Console.WriteLine($"GyorsRendezés: {JoinArray(gyorsTomb)}");
        Algorithms.GyorsRendezes(ref gyorsTomb, 0, gyorsTomb.Length - 1);
        Console.WriteLine($"-> rendezve: {JoinArray(gyorsTomb)}\n");

        var kadikLegkisebbTombEredeti = new int[] { 3, 2, 1, 4, 8, 6, 12, 10, 7, 9, 5, 14, 13, 11 };
        var kadikLegkisebbTomb = new int[kadikLegkisebbTombEredeti.Length];
        Array.Copy(kadikLegkisebbTombEredeti, kadikLegkisebbTomb,kadikLegkisebbTombEredeti.Length);
        var k = 5;
        var k_adikLegkisebbElem = Algorithms.K_adikLegkisebbElem(kadikLegkisebbTomb, 0, kadikLegkisebbTomb.Length - 1, k);
        Console.WriteLine($"K-adikLegkisebbElem: {JoinArray(kadikLegkisebbTombEredeti)}\nk -> {k}\n K-adik legkisebb elem: {k_adikLegkisebbElem}");


    }
}