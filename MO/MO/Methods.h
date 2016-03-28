#include <cmath>
#include <fstream>

using namespace std;

double Simplified_Newton(double StartValue, const double m1, const double M2, const double Eps, ofstream &fo, const int & variant);
double function1(double x);//���� ������� 1
double first_derivative1(double x);//����� ������� 1
double function2(double x);//���� ������� 2
double first_derivative2(double x);//����� ������� 2
double Relaxation(double StartValue, double tao, const double m1, const double M1, const double Eps, ofstream &fo, const int & variant);