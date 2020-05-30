using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

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
        static int life = 0;

        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("|-------------------------------------*****-------------------------------------|");
            Console.WriteLine("|___________________________ Calculadora PPTO v0.1.0 ___________________________|");
            Console.WriteLine("|-------------------------------------*****-------------------------------------|");
            Console.WriteLine();
            Console.Write("Carregando");
            for (int i = 0; i < 7; i++) {
                Thread.Sleep(1000);
                Console.Write(".");
            }

            Console.ForegroundColor = System.ConsoleColor.Yellow;

            do {
                life = menuPrincipal();
            } while (life != 0);
        }

        static int menuPrincipal() {
            templatePrincipal();
            Console.WriteLine("Escolha a opção desejada, inserindo o número equivalente");
            Console.WriteLine("\n1. Converter"
                    + "\n2. Calcular"
                    + "\n3. Sair");
            int opcao = int.Parse(Console.ReadLine());
            if (opcao.Equals(1)) {
                int convertInt = menuConverter();
                return convertInt;
            } else if (opcao.Equals(2)) {
                int calcInt = menuCalcular();
                return calcInt;
            } else if (opcao.Equals(3)) {
                return 0;
            } else {
                templatePrincipal();
                Console.WriteLine("Insira um valor correto!");
                Thread.Sleep(2000);
                return 1;
            }
        }

        static void templatePrincipal() {
            Console.Clear();
            Console.WriteLine("------------------------------------//------------------------------------");
            Console.WriteLine("***************************** MENU PRINCIPAL *****************************");
            Console.WriteLine("------------------------------------//------------------------------------");
            Console.WriteLine();
        }

        static int menuConverter() {
            Console.Clear();
            templateConverte();
            Console.WriteLine("Escolha a base que será inserido o valor:");
            Console.WriteLine("\n1. Binário"
                    + "\n2. Octal"
                    + "\n3. Decimal"
                    + "\n4. Hexadecimal"
                    + "\n"
                    + "\n"
                    + "\n8. Voltar ao Menu Principal"
                    + "\n9. Sair");

            int optionOne = int.Parse(Console.ReadLine());
            if (optionOne.Equals(1) || optionOne.Equals(2) || optionOne.Equals(3) || optionOne.Equals(4)) {
                //faço nada, tá certo uai
            } else if (optionOne.Equals(8)) {
                return 1;
            } else if (optionOne.Equals(9)) {
                return 0;
            } else {
                Console.Clear();
                templateConverte();
                Console.WriteLine("Você inseriu um valor incorreto, será encaminhado para o Menu Principal,"
                + "\npara assim manter a integridade dos dados."
                + "\nLeia com atenção as opções mostradas e depois selecione!");
                Thread.Sleep(8000);
                return 1;
            }

            Console.Clear();
            templateConverte();
            Console.WriteLine("Insira o valor a ser convertido: ");
            string valueOne = Console.ReadLine();
            int convertToDecimal = 0;

            if (optionOne.Equals(1)) {
                convertToDecimal = ToDecimal(valueOne, TypeBase.Binary);
            } else if (optionOne.Equals(2)) {
                convertToDecimal = ToDecimal(valueOne, TypeBase.Octal);
            } else if (optionOne.Equals(3)) {
                convertToDecimal = int.Parse(valueOne);
            } else if (optionOne.Equals(4)) {
                convertToDecimal = ToDecimal(valueOne, TypeBase.Hexadecimal);
            }

            Console.Clear();
            templateConverte();
            Console.WriteLine("Escolha a base que o valor será convertido:");
            Console.WriteLine("\n1. Binário"
                    + "\n2. Octal"
                    + "\n3. Decimal"
                    + "\n4. Hexadecimal"
                    + "\n"
                    + "\n"
                    + "\n8. Voltar ao Menu Principal"
                    + "\n9. Sair");
            
            int optionTwo = int.Parse(Console.ReadLine());

            if (optionTwo.Equals(1) || optionTwo.Equals(2) || optionTwo.Equals(3) || optionTwo.Equals(4)) {
                //faço nada, tá certo uai
            } else if (optionOne.Equals(8)) {
                return 1;
            } else if (optionOne.Equals(9)) {
                return 0;
            } else {
                Console.Clear();
                templateConverte();
                Console.WriteLine("Você inseriu um valor incorreto, será encaminhado para o Menu Principal,"
                + "\npara assim manter a integridade dos dados."
                + "\nLeia com atenção as opções mostradas e depois selecione!");
                Thread.Sleep(8000);
                return 1;
            }

            String convertToBase = "";

            if (optionTwo.Equals(1)) {
                convertToBase = ToBase(convertToDecimal, TypeBase.Binary);
            } else if (optionTwo.Equals(2)) {
                convertToBase = ToBase(convertToDecimal, TypeBase.Octal);
            } else if (optionTwo.Equals(3)) {
                convertToBase = "" + convertToDecimal;
            } else if (optionTwo.Equals(4)) {
                convertToBase = ToBase(convertToDecimal, TypeBase.Hexadecimal);
            }

            Console.Clear();
            string format = convertToBase.Replace("\0", "");
            templateConverte();
            Console.WriteLine("Valor convertido: " + format);
            Thread.Sleep(4000);
            return 1;
        }

        static void templateConverte() {
            Console.WriteLine("------------------------------------//------------------------------------");
            Console.WriteLine("****************************** MENU CONVERTE *****************************");
            Console.WriteLine("------------------------------------//------------------------------------");
            Console.WriteLine();
        }

        static int menuCalcular() {
           Console.Clear();
           templateCalcula();
           Console.WriteLine("Escolha a base que representará o primeiro membro:");
           Console.WriteLine("\n1. Binário"
                    + "\n2. Octal"
                    + "\n3. Decimal"
                    + "\n4. Hexadecimal"
                    + "\n"
                    + "\n"
                    + "\n8. Voltar ao Menu Principal"
                    + "\n9. Sair");
                    
            int optionOne = int.Parse(Console.ReadLine());

            if (optionOne.Equals(1) || optionOne.Equals(2) || optionOne.Equals(3) || optionOne.Equals(4)) {
                //faço nada, tá certo uai
            } else if (optionOne.Equals(8)) {
                return 1;
            } else if (optionOne.Equals(9)) {
                return 0;
            } else {
                Console.Clear();
                templateCalcula();
                Console.WriteLine("Você inseriu um valor incorreto, será encaminhado para o Menu Principal,"
                + "\npara assim manter a integridade dos dados."
                + "\nLeia com atenção as opções mostradas e depois selecione!");
                Thread.Sleep(8000);
                return 1;
            }

            Console.Clear();
            templateCalcula();
            Console.WriteLine("Insira o valor do primeiro membro: ");
            string valueOne = Console.ReadLine();

            int convertToDecimalOne = 0;

            if (optionOne.Equals(1)) {
                convertToDecimalOne = ToDecimal(valueOne, TypeBase.Binary);
            } else if (optionOne.Equals(2)) {
                convertToDecimalOne = ToDecimal(valueOne, TypeBase.Octal);
            } else if (optionOne.Equals(3)) {
                convertToDecimalOne = int.Parse(valueOne);
            } else if (optionOne.Equals(4)) {
                convertToDecimalOne = ToDecimal(valueOne, TypeBase.Hexadecimal);
            }

            Console.Clear();
            templateCalcula();
            Console.WriteLine("Escolha o tipo de operação:");
            Console.WriteLine("\n1. Soma"
                    + "\n2. Subtração"
                    + "\n3. Multiplicação"
                    + "\n4. Divisão"
                    + "\n"
                    + "\n"
                    + "\n8. Voltar ao Menu Principal"
                    + "\n9. Sair");

            int optionTwo = int.Parse(Console.ReadLine());

            if (optionTwo.Equals(1) || optionTwo.Equals(2) || optionTwo.Equals(3) || optionTwo.Equals(4)) {
                //faço nada, tá certo uai
            } else if (optionOne.Equals(8)) {
                return 1;
            } else if (optionOne.Equals(9)) {
                return 0;
            } else {
                Console.Clear();
                templateCalcula();
                Console.WriteLine("Você inseriu um valor incorreto, será encaminhado para o Menu Principal,"
                + "\npara assim manter a integridade dos dados."
                + "\nLeia com atenção as opções mostradas e depois selecione!");
                Thread.Sleep(8000);
                return 1;
            }

            Console.Clear();
            templateCalcula();
            Console.WriteLine("Escolha a base que representará o segundo membro:");
            Console.WriteLine("\n1. Binário"
                    + "\n2. Octal"
                    + "\n3. Decimal"
                    + "\n4. Hexadecimal"
                    + "\n"
                    + "\n"
                    + "\n8. Voltar ao Menu Principal"
                    + "\n9. Sair");
                    
            int optionThree = int.Parse(Console.ReadLine());

            if (optionThree.Equals(1) || optionThree.Equals(2) || optionThree.Equals(3) || optionThree.Equals(4)) {
                //faço nada, tá certo uai
            } else if (optionOne.Equals(8)) {
                return 1;
            } else if (optionOne.Equals(9)) {
                return 0;
            } else {
                Console.Clear();
                templateCalcula();
                Console.WriteLine("Você inseriu um valor incorreto, será encaminhado para o Menu Principal,"
                + "\npara assim manter a integridade dos dados."
                + "\nLeia com atenção as opções mostradas e depois selecione!");
                Thread.Sleep(8000);
                return 1;
            }

            Console.Clear();
            templateCalcula();
            Console.WriteLine("Insira o valor do segundo membro: ");
            string valueTwo = Console.ReadLine();
            int convertToDecimalTwo = 0;

            if (optionThree.Equals(1)) {
                convertToDecimalTwo = ToDecimal(valueTwo, TypeBase.Binary);
            } else if (optionThree.Equals(2)) {
                convertToDecimalTwo = ToDecimal(valueTwo, TypeBase.Octal);
            } else if (optionThree.Equals(3)) {
                convertToDecimalTwo = int.Parse(valueTwo);
            } else if (optionThree.Equals(4)) {
                convertToDecimalTwo = ToDecimal(valueTwo, TypeBase.Hexadecimal);
            }

            int valueThree = 0;

            if (optionTwo.Equals(1)) {
                valueThree = soma(convertToDecimalOne, convertToDecimalTwo);
            } else if (optionTwo.Equals(2)) {
                valueThree = subtrai(convertToDecimalOne, convertToDecimalTwo);
            } else if (optionTwo.Equals(3)) {
                valueThree = multiplica(convertToDecimalOne, convertToDecimalTwo);
            } else if (optionTwo.Equals(4)) {
                valueThree = divide(convertToDecimalOne, convertToDecimalTwo);
            }

            Console.Clear();
            templateCalcula();
            Console.WriteLine("Escolha a base que será mostrado o resultado:");
            Console.WriteLine("\n1. Binário"
                    + "\n2. Octal"
                    + "\n3. Decimal"
                    + "\n4. Hexadecimal"
                    + "\n"
                    + "\n"
                    + "\n8. Voltar ao Menu Principal"
                    + "\n9. Sair");

            int optionFour = int.Parse(Console.ReadLine());

            if (optionFour.Equals(1) || optionFour.Equals(2) || optionFour.Equals(3) || optionFour.Equals(4)) {
                //faço nada, tá certo uai
            } else if (optionOne.Equals(8)) {
                return 1;
            } else if (optionOne.Equals(9)) {
                return 0;
            } else {
                Console.Clear();
                templateCalcula();
                Console.WriteLine("Você inseriu um valor incorreto, será encaminhado para o Menu Principal,"
                + "\npara assim manter a integridade dos dados."
                + "\nLeia com atenção as opções mostradas e depois selecione!");
                Thread.Sleep(8000);
                return 1;
            }

            String convertToBase = "";

            if (optionFour.Equals(1)) {
                convertToBase = ToBase(valueThree, TypeBase.Binary);
            } else if (optionFour.Equals(2)) {
                convertToBase = ToBase(valueThree, TypeBase.Octal);
            } else if (optionFour.Equals(3)) {
                convertToBase = "" + valueThree;
            } else if (optionFour.Equals(4)) {
                convertToBase = ToBase(valueThree, TypeBase.Hexadecimal);
            }

            Console.Clear();
            string format = convertToBase.Replace("\0", "");
            templateCalcula();
            Console.WriteLine("Resultado da operação: " + format);
            Thread.Sleep(4000);
            return 1;
        }

        static void templateCalcula() {
            Console.WriteLine("------------------------------------//------------------------------------");
            Console.WriteLine("****************************** MENU CALCULA ******************************");
            Console.WriteLine("------------------------------------//------------------------------------");
            Console.WriteLine();
        }

        static int soma(int n1, int n2) {
            int result = 0;
            result = n1 + n2;
            return result;
        }

        static int subtrai(int n1, int n2) {
            int result = 0;
            result = n1 - n2;
            return result;
        }

        static int multiplica(int n1, int n2) {
            int result = 0;
            result = n1 * n2;
            return result;
        }

        static int divide(int n1, int n2) {
            int result = 0;
            result = n1 / n2;
            return result;
        }

        static string ToBase(int value, TypeBase Base)
        {
            string d = "";
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