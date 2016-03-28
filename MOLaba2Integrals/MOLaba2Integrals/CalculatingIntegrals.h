#include <cmath>
#include <stdio.h>

using namespace std;

/* Support class (Functor) for making opportunity create different functions of one type, which have one parameter of type double, and second - 
 * of type int.
 * For later transfer them as parameters in the function, and opportunity call them 
 */
class Function
{
	private:
		int _n;
		double (*f)(const double &, const int &);
	public:
		Function (double (*function)(const double &, const int &), const int & n)
		{
			_n = n;
			f = function;
		}
		double operator()(const double & x)
		{
			return (*f)(x, _n);
		}
		~Function()
		{
			f = NULL;
		}
};

double SimpsonFormula(Function func, double a, double b, int N);

//Trapezium formula for principle of Runge, where we fix h=(b - a)/N, i. e. an accuracy and M2 are not given
double Trapezium(Function func, double a, double b, int N);

/* Different objects of this class gives us opportunity to calculate integrals on each step in Runge's principle in different ways
 * for example by using Simpson and trapezium formulas
 */
class IntegralCalculator
{
	private:
		double (*Formula)(Function, double, double, int);
	public:
		IntegralCalculator(double (*function)(Function, double, double, int))
		{
			Formula = function;
		}
		double operator()(Function func, double a, double b, int N)
		{
			return (*Formula)(func, a, b, N);
		}
		~IntegralCalculator()
		{
			Formula = NULL;
		}
};

double RungePrinciple(Function func, double a, double b, double EPS, IntegralCalculator IntCalc);

double f(const double & x, const int & n);