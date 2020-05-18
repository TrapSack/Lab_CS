using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab7
{
    class Fraction : IComparable<Fraction>, IEquatable<Fraction>
    {
        private long numerator;
        private long denominator;

        public long Numerator => numerator;
        public long Denominator => denominator;

        private static long GCD(long a, long b)
        {
            if (b == 0)
            {
                return Math.Abs(a);
            }
            return GCD(b, a % b);
        }
        private static void Reduce(ref long a, ref long b)
        {
            long gcd = GCD(a, b);
            a /= gcd;
            b /= gcd;
        }
        private void Reduce()
        {
            Reduce(ref numerator, ref denominator);
        }

        public Fraction(long n, long m)
        {
            if (m == 0)
            {
                throw new DivideByZeroException();
            }
            Reduce(ref n, ref m);
            if (m < 0)
            {
                n = -n;
                m = -m;
            }
            numerator = n;
            denominator = m;
        }
        public Fraction(long n) : this(n, 1) { }
        public Fraction() : this(0) { }
        public Fraction(Fraction a) : this(a.Numerator, a.Denominator) { }

        private int Compare(Fraction other)
        {
            long a, b;
            checked
            {
                a = Numerator * other.Denominator;
                b = other.Numerator * Denominator;
            }
            return a.CompareTo(b);
        }

        int IComparable<Fraction>.CompareTo(Fraction other)
        {
            return this.Compare(other);
        }
        bool IEquatable<Fraction>.Equals(Fraction other)
        {
            return this.Compare(other) == 0;
        }
        public override bool Equals(object obj)
        {
            return obj is Fraction fraction &&
                   this.Compare(fraction) == 0;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Numerator / Denominator);
        }

        public override string ToString()
        {
            return this.ToString(null);
        }
        public string ToString(string format)
        {
            if (String.IsNullOrEmpty(format))
            {
                format = "standart";
            }
            format = format.Trim().ToLowerInvariant();
            switch (format)
            {
                case "standart":
                    return Numerator.ToString() + '/' + Denominator.ToString();
                case "float":
                    return ((decimal)this).ToString();
                case "integer":
                    return ((long)this).ToString();
                case "binary":
                    {
                        long n = Numerator, m = Denominator;
                        StringBuilder ans = new StringBuilder();
                        if (n < 0)
                        {
                            ans.Append('-');
                            n = -n;
                        }
                        ans.Append(Convert.ToString(n / m, 2));
                        n %= m;
                        if (n > 0)
                        {
                            ans.Append('.');
                            while (n > 0 && ans.Length < 42)
                            {
                                try
                                {
                                    checked
                                    {
                                        n *= 2;
                                    }
                                }
                                catch
                                {
                                    break;
                                }
                                if (n >= m)
                                {
                                    ans.Append('1');
                                    n -= m;
                                }
                                else
                                {
                                    ans.Append('0');
                                }
                            }
                        }
                        return ans.ToString();
                    }
                default:
                    throw new FormatException(String.Format("The '{0}' format string is not supported.", format));
            }
        }
        public static Fraction Parse(string s)
        {
            Regex regex;
            MatchCollection match;

            regex = new Regex(@"-?\d+\.\d+");
            match = regex.Matches(s);
            if (match.Count == 1)
            {
                try
                {
                    return decimal.
                        Parse(match[0].Value,
                        new System.Globalization.
                        NumberFormatInfo {
                        NumberDecimalSeparator = "." });
                }
                catch { }
            }

            regex = new Regex(@"-?\d+\,\d+");
            match = regex.Matches(s);
            if (match.Count == 1)
            {
                try
                {
                    return decimal.
                        Parse(match[0].Value,
                        new System.Globalization.
                        NumberFormatInfo {
                        NumberDecimalSeparator = "," });
                }
                catch { }
            }

            regex = new Regex(@"-?\d+");
            match = regex.Matches(s);
            if (match.Count == 2)
            {
                try
                {
                    return new Fraction(
                        long.Parse(match[0].Value), 
                        long.Parse(match[1].Value));
                }
                catch { }
            }

            if (match.Count == 1)
            {
                try
                {
                    return new Fraction(
                        long.Parse(match[0].Value));
                }
                catch { }
            }

            throw new ArgumentException();
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            long n, m;
            checked
            {
                n = a.Numerator * b.Denominator + a.Denominator * b.Numerator;
                m = a.Denominator * b.Denominator;
            }
            return new Fraction(n, m);
        }
        public static Fraction operator -(Fraction a, Fraction b)
        {
            long n, m;
            checked
            {
                n = a.Numerator * b.Denominator - a.Denominator * b.Numerator;
                m = a.Denominator * b.Denominator;
            }
            return new Fraction(n, m);
        }
        public static Fraction operator *(Fraction a, Fraction b)
        {
            long n, m;
            checked
            {
                n = a.Numerator * b.Numerator;
                m = a.Denominator * b.Denominator;
            }
            return new Fraction(n, m);
        }
        public static Fraction operator /(Fraction a, Fraction b)
        {
            long n, m;
            checked
            {
                n = a.Numerator * b.Denominator;
                m = a.Denominator * b.Numerator;
            }
            return new Fraction(n, m);
        }

        public static bool operator <(Fraction a, Fraction b)
        {
            return a.Compare(b) == -1;
        }
        public static bool operator >(Fraction a, Fraction b)
        {
            return a.Compare(b) == 1;
        }
        public static bool operator ==(Fraction a, Fraction b)
        {
            return a.Compare(b) == 0;
        }
        public static bool operator !=(Fraction a, Fraction b)
        {
            return a.Compare(b) != 0;
        }
        public static bool operator <=(Fraction a, Fraction b)
        {
            return a.Compare(b) != 1;
        }
        public static bool operator >=(Fraction a, Fraction b)
        {
            return a.Compare(b) != -1;
        }
        public static Fraction operator ++(Fraction a)
        {
            return a + 1;
        }
        public static Fraction operator --(Fraction a)
        {
            return a - 1;
        }
        public static bool operator true(Fraction a)
        {
            return a.Numerator != 0;
        }
        public static bool operator false(Fraction a)
        {
            return a.Numerator == 0;
        }
        public static Fraction operator -(Fraction a)
        {
            return new Fraction(-a.Numerator, a.Denominator);
        }
        public static Fraction operator +(Fraction a)
        {
            return new Fraction(Math.Abs(a.Numerator), a.Denominator);
        }

        public static implicit operator Fraction(long a)
        {
            return new Fraction(a);
        }
        public static implicit operator Fraction(decimal a)
        {
            long num, den = 1;
            checked
            {
                num = (long)Math.Truncate(a);
            }
            a -= Math.Truncate(a);
            while (a != 0)
            {
                try
                {
                    checked
                    {
                        a *= 10;
                        long tmpnum = num * 10 + (long)a;
                        long tmpden = den * 10;
                        num = tmpnum;
                        den = tmpden;
                        a -= Math.Truncate(a);
                    }
                }
                catch
                {
                    break;
                }
            }
            return new Fraction(num, den);
        }
        public static explicit operator long(Fraction a)
        {
            checked
            {
                long ans = a.Numerator / a.Denominator;
                if ((Math.Abs(a.Numerator) % a.Denominator) * 2 >= a.Denominator)
                {
                    ans += a.Numerator / Math.Abs(a.Numerator);
                }
                return ans;
            }
        }
        public static explicit operator double(Fraction a)
        {
            return ((double)a.Numerator) / a.Denominator;
        }
        public static explicit operator decimal(Fraction a)
        {
            return ((decimal)a.Numerator) / a.Denominator;
        }
    }
}
