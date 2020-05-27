using System;
using System.Linq.Expressions;

namespace Calculator
{
    public enum TypeBase
    {
        Binary = 2,
        Octal = 8,
        Decimal = 10,
        Hexadecimal = 16
    };
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine(ToBase(1034534, TypeBase.Hexadecimal));
            System.Console.WriteLine(ToBase(51489, TypeBase.Binary));
            System.Console.WriteLine(ToBase(8974562, TypeBase.Octal));
            System.Console.WriteLine(ToDecimal("10101", TypeBase.Hexadecimal));
            System.Console.WriteLine(ToDecimal("258", TypeBase.Octal));
            System.Console.WriteLine(ToDecimal("5520", TypeBase.Binary));
        }

        static string ToBase(int value, TypeBase Base)
        {
            string d = " ";
            if (Base == TypeBase.Binary || Base == TypeBase.Octal || Base == TypeBase.Hexadecimal)
            {
                char[] caracteres = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
                char[] c = new char[300];
                int p = 0;

                while (value > 0)
                {
                    c[p] = caracteres[value % (int)Base];
                    value /= (int)Base;
                    p++;
                }
                for (int i = c.Length - 1; i >= 0; i--)
                {
                    d += c[i];
                }
            }
            return d;
        }

        static int ToDecimal(string valueBase, TypeBase sourceBase)
        {
            int result = 0;
            int size = valueBase.Length;
            int exponent = 0;
            int hlp;

            for (int i = size - 1; i >= 0; i--)
            {
                hlp = ConversionCaractere(valueBase[i]);

                if ((hlp > (int)sourceBase - 1) || (hlp < 0))
                {
                    return -1;
                }
                result += hlp * (int)Math.Pow((int)sourceBase, exponent++);
            }
           return result;
        }
        static int ConversionCaractere(char Caractere)
                {
                    int char_num = 0;

                    switch (Caractere)
                    {
                        case 'A':
                            char_num = 10;
                            break;

                        case 'B':
                            char_num = 11;
                            break;

                        case 'C':
                            char_num = 12;
                            break;

                        case 'D':
                            char_num = 13;
                            break;

                        case 'E':
                            char_num = 14;
                            break;

                        case 'F':
                            char_num = 15;
                            break;

                        default:
                            char_num = (int)Caractere - (int)'0';
                            break;
                    }

                    return char_num;
                }
            }
        }