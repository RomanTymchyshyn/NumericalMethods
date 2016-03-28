#include "Methods.h"

double Simplified_Newton(double StartValue, const double m1, const double M2, const double Eps, ofstream &fo, const int & variant)
{
	double Beta = M2/(2*m1);
	double Alpha = Eps*2;//альфа - права частина умови виходу з циклу, задаємо її такою, щоб хоча б раз попасти в цикл
	double old_value = StartValue;
	double new_value = old_value + Eps * 2;
	double start_first_derivative = 0.0;
	if (variant == 1) start_first_derivative = first_derivative1(StartValue);
	if (variant == 2) start_first_derivative = first_derivative2(StartValue);
	int number_of_iterations = 0;
	double func_last = 0.0;

	if (variant == 1) func_last = function1(StartValue);
	if (variant == 2) func_last = function2(StartValue);

	fo<<"//////=  Modified Newton Method  =//////"<<endl;

	fo.width(20);
	fo<<"argument";
	fo.fill(' ');

	fo.width(20);
	fo<<"function";
	fo.fill(' ');
	fo<<endl;

	fo<<number_of_iterations;

	fo.width(20);
	fo<<StartValue;
	fo.fill(' ');

	fo.width(20);
	if (variant == 1) fo<<function1(StartValue);
	if (variant == 2) fo<<function2(StartValue);
	fo.fill(' ');

	fo<<endl;

	for ( ; fabs(new_value - old_value) > Eps || fabs(func_last) > Eps; ++number_of_iterations)
	{
		new_value = old_value - (func_last/start_first_derivative);
		
		fo<<number_of_iterations + 1;

		fo.width(20);
		fo<<new_value;
		fo.fill(' ');

		fo.width(20);
		if (variant == 1) fo<<function1(new_value);
		if (variant == 2) fo<<function2(new_value);
		fo.fill(' ');

		fo<<endl;

		old_value = new_value;
		if (variant == 1) func_last = function1(old_value);
		if (variant == 2) func_last = function2(old_value);
	}
	fo<<"Number of iterations - "<<number_of_iterations<<endl;
	return old_value;
}

double function1(double x)
{
	return x * x * x - 10 * x * x + 44 * x + 29;
}

double function2(double x)
{
	return 3 * x - cos(x) - 1;
}

double first_derivative1(double x)
{
	return 3 * x * x - 20 * x + 44;
}

double first_derivative2(double x)
{
	return 3 + sin(x);
}

double Relaxation(double StartValue, double tao, const double m1, const double M1, const double Eps, ofstream &fo, const int & variant)
{
	int sign_of_tao = 0;
	double first_der = 0.0;
	if (variant == 1) first_der = first_derivative1(StartValue);
	if (variant == 2) first_der = first_derivative2(StartValue);
	if (first_der > 0) sign_of_tao = -1;
	else sign_of_tao = 1;

	double old_value = StartValue;
	double new_value = old_value + Eps * 2;
	double Alpha = new_value - old_value;
	int number_of_iterations = 0;
	tao *= sign_of_tao;

	fo<<"//////=  Relaxation Method  =//////"<<endl;

	fo.width(20);
	fo<<"argument";
	fo.fill(' ');

	fo.width(20);
	fo<<"function";
	fo.fill(' ');
	fo<<endl;

	fo<<number_of_iterations;

	fo.width(20);
	fo<<StartValue;
	fo.fill(' ');

	fo.width(20);
	if (variant == 1) fo<<function1(StartValue);
	if (variant == 2) fo<<function2(StartValue);
	fo.fill(' ');

	fo<<endl;

	double func = 0.0;
	if (variant == 1) func = function1(new_value);
	if (variant == 2) func = function2(new_value);

	for ( ; fabs(func) > Eps || fabs(new_value - old_value) > Eps; ++number_of_iterations)
	{
		if (variant == 1) new_value = old_value + tao * function1(old_value);
		if (variant == 2) new_value = old_value + tao * function2(old_value);

		fo<<number_of_iterations + 1;

		fo.width(20);
		fo<<new_value;
		fo.fill(' ');

		fo.width(20);
		if (variant == 1) fo<<function1(new_value);
		if (variant == 2) fo<<function2(new_value);
		fo.fill(' ');

		fo<<endl;
		old_value = new_value;
		if (variant == 1) func = function1(new_value);
		if (variant == 2) func = function2(new_value);
	}
	fo<<"Number of iterations - "<<number_of_iterations<<endl;
	return old_value;
}