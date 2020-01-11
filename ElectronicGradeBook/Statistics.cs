using System;

namespace ElectronicGradeBook
{
    public class Statistics
    {
        public double High;
        public double Low;
        public int Count;
        public double Sum;
        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }
        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 90.0:
                        return 'A';
                    case var d when d >= 80.0:
                        return 'B';
                    case var d when d >= 70.0:
                        return 'C';
                    case var d when d >= 60.0:
                        return 'D';
                    default:
                        return 'F';
                }
            }
        }
        public Statistics()
        {
            Count = 0;
            Sum = 0.0;
            Low = double.MaxValue;
            High = double.MinValue;
        }
        public void Add(double grade)
        {
            Low = Math.Min(Low, grade);
            High = Math.Max(High, grade);
            Count += 1;
            Sum += grade;
        }
    }
}