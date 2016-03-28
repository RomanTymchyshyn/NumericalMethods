#include <iostream>
#include "CalculatingIntegrals.h"

using namespace std;

int main()
{
	int n = 0;
	double eps = 0.0;
	IntegralCalculator Simpson(&SimpsonFormula);
	cout<<"n = ";
	// For exit press Ctrl + Z and then enter
	while(cin>>n)
	{
		cout<<"eps = ";
		if (!(cin>>eps))
		{
			system("pause");
			return 0;
		}
		Function func(&f,n);
		double A = pow(2.0 / (eps * (n + 1)), 1.0 / (n + 1.0));
		double Integral = RungePrinciple(func, 0.0, A, eps/2.0, Simpson);
		cout.precision(15);
		cout<<"Answer >>>>  "<<Integral<<endl;
		cout<<"Enter n or press Ctrl + z and key enter"<<endl;
	}
	system("pause");
	return 0;
}