using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace lb1
{
    class Lb
    {   
        public Lb()
        {
            int a = 0;    
            Console.WriteLine("Введите функционал какого задания использовать '1','2' или '3' ");
            while (!int.TryParse(Console.ReadLine(), out a)) ;
            while (a != 1 && a != 2 && a != 3)
            {
                while (!int.TryParse(Console.ReadLine(), out a)) ;
            }
            switch (a)
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
        private bool Check(ref string[] s)
        {
            int n = -1;
            for (int i=0; i < s.Length; i++)
            {
                if (!int.TryParse(s[i], out n))
                {
                    return false;
                }
            }
            return true;
        }
        virtual protected void task1()
        {
            Console.WriteLine("Введите массив через пробел");
            string s = "";
            string[] t=null;
            bool flag = true;
            while(flag)
            {
                flag = false;
                s = Console.ReadLine();
                t = s.Split();
                if (!Check(ref t))
                {
                    Console.WriteLine("Некорректные данные, введите еще");
                    flag = true;
                }
            }
            
            var ls=new List<int>();
            for (int i = 0; i < t.Length; i++)
                ls.Add(Convert.ToInt32(t[i]));
            foreach (int i in ls)
                Console.Write(i + " ");
            Console.WriteLine();
            Max_Min(ref ls);
            Console.WriteLine("Выберите режим сортировки массива 'a' или 'h' ");
            string r = Console.ReadLine();
            while (r != "a" && r != "h")
            {
                Console.WriteLine("Некорректные данные");
                r = Console.ReadLine();
            }
            if (r =="a")
            {
                ls.Sort();
                Console.WriteLine(string.Join(" ", ls));
                ls.Reverse();
                Console.WriteLine(string.Join(" ", ls));
            }
            if (r =="h")
            {
                Qsort(ref ls,0,ls.Count-1);
                Console.WriteLine(string.Join(" ", ls));
                for (int i = ls.Count - 1; i >= 0; i--)
                    Console.Write(ls[i] + " ");
                Console.WriteLine();
            }
            
        }
      virtual protected void task2()
        {
            Console.WriteLine("Введите количество строк в двумерном массиве");
            int n = -1;
            while (!int.TryParse(Console.ReadLine(), out n)) ;
            Console.WriteLine("Введите массив с элементами через пробел");
            var ls=new List<int>();
            string[][] temp=new string[n][];
            string s = "";
            bool flag = true;
            while (flag)
            {
                flag = false;

                for (int i = 0; i < n; i++)
                {
                    s = Console.ReadLine();
                    temp[i] = s.Split();
                    if (!Check(ref temp[i]))
                    {
                        Console.WriteLine("Некорректные данные, введите еще");
                        flag = true;
                        break;
                    }
                    
                    for (int j = 0; j < temp[i].Length; j++)
                    {
                        ls.Add(Convert.ToInt32(temp[i][j]));
                    }
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
            while (!int.TryParse(Console.ReadLine(), out n)) ;
            Console.WriteLine("Введите массив с элементами через пробел");
            var ls = new List<int>();
            string[][] temp = new string[n][];
            string s = "";
            bool flag = true;
            while (flag)
            {
                flag = false;

                for (int i = 0; i < n; i++)
                {
                    s = Console.ReadLine();
                    temp[i] = s.Split();
                    if (!Check(ref temp[i]))
                    {
                        Console.WriteLine("Некорректные данные, введите еще");
                        flag = true;
                        break;
                    }

                    for (int j = 0; j < temp[i].Length; j++)
                    {
                        ls.Add(Convert.ToInt32(temp[i][j]));
                    }
                }
            }
            Max_Min(ref ls);
            Console.WriteLine("Введите номер элемента массива");
            int num=-1;
            bool flag2 = true;
            while (flag2)
            {
                flag2 = false;
                while (!int.TryParse(Console.ReadLine(), out num));
                if (num > ls.Count - 1)
                {
                    Console.WriteLine("Нет такого индекса массива");
                    flag2 = true;
                }
            }
            Random r = new Random();
            ls[num] = r.Next(-1000000,1000000);
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
        private void check_path(ref string path)
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                path = Console.ReadLine();
                if (!File.Exists(path))
                {
                    flag = true;
                    Console.WriteLine("Некорректный путь к файлу");
                }
            }
        }
        private bool chek_str(ref string s)
        {
            int n = 0;
            string[] t = s.Split();
            for (int i=0;i<t.Length;i++)
            {
                if (!int.TryParse(t[i], out n))
                {
                    return false;
                }
            }
            return true;
        }
    
        protected override void task1()
        {
            Console.WriteLine("Введите массив через пробел и режим сортировки ('a' или 'h') на след. строке в файле ");
            string s="", s1="";
            bool flag = true;
            while(flag)
            {
                flag=false;
                Console.WriteLine("Введите путь к этому файлу с указанием типа файла(.txt) ");
                string path = "";
                check_path(ref path);
                StreamReader streamReader = new StreamReader(path);
                s = streamReader.ReadLine();
                s1 = streamReader.ReadLine();
                if (!chek_str(ref s))
                {
                    flag = true;
                    Console.WriteLine("Некорректные данные в файле, попробуйте заново ");
                    streamReader.Close();
                }
                 if (s1!="a" && s1!="h")
                {
                    flag = true;
                    Console.WriteLine("Некорректные дынные в файле, попробуйте заново ");
                    streamReader.Close();
                }
            }

            var ls = new List<int>();
            string[] t= s.Split();
            for (int i = 0; i < t.Length; i++)
                ls.Add(Convert.ToInt32(t[i]));
            Console.WriteLine(string.Join(" ", ls));
            Max_Min(ref ls);
            if (s1 == "a")
            {
                ls.Sort();
                Console.WriteLine(string.Join(" ", ls));
                ls.Reverse();
                Console.WriteLine(string.Join(" ", ls));
            }
            if (s1 == "h")
            {
                Qsort(ref ls, 0, ls.Count - 1);
                Console.WriteLine(string.Join(" ", ls));
                for (int i = ls.Count - 1; i >= 0; i--)
                    Console.Write(ls[i] + " ");
                Console.WriteLine();
            }
        }

        protected override void task2()
        {
            var ls=new List<int>();
            var lst = new List<string>();
            Console.WriteLine("Введите массив с элементами через пробел в файл");
            string s = "";
            bool flag = true;
            while (flag)
            {
                flag = false;
                Console.WriteLine("Введите путь к этому файлу с указанием типа файла(.txt) ");
                string path = "";
                check_path(ref path);
                StreamReader streamReader = new StreamReader(path);
                
                while (!streamReader.EndOfStream)
                {
                    s = streamReader.ReadLine();
                    if (!chek_str(ref s))
                    {
                        flag = true;
                        Console.WriteLine("Некорректные данные в файле, попробуйте заново ");
                        streamReader.Close();
                        break;
                    }
                    lst.Add(s);
                }

                
            }

            string[][] temp = new string[lst.Count][];
            for (int i = 0; i < lst.Count; i++)
            {
                temp[i] = lst[i].Split();
                for (int j = 0; j < temp[i].Length; j++)
                {
                    ls.Add(Convert.ToInt32(temp[i][j]));
                }
            }
            Max_Min(ref ls);
            foreach (var item in lst)
            {
                Console.WriteLine(item);
            }
        }
        protected override void task3()
        {
            var ls = new List<int>();
            var lst = new List<string>();
            Console.WriteLine("Введите массив с элементами через пробел в файл");
            string s = "";
            bool flag = true;
            while (flag)
            {
                flag = false;
                Console.WriteLine("Введите путь к этому файлу с указанием типа файла(.txt) ");
                string path = "";
                check_path(ref path);
                StreamReader streamReader = new StreamReader(path);

                while (!streamReader.EndOfStream)
                {
                    s = streamReader.ReadLine();
                    if (!chek_str(ref s))
                    {
                        flag = true;
                        Console.WriteLine("Некорректные данные в файле, попробуйте заново ");
                        streamReader.Close();
                        break;
                    }
                    lst.Add(s);
                }
            }
            string[][] temp = new string[lst.Count][];
            for (int i = 0; i < lst.Count; i++)
            {
                temp[i] = lst[i].Split();
                for (int j = 0; j < temp[i].Length; j++)
                {
                    ls.Add(Convert.ToInt32(temp[i][j]));
                }
            }
            for (int i = 0; i < lst.Count; i++)
            {
                for (int j = 0; j < temp[i].Length; j++)
                {
                    Console.Write(temp[i][j]+" ");
                }
                Console.WriteLine();
            }
            Max_Min(ref ls);
            Console.WriteLine("Введите номер элемента массива");
            int n = -1;
            while (!int.TryParse(Console.ReadLine(),out n));
            Random r = new Random();
            ls[n] = r.Next(-1000000, 1000000);
            int k = -1;
            for (int i = 0; i < lst.Count; i++)
            {
                for (int j = 0; j < temp[i].Length; j++)
                {
                    Console.Write(ls[++k] + " ");
                }
                Console.WriteLine();
            }

        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            string s="";
            while (s != "000")
            {
                Console.WriteLine("Выберите формат ввода: из файла 'f' или с клавиатуры 'k' или введите '000'для завершения работы");
                s = Console.ReadLine();
                while (s != "000" && s != "f" && s != "k")
                {
                    Console.WriteLine("Некоррктный ввод");
                    s = Console.ReadLine();
                }
                if (s == "000")
                    break;
                if (s == "f")
                {
                    LBf f = new LBf();
                }
                if (s == "k")
                {
                    Lb lb = new Lb();
                }
                Console.WriteLine("----------------------------------------------------------------------------------");
            }
        }
    }
}
