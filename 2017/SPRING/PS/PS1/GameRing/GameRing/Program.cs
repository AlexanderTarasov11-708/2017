using System.IO;

namespace GameRing
{
    class Program
    {
        static void Main(string[] args)
        {
            var readPath = new StreamReader("data.txt");
            var listFromTextFile = DecodeText(readPath.ReadLine());
            readPath.Close();


            //listFromTextFile.Add(4,'M');
            var writePath = new StreamWriter("data.txt");
            //writePath.WriteLine(Encoding(listFromTextFile));
            writePath.Close();

            listFromTextFile.Remove(1);
            writePath = new StreamWriter("data.txt");
            writePath.WriteLine(Encoding(listFromTextFile));
            writePath.Close();

            writePath = new StreamWriter("male.txt");
            var tuple = listFromTextFile.SeparateGender(1);
            writePath.WriteLine(Encoding(tuple.Item1));
            writePath.Close();

            writePath = new StreamWriter("female.txt");
            writePath.WriteLine(Encoding(tuple.Item2));
            writePath.Close();

            var merged = tuple.Item1.Merge(tuple.Item2);
            writePath = new StreamWriter("data1.txt");
            writePath.WriteLine(Encoding(merged));
            writePath.Close();

            var check = listFromTextFile.Sort(1, false);
            writePath = new StreamWriter("data2.txt");
            writePath.WriteLine(Encoding(check));
            writePath.Close();

            var deleted = listFromTextFile.DeleteEveryK(3);
            writePath = new StreamWriter("deleted.txt");
            writePath.WriteLine(deleted.ID);
            writePath.Close();
        }

        public static RingList DecodeText(string path)
        {
            var newList = new RingList();
            for (int i = 0; i<path.Length; i++)
            {
                newList.Add(path[i]);
            }
            return newList;
        }

        public static string Encoding(RingList list)
        {
            var text = "";
            foreach (var elem in list)
                text += elem.GetChar();
            return text;
        }
    }
}
