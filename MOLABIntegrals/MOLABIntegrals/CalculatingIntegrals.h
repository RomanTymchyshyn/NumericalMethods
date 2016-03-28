#include <cmath>
#include <stdio.h>

using namespace std;

/* Support class (Functor) for making opportunity create different functions of one type, which have one parameter of type double,
 * for later transfer them as parameters in the function
 */
class Function
{
	private:
		double (*f)(double);
	public:
		Function (double (*function)(double))
		{
			f = function;
		}
		double operator()(double x)
		{
			return (*f)(x);
		}
		~Function()
		{
			f = NULL;
		}
};

double TrapeziumFormula(Function func, double a, double b, double EPS, double M2);

double SimpsonFormula(Function func, double a, double b, int N);

//Trapezium formula for principle of Runge, where we fix h=(b - a)/N, i. e. an accuracy and M2 are not given
double TrapeziumForRunge(Function func, double a, double b, int N);

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

double RungePrinciple(Function func, double a, double b, double EPS, IntegralCalculator IntCalc, const int & type);

double ImproperIntegral(Function func, double a, double b, double delta, double EPS);

//function from 1 task
double f(double x);

//function from 2 task
double g(double x);