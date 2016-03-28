#include <fstream>
#include "CalculatingIntegrals.h"
#define eps 1e-4

using namespace std;

int main()
{
	ofstream fo("Output.txt");
	fo.precision(10);
	Function func1(&f);//function from task 1
	Function func2(&g);//function from task 2
	//creating object which corresponds way we will calculate integrals in principle of Runge in first task
	IntegralCalculator Simpson(&SimpsonFormula);
	//calculating integrals from first task
	double M2 = 1.42059;
	double a = 0.8;
	double b = 1.2;
	double Integral1_Trapezium = TrapeziumFormula(func1, a, b, eps, M2);//Exact value: 0.0738412
	double Integral1_Simpson = RungePrinciple(func1, 0.8, 1.2, eps, Simpson, 3);//Exact value: 0.0738412
	//calculating integrals from second task
	double delta = tan(eps/4)*tan(eps/4);
	a = 0;
	b = 1;
	double Integral2 = ImproperIntegral(func2, a, b, delta, eps);//Exact value: 1.570796326...
	//print results to file
	fo<<"First task:\nTrapezium formula:\n"<<Integral1_Trapezium<<endl;
	fo<<"Simpson's formula:\n"<<Integral1_Simpson<<endl;
	fo<<"Second task:\n"<<Integral2<<endl;
	fo.close();
	return 0;
}