#include "Non-linear.h"

double f(const double & x, const double & y)
{
	return (0.7*x - (1.0/3.0)*sin(y) - 2);
}

double g(const double & x, const double & y)
{
	return (1.1*x + 2*y - sin(x/5.0) + 1);
}

double f1x(const double & x, const double & y)
{
	return 0.7;
}

double f1y(const double & x, const double & y)
{
	return (-1.0/3.0)*cos(y);
}

double g1x(const double & x, const double & y)
{
	return (1.1 - (1.0/5.0)*cos(x/5.0));
}

double g1y(const double & x, const double & y)
{
	return 2.0;
}

void Newton(const double & startX, const double & startY,double & x_sol, double & y_sol, const double & eps, ostream & o)
{
	double oldX = 0.0;
	double oldY = 0.0;
	double newX = startX;
	double newY = startY;
	o<<"Start approximation: x0 = "<<startX<<"\ty0 = "<<startY<<endl;
	int numOfIter = 0;
	o.precision(10);
	do
	{
		oldX = newX;
		oldY = newY;
		newX = oldX - det(f(oldX,oldY), f1y(oldX,oldY), g(oldX, oldY), g1y(oldX, oldY))/
					  det(f1x(oldX,oldY), f1y(oldX,oldY), g1x(oldX, oldY), g1y(oldX, oldY));
		newY = oldY - det(f1x(oldX,oldY), f(oldX,oldY), g1x(oldX, oldY), g(oldX, oldY))/
					  det(f1x(oldX,oldY), f1y(oldX,oldY), g1x(oldX, oldY), g1y(oldX, oldY));
		++numOfIter;
		
		o<<"x"<<numOfIter<<" = "<<newX<<"\ty"<<numOfIter<<" = "<<newY<<endl;
	}
	while(max(fabs(newX - oldX), fabs(newY - oldY)) > eps);
	x_sol = newX;
	y_sol = newY;
	o<<"Number of iteration: "<<numOfIter<<endl;
	return;
}