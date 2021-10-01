using System;
using System.IO;

namespace FinalTry
{
    class CountBank
    {
        public CountBank(int balance)
        {
            Balance = balance;
        }
        public int Balance { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string path = Environment.CurrentDirectory + "\\file.txt";
            var splitData = ReadData(path);
            var account = new CountBank(int.Parse(splitData[0][0]));
        }
        static string[][] ReadData(string path)
        {
            string[] data = File.ReadAllLines(path);
            string[][] splitData = new string[data.Length][];
            for (var i = 0; i < data.Length; i++)
            {
                var line = data[i];
                string[] parts = line.Trim().Split("|");
                splitData[i] = parts;
            }

            return splitData;
        }
        static void UseData(string[][] data, CountBank balance)
        {
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    if (data[i][j] == "in")
                    {
                        balance.Balance += int.Parse(data[i][j - 1]);
                    }
                    else if (data[i][j] == "out")
                    {
                        if (balance.Balance >= int.Parse(data[i][j - 1]))
                        {
                            balance.Balance -= int.Parse(data[i][j - 1]);
                        }
                        else
                        {
                            throw new Exception("Ошибка! Недостаточно средств на счету!");
                        }
                    }
                    else if (data[i][j] == "revert")
                    {
                        throw new Exception(); //заглушка
                    }
                }
            }
        }
    }
}
