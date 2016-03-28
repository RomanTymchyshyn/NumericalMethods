#include "CalculatingIntegrals.h"

/* This function returns number of roots on intreval [a,b] we must take if we integrate the function on the interval (a,b)
 * with an accuracy EPS. M2 - maximum of second derivative of our function on interval [a,b].
 * Than step will be (b - a)/N, where N - is value our function returns.
 */
int CalcNumberOfRootsTrapezium(const double & a, const double & b, const double & EPS, const double & M2)
{
	double h = 0.0;
	h = sqrt(6*EPS/((b - a) * M2));
	int N = (int)((b - a)/h) + 1;
	return N;
}

/* This function returns value of function, which we are integrating, in the point x. This function is function from 1 task. 
 */
double f(double x)
{
	return (sin(x*x - 0.4) / (x + 2));
}

/* This function calculate integral of function func on interval [a,b] with an accuracy EPS by formula of trapezium.
 * M2 - maximum of second derivative of func.
 */
double TrapeziumFormula(Function func, double a, double b, double EPS, double M2)
{
	int N = CalcNumberOfRootsTrapezium(a, b, EPS, M2);
	double h = (b - a) / N;//step
	double result = h/2 * (func(a) + func(b));
	for (int i = 1; i < N; ++i)
	{
		result += h * func(a + i * h);
	}
	return result;
}

/* Trapezium formula for principle of Runge, where we fix h=(b - a)/N, i. e. an accuracy and M2 are not given
 */
double TrapeziumForRunge(Function func, double a, double b, int N)
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
 * On each step integal calculates by Simpson's formula.
 */
double RungePrinciple(Function func, double a, double b, double EPS, IntegralCalculator IntCalc, const int & type)
{
	double res_prev = IntCalc(func, a, b, 1);
	double res_next = IntCalc(func, a, b, 2);
	int N = 4;
	double k = 0.0;
	if (type == 1) k = 3.0;
	if (type == 2) k = 3.0;
	if (type == 3) k = 15.0;
	while (fabs(res_next - res_prev) / k >= EPS)
	{
		res_prev = res_next;
		res_next = IntCalc(func, a, b, N);
		N *= 2;
	}
	return res_next;
}

/* This function calculates improrer integral with singular point - left end.
 * For calculating integral we divide integral into two integrals: first - from a to a + delta, where we 
 * choose delta so that the accuracy of the calculations was EPS/2; second - integral from a + delta to b
 * we find by using principle of Runge and calculate this integral with an accuracy EPS/2.
 */
double ImproperIntegral(Function func, double a, double b, double delta, double EPS)
{
	IntegralCalculator Trapezium(&TrapeziumForRunge);
	double result = RungePrinciple(func, a + delta, b, EPS/2.0, Trapezium, 2);
	return result;
}

/* This function returns value of function, which we are integrating, in the point x. This function is function from 2 task. 
 */
double g(double x)
{
	return 1.0/((1.0 + x) * sqrt(x));
}