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
public class Algorithms
{
    public static int FelezoMaximumKivalasztas(int[] x, int jobb, int bal)
    {
        if (bal == jobb)
        {
            return bal;
        }
        else
        {
            int center = (bal + jobb) / 2;
            int balmax = FelezoMaximumKivalasztas(x, bal, center);
            int jobbmax = FelezoMaximumKivalasztas(x, center + 1, jobb);
            if (x[balmax] >= x[jobbmax])
            {
                return balmax;
            }
            else
            {
                return jobbmax;
            }
        }
    }
    public static void OsszefesuloRendezes(ref int[] x, int bal, int jobb)
    {
        if (bal < jobb)
        {
            int center = (bal + jobb) / 2;
            OsszefesuloRendezes(ref x, bal, center);
            OsszefesuloRendezes(ref x, center + 1, jobb);
            Osszefesul(ref x, bal, center, jobb);
        }
    }
    private static void Osszefesul(ref int[] x, int bal, int center, int jobb)
    {
        int n1 = center - bal + 1;
        int n2 = jobb - center;
        float[] y1 = new float[n1 + 1];
        int i = 0;
        int j = 0;
        for (i = 0; i < n1; i++)
        {
            y1[i] = x[bal + i];
        }
        float[] y2 = new float[n2 + 1];
        for (j = 0; j < n2; j++)
        {
            y2[j] = x[center + 1 + j];
        }
        y1[n1] = float.PositiveInfinity;
        y2[n2] = float.PositiveInfinity;
        i = 0;
        j = 0;
        for (int k = bal; k <= jobb; k++)
        {
            if (y1[i] <= y2[j])
            {
                x[k] = (int)y1[i];
                i = i + 1;
            }
            else
            {
                x[k] = (int)y2[j];
                j = j + 1;
            }
        }
    }
    private static int Szetvalogat(ref int[] x, int bal, int jobb)
    {
        int seged = x[bal];
        while (bal < jobb)
        {
            while ((bal < jobb) && (x[jobb] > seged))
            {
                jobb = jobb - 1;
            }
            if (bal < jobb)
            {
                x[bal] = x[jobb];
                bal = bal + 1;
                while ((bal < jobb) && (x[bal] <= seged))
                {
                    bal = bal + 1;
                }
                if (bal < jobb)
                {
                    x[jobb] = x[bal];
                    jobb = jobb - 1;
                }
            }
        }
        int idx = bal;
        x[idx] = seged;
        return idx;
    }
    public static void GyorsRendezes(ref int[] x, int bal, int jobb)
    {
        int idx = Szetvalogat(ref x, bal, jobb);
        if (idx > bal + 1)
        {
            GyorsRendezes(ref x, bal, idx - 1);
        }
        if (idx < jobb - 1)
        {
            GyorsRendezes(ref x, idx + 1, jobb);
        }
    }

    public static int K_adikLegkisebbElem(int[] x, int bal, int jobb, int k)
    {
        if (bal == jobb)
        {
            return x[bal];
        }
        else
        {
            int idx = Szetvalogat(ref x, bal, jobb);
            if (k == idx - bal + 1)
            {
                return x[idx];
            }
            else if (k < idx - bal + 1)
            {
                return K_adikLegkisebbElem(x, bal, idx - 1, k);
            }
            else
            {
                return K_adikLegkisebbElem(x, idx + 1, jobb, k - (idx - bal + 1));
            }
        }
    }
}
