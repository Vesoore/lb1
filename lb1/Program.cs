using System;
using System.Collections.Generic;
using System.IO;
namespace lb1
{
    class Lb
    {   
        public Lb()
        {
            int number = 0;    
            Console.WriteLine("Введите функционал какого задания использовать 1,2 или 3");
            while (!int.TryParse(Console.ReadLine(), out number));
            while(number!=1 && number!=2 && number != 3)
            {
                while (!int.TryParse(Console.ReadLine(), out number)) ;
            }
            switch (number)
            {
                case 1:
                    task1();
                    break;
                case 2:
                    task2();
                    break;
                case 3:
                    task3();
                    break;
                    
                default:
                    break;
            }
        }
        
        virtual protected void task1()
        {
            Console.WriteLine("Введите массив через пробел");
            string s = Console.ReadLine();
            var ls=new List<int>();
            string[] t;
            
            t = s.Split();
            for (int i = 0; i < t.Length; i++)
                ls.Add(Convert.ToInt32(t[i]));
            foreach (int i in ls)
                Console.Write(i + " ");
            Console.WriteLine();
            Max_Min(ref ls);
            Console.WriteLine("Выберите режим сортировки массива 'a' или 'h' ");
            string r=Console.ReadLine();
            while(r!="a" && r!="h") r = Console.ReadLine();
            if (r =="a")
            {
                ls.Sort();
                foreach (var item in ls)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
                ls.Reverse();
                foreach (var item in ls)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
            if (r =="h")
            {
                Qsort(ref ls,0,ls.Count-1);
                foreach (var item in ls)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
                for (int i = ls.Count - 1; i >= 0; i--)
                    Console.Write(ls[i] + " ");
                Console.WriteLine();
            }
            
        }
      virtual  protected void task2()
        {
            Console.WriteLine("Введите количество строк в двумерном массиве");
            int n = -1;
            n=int.Parse(Console.ReadLine());
            Console.WriteLine("Введите массив с элементами через пробел");
            var ls=new List<int>();
            string[][] temp=new string[n][];
            for (int i = 0; i < n; i++)
            {
                string s = Console.ReadLine();
                temp[i]=s.Split();
                for (int j = 0; j < temp[i].Length; j++)
                {
                    ls.Add(Convert.ToInt32(temp[i][j]));
                }
            } 
            Max_Min(ref ls);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < temp[i].Length; j++)
                {
                    Console.Write(temp[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
      virtual protected void task3()
        {
            Console.WriteLine("Введите количество строк в двумерном массиве");
            int n = -1;
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите массив с элементами через пробел");
            var ls = new List<int>();
            string[][] temp = new string[n][];
            for (int i = 0; i < n; i++)
            {
                string s = Console.ReadLine();
                temp[i] = s.Split();
                for (int j = 0; j < temp[i].Length; j++)
                {
                    ls.Add(Convert.ToInt32(temp[i][j]));
                }
            }
            Console.WriteLine("Введите номер элемента массива");
            int num=int.Parse(Console.ReadLine());
            Random r = new Random();
            ls[num] = r.Next(-1000000,1000000);
            Max_Min(ref ls);
            int k = -1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < temp[i].Length; j++)
                {
                    Console.Write(ls[++k] + " ");
                }
                Console.WriteLine();
            }
        }
        protected void Qsort(ref List<int>ls,int left,int right)
        {
            int i=left, j=right;
            int tm = ls[(left+right)/ 2];
            do
            {
                while (ls[i] < tm && i < right)
                    i++;
                while (ls[j] > tm && j > left)
                    j--;
                if (i <= j)
                {
                    int y = ls[i];
                    ls[i] = ls[j];
                    ls[j] = y;
                    i++; j--;
                }
            } while (i <= j);

            if (left<j)
                Qsort(ref ls,left,j);
            if (right>i)
                Qsort(ref ls,i,right);
        }
        protected void Max_Min(ref List<int>t)
        {
            int ma = int.MinValue;
            int mi = int.MaxValue;
            int ki = -1;
            int ka = -1;
            for (int i = 0; i < t.Count; i++)
            {
                if (t[i] > ma)
                {
                    ma = t[i];
                    ka = i;
                    
                }
                if (t[i] < mi)
                {
                    mi = t[i];
                    ki = i;
                }
            }
            Console.WriteLine("Максимальное занчение {0} ({1}) ",ma,ka);
            Console.WriteLine("Минимальное занчение {0} ({1})", mi,ki);
            
        }
    }
    class LBf:Lb
    {
        protected override void task1()
        {
            Console.WriteLine("Введите массив через пробел");
            Console.WriteLine("Выберите режим сортировки массива 'a' или 'h' ");
            StreamReader streamReader = new StreamReader("task1.txt");
            string s=streamReader.ReadLine();
            var ls = new List<int>();
            string[] t;

            t = s.Split();
            for (int i = 0; i < t.Length; i++)
                ls.Add(Convert.ToInt32(t[i]));
            foreach (int i in ls)
                Console.Write(i + " ");
            Console.WriteLine();
            Max_Min(ref ls);
            s=streamReader.ReadLine();
            if (s == "a")
            {
                ls.Sort();
                foreach (var item in ls)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
                ls.Reverse();
                foreach (var item in ls)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
            if (s == "h")
            {
                Qsort(ref ls, 0, ls.Count - 1);
                foreach (var item in ls)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
                for (int i = ls.Count - 1; i >= 0; i--)
                    Console.Write(ls[i] + " ");
                Console.WriteLine();
            }
        }

        protected override void task2()
        {
            StreamReader streamReader = new StreamReader("task2.txt");
            var ls=new List<int>();
           // Console.WriteLine("Введите количество строк в двумерном массиве");
            //Console.WriteLine("Введите массив с элементами через пробел");
            int n=int.Parse(streamReader.ReadLine());
            string[][] temp = new string[n][];
            for (int i = 0; i < n; i++)
            {
                string s = streamReader.ReadLine();
                temp[i] = s.Split();
                for (int j = 0; j < temp[i].Length; j++)
                {
                    ls.Add(Convert.ToInt32(temp[i][j]));
                }
            }
            Max_Min(ref ls);
            for (int i = 0; i < n; i++)
            {
                for (int j=0;j<temp.Length; j++)
                    Console.Write(temp[i][j]+" ");
                Console.WriteLine();
            }
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string s="";
            while(s != "000")
            {
                //Console.WriteLine("Для завершения введите 000");
                Console.WriteLine("Выберите формат ввода: из файла 'f' или с клавиатуры 'k' или введите '000'для завершения работы");
                 s=Console.ReadLine();
                while (s != "000" && s != "f" && s != "k") s=Console.ReadLine();
                if (s == "000")
                    break;
                while(s!="f" && s!="k") Console.ReadLine();
                if (s == "f")
                {
                    LBf f = new LBf();
                }
                if (s == "k")
                {
                    Lb lb = new Lb();
                }
                Console.WriteLine("----------------------------------------------------------------------------");
            }
         
        }
    }
}
