using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpolation_polynomials_in_the_form
{
    internal class TInterpolation_polynomials_Newtons
    {
        double[] Original_Vector_X()
        {
            double[] vector_X = { -2, -1, 0, 1 };
            return vector_X;
        }
        //-----------------------------------------------------------------------------------------
        double[] Function_X(double[] vector_X)
        {
            double[] function_X = new double[vector_X.Length];
            for (int i = 0; i < function_X.Length; i++)
            {
                function_X[i] = Math.Exp(vector_X[i]) + vector_X[i];
            }
            return function_X;
        }
        //-----------------------------------------------------------------------------------------
        double Function_X(double X)
        {
            double function_X = Math.Exp(X) + X;
            return function_X;
        }
        //-----------------------------------------------------------------------------------------
        double Function_W_for_X(double X, double[] vector_X)
        {
            double function_W = (X - vector_X[0]) * (X - vector_X[1]) * (X - vector_X[2]) * (X - vector_X[3]);
            return function_W;
        }
        //-----------------------------------------------------------------------------------------
        double[] Function_X_fisrt(double[] vector_X, double[] function_X)
        {
            double[] function_X_fisrt = new double[function_X.Length - 1];
            function_X_fisrt[0] = (function_X[1] - function_X[0]) / (vector_X[1] - vector_X[0]);
            function_X_fisrt[1] = (function_X[2] - function_X[1]) / (vector_X[2] - vector_X[1]);
            function_X_fisrt[2] = (function_X[3] - function_X[2]) / (vector_X[3] - vector_X[2]);
            return function_X_fisrt;
        }
        double[] Function_X_second(double[] vector_X, double[] function_X_first)
        {
            double[] function_X_second = new double[function_X_first.Length - 1];
            function_X_second[0] = (function_X_first[1] - function_X_first[0]) / (vector_X[2] - vector_X[0]);
            function_X_second[1] = (function_X_first[2] - function_X_first[1]) / (vector_X[3] - vector_X[1]);
            return function_X_second;
        }
        //-----------------------------------------------------------------------------------------
        double Function_X_third(double[] vector_X, double[] function_X_second)
        {
            double function_X_third = (function_X_second[1] - function_X_second[0]) / (vector_X[3] - vector_X[0]); ;
            return function_X_third;
        }
        double Function_L(double X, double[] vector_X, double[] function_X, double[] function_X_first , double[] function_X_second, double function_X_third)
        {
            double function_L = function_X[0] + (X - vector_X[0]) * function_X_first[0] + (X - vector_X[0]) * (X - vector_X[1]) * function_X_second[0]
                + (X - vector_X[0]) * (X - vector_X[1]) * (X - vector_X[2]) * function_X_third;
            return function_L;
        }
        void Error_rate(double X, double function_L, double[] vector_X)
        {
            var function_X = Function_X(X);
            var absolute_error = Math.Abs(function_L - function_X);
            var priori_error = ( 2.718 / 24 ) * Math.Abs(Function_W_for_X(X, vector_X));
            Console.WriteLine("absolute error = " + absolute_error);
            Console.WriteLine("priori error = " + priori_error);
        }
        void Method_Newton()
        {
            var X = -0.5;
            var vector_X = Original_Vector_X();
            var function_X = Function_X(vector_X);
            var function_X_first = Function_X_fisrt(vector_X, function_X);
            var function_X_second = Function_X_second(vector_X, function_X_first);
            var function_X_third = Function_X_third(vector_X, function_X_second);
            var function_L = Function_L(X, vector_X, function_X, function_X_first, function_X_second, function_X_third);
            Error_rate(X, function_L, vector_X);
        }
        //-----------------------------------------------------------------------------------------
        public void Start()
        {
            Method_Newton();
        }
    }
}
