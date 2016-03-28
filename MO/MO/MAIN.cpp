#include "Methods.h"
#define EPS 0.000001

int main ()
{
	double M2 = 26;
	double m1 = 44;
	
	double StartValue = -1.0;
	double root = 0;

	ofstream of("Output Data.txt");
	of.clear();
	of.precision(10);

	of<<"x^3 - 10*x^2 + 44*x +29 = 0\n";
	root = Simplified_Newton(StartValue, m1, M2, EPS, of, 1);
	of<<"Root - "<<root<<endl;
	
	double M1 = 67;
	double tao = 2/(m1 + M1);

	root = Relaxation(StartValue, tao, m1, M1, EPS, of, 1);
	of<<"Root - "<<root<<endl;
	///////////////////////////////////
	StartValue = 1.0;
	m1 = 3.0;
	M1 = 3.0 + sin(1.0);
	M2 = 1.0;
	tao = 2 / (m1 + M1);

	of<<"3*x - cos(x) - 1 = 0\n";
	root = Simplified_Newton(StartValue, m1, M2, EPS, of, 2);
	of<<"Root - "<<root<<endl;

	root = Relaxation(StartValue, tao, m1, M1, EPS, of, 2);
	of<<"Root - "<<root<<endl;

	of.close();
	system("pause");
	return 0;
}