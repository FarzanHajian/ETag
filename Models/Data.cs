using System;
using System.Timers;
using System.Collections.Generic;

namespace ETag.Models
{
    public partial class Data
    {
        public int Id { get; set; }
        public int Value1 { get; set; }
        public DateTime Value2 { get; set; }
        public List<Guid> Tokens { get; set; } = new List<Guid>();
    }

    partial class Data
    {
        private static Data data = new Data();
        private static Timer timer;
        static Data()
        {
            timer = new Timer();
            timer.Elapsed += (sender, e) => LoadData();

            LoadData();
        }
        public static Data GetData()
        {
            return data;
        }

        private static void LoadData()
        {
            timer.Stop();

            Random rnd = new Random(DateTime.Now.Millisecond);
            data.Id = rnd.Next();
            data.Value1 = rnd.Next();
            data.Value2 = DateTime.Now;

            data.Tokens.Clear();
            for (int i = 0; i < 50; i++)
                data.Tokens.Add(Guid.NewGuid());

            timer.Interval = rnd.Next(5000, 10000);
            timer.Start();
        }
    }
}