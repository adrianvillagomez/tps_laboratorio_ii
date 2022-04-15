using System;

namespace Entidades
{
    public static class Calculadora
    {
         private static char ValidarOperador(char operador)
        {          
            if (operador == '+' || operador == '-' || operador == '*' || operador == '/')
            {
                return operador;
            }
            else
            {
                return '+';
            }
        }
        public static double Operar(Operando num1,Operando num2,Char operador)
        {
            double resultadoOperaciones = 0;
            char operandoValidado=ValidarOperador(operador);
            switch (operandoValidado)
            {
                case '+':
                    return num1 + num2;
                case '-':
                    return num1 - num2;
                case '*':
                    return num1 * num2;                   
                case'/':
                    return num1 / num2;
            }
            return resultadoOperaciones;
        }
        
    }

}
