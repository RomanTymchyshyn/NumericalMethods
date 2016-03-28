#pragma once
#include <cmath>
#include <fstream>
#include <vector>

using namespace std;

template<class T>
T det(T a11, T a12, T a21, T a22)
{
	return a11*a22 - a12*a21;
}

double f(const double & x, const double & y);
double g(const double & x, const double & y);
double f1x(const double & x, const double & y);
double f1y(const double & x, const double & y);
double g1x(const double & x, const double & y);
double g1y(const double & x, const double & y);

void Newton(const double & startX, const double & startY,double & x_sol, double & y_sol, const double & eps, ostream & o);