using System;
using Entidades;
namespace Vista
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Operando operador = new Operando(5);
            Operando operando2 = new Operando(2);
            //Console.WriteLine(operador.BinarioDecimal("10110"));
            //Console.WriteLine(operador.DecimalBinario(13));
            //Console.WriteLine(operador.DecimalBinario("asd"));
            //operando2.Numero = "20";
            //Console.WriteLine(operador+operando2);
            double resultado = Calculadora.Operar(operador, operando2,'-');
            Console.WriteLine(resultado);
        }
    }
}
