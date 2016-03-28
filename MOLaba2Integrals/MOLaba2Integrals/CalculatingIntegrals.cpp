#include "CalculatingIntegrals.h"
#include <limits>

/* This function returns value of function, which we are integrating, in the point x. This function is function from 1 task. 
 */
double f(const double & x, const int & n)
{
	if (x <= std::numeric_limits<double>::epsilon()) return 0.0;//function is not defined in point 0.0, because we change it's value at this point on it's limit
	return exp(-1.0/x)/pow(x, n + 2.0);
}

/* This function calculate integral of function func on interval [a,b] by formula of trapeziums with a given number of roots.
 * step = (b - a) / N, where N - number of roots on interval [a,b].
 */
double Trapezium(Function func, double a, double b, int N)
{
	double h = (b - a) / N;//step
	double result = h/2 * (func(a) + func(b));
	for (int i = 1; i < N; ++i)
	{
		result += h * func(a + i * h);
	}
	return result;
}

/* This function calculate integral of function func on interval [a,b] by formula of Simpson with a given number of roots.
 * step = (b - a) / N, where N - number of roots on interval [a,b].
 */
double SimpsonFormula(Function func, double a, double b, int N)
{
	double h = (b - a) / N;
	double result = 0;
	for (int i = 1; i <= N; ++i)
	{
		result += (func(a + (i - 1) * h) + 4 * func(a + (i - 0.5) * h) + func(a + i * h)) * h / 6;
	}
	return result;
}

/* This function calculates integral of function func on interval [a,b] with an accuracy EPS by using Runge principle.
 * On each step integal calculates by InegralCalculator.
 */
double RungePrinciple(Function func, double a, double b, double EPS, IntegralCalculator IntCalc)
{
	int k = 4;
	double pow_k = 15.0;
	double n = (b - a) / pow(EPS, 1.0/k);
	int N = (n < 1 ? 1 : n);
	double res_prev = 0.0;
	double res_next = IntCalc(func, a, b, N);
	do
	{
		res_prev = res_next;
		N *= 2;
		res_next = IntCalc(func, a, b, N);
	}
	while (fabs(res_next - res_prev) / pow_k >= EPS);
	return res_next;
}