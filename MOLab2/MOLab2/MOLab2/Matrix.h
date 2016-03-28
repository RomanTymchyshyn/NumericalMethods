#ifndef Matrix____
#define Matrix____

#pragma once
#include <iostream>
#include <fstream>
#include <vector>

using namespace std;

template<class T>
class Matrix//клас квадратних матриць
{
	vector<vector<T>> matrix;
	T* determinant;
public:
	Matrix<T>();
	Matrix<T>(int _size, T val=(T)0);
	int size() const { return (int) matrix.size(); }// розмір матриці
	T Det() const { if (determinant != NULL) return (*determinant); else return (T)-1111111111; };
	template<class T>
	friend Matrix<T> unitMatr(int _size);//повертає одиничну матрицю відповідного розміру
	template<class T>
	friend bool operator>>(istream &i, Matrix<T> &a);//зчитування матриці з файлу
	template<class T>
	friend bool operator<<(ostream &o, Matrix<T> a);//вивід матриці у файл чи на екран
	Matrix<T> operator=(Matrix<T> a);
	Matrix<T> operator+(Matrix<T> a);
	Matrix<T> operator-(Matrix<T> a);
	Matrix<T> operator*(int a);
	vector<T> operator*(vector<T> a);//множення на вектор-стовпчик
	Matrix<T> operator*(Matrix<T> a);
	vector<T>& operator[](int i);
	Matrix<T> transpose();//транспонування
	vector<T> Gauss(vector<T> a, Matrix<T> & inverse, ostream & o);
	vector<T> SqRoots(vector<T> b, Matrix<T> & Inv, ostream & o);
	vector<T> Matrix<T>::SimpleIteration(vector<T> f, const T & Eps, ostream & o);
	double Norm();
};

//ввід-вивід матриць
template <class T>
bool operator>>(istream &i, Matrix<T> &a)
{
	vector<T> temp;
	T t;
	while(i>>t) temp.push_back(t);
	int size=(int)temp.size();
	size=(int)sqrt((double)size);
	vector<T> y(0);
	int k=0;
	for (int i=0; i<size; ++i)
	{
		a.matrix.push_back(y);
		for (int j=0; j<size; ++j)
			a.matrix[i].push_back(temp[k++]);
	}
	return true;
}

template<class T>
bool operator<<(ostream &o, Matrix<T> a)
{
	if (a.size()==0) return false;
	for (int i=0; i<a.size(); ++i)
	{
		for (int j=0; j<a.size(); ++j)
		{
			o.width(20);
			if (!(o<<a.matrix[i][j]) || !(o<<' ')) return false;
		}
		if(!(o<<endl)) return false;
	}
	return true;
}

//ввід-вивід векторів
template<class T>
bool operator>>(istream & i, vector<T> & a)
{
	a.clear();
	T temp;
	while(i>>temp) a.push_back(temp);
	return true;
}

template<class T>
bool operator<<(ostream & o, vector<T> a)
{
	for(int i=0; i<a.size(); ++i)
	{
		o<<a[i];
		o<<' ';
	}
	return true;
}

//деякі допоміжні операції для векторів
template<class T>
vector<T> operator*(vector<T> a, T b)
{
	for (int i=0; i<(int)a.size(); ++i)
		a[i]=a[i]*b;
	return a;
}

template<class T>
vector<T> operator+(vector<T> a, vector<T> b)
{
	vector<T> result;
	if (a.size()!=b.size()) return result;
	for (int i=0; i<(int)a.size(); ++i)
		result.push_back(a[i]+b[i]);
	return result;
}

template<class T>
vector<T> operator-(vector<T> a, vector<T> b)
{
	vector<T> result;
	if (a.size()!=b.size()) return result;
	for (int i=0; i<(int)a.size(); ++i)
		result.push_back(a[i]-b[i]);
	return result;
}

template<class T>
T operator*(vector<T>a, vector<T> b)
{
	T result(0);
	if (a.size()!=b.size() || a.size()==0) return result;
	for (int i=0; i<(int)a.size(); ++i)
		result=result+a[i]*b[i];
	return result;
}

template<class T>
T NormVect(vector<T> v)
{
	T max = (T)0;
	for (int i = 0 ; i < v.size(); ++i)
		if (fabs(v[i]) > max) max = fabs(v[i]);
	return max;
}

//матриці основні методи
template<class T>
Matrix<T>::Matrix<T>()
{
	determinant = NULL;
	matrix.clear();
}

template<class T>
Matrix<T>::Matrix<T>(int _size, T val)
{
	determinant = NULL;
	if (_size==0) matrix.clear();
	vector <T> y(0);
	for (int i=0; i<_size; ++i)
	{
		matrix.push_back(y);
		for (int j=0; j<_size; ++j)
			matrix[i].push_back(val);
	}
	determinant = NULL;
}

template<class T>
Matrix<T> Matrix<T>::operator=(Matrix<T> b)
{
	if (b.determinant != NULL) determinant = new T(*b.determinant);
	if (b.size()==0) return Matrix<T>();
	matrix=b.matrix;
	return (*this);
}

template<class T>
Matrix<T> unitMatr(int _size)
{
	Matrix<T> E;
	if (_size==0) E.matrix.clear();
	vector <T> y(0);
	for (int i=0; i<_size; ++i)
	{
		E.matrix.push_back(y);
		for (int j=0; j<_size; ++j)
			if (i==j) E.matrix[i].push_back((T)1);
			else E.matrix[i].push_back((T)0);
	}
	E.determinant = new T(1);
	return E;
}

template<class T>
Matrix<T> Matrix<T>::operator+(Matrix<T> a)
{
	if(size()==0) return a;
	if(a.size()==0) return (*this);
	if(size()!=a.size()) return Matrix<T>();
	Matrix<T> result(size());
	for(int i=0; i<size(); ++i)
		for(int j=0; j<size(); ++j)
			result.matrix[i][j]=matrix[i][j]+a.matrix[i][j];
	return result;
}

template<class T>
Matrix<T> Matrix<T>::operator-(Matrix<T> a)
{
	if(size()==0) return a*(-1);
	if(a.size()==0) return (*this);
	Matrix<T> result(size());
	for(int i=0; i<size(); ++i)
		for(int j=0; j<size(); ++j)
			result.matrix[i][j]=matrix[i][j]-a.matrix[i][j];
	return result;
}

template<class T>
Matrix<T> Matrix<T>::operator*(int a)
{
	if (a==0) return Matrix<T>(size());
	Matrix<T> result(size());
	for(int i=0; i<size(); ++i)
		for(int j=0; j<size(); ++j)
			result.matrix[i][j]=matrix[i][j]*a;
	if (determinant != NULL) (*determinant) *= a;
	return result;
}

//множення на вектор стовпчик справа
template<class T>
vector<T> Matrix<T>::operator*(vector<T> a)
{
	
	if (a.size()==0) return vector <T> ();
	if (size()==0||size()!=int(a.size())) return vector<T> ();
	vector<T> result (size(),(T)0);
	for (int i=0; i<size(); ++i)
	{
		T temp=0;
		for (int j=0; j<size(); ++j)
		{
			temp=matrix[i][j]*a[j];
			result[i]=result[i]+temp;
			temp=(T)0;
		}
	}
	return result;
}

//звичайне множення
template<class T>
Matrix<T> Matrix<T>::operator*(Matrix<T> a)
{
	int n=size();
	if (a.size()==0) return Matrix<T> ();
	if (n==0||n!=int(a.size())) return Matrix<T> ();
	Matrix<T> b;
	b=(*this);
	Matrix<T> result(n);
	for (int i=0; i<n; ++i)
	{
		T temp=0;
		for (int j=0, k=0; k<n; ++j)
		{
			if (j==n){j=0;++k;}
			if (k==n) break;
			temp=b.matrix[i][j]*a.matrix[j][k];
			result.matrix[i][k]=result.matrix[i][k]+temp;
			temp=(T)0;
		}
		temp=(T)0;
	}
	if (determinant != NULL && a.determinant != NULL) (*determinant) *= (*a.determinant);
	return result;
}

template<class T>
vector<T>& Matrix<T>::operator[](int i)
{
	return matrix[i];
}

template<class T>
Matrix<T> Matrix<T>::transpose()
{
	if (size()==0) return Matrix<T> ();
	if (size()==1) return (*this);
	Matrix<T> result(size());
	for (int i=0; i<size(); ++i)
		for (int j=0; j<size(); ++j)
			result.matrix[i][j]=(*this)[j][i];
	return result;
}

template<class T>
double Matrix<T>::Norm()
{
	double norm = 0.0;
	double temp = 0.0;
	for (int i = 0; i < matrix.size(); ++i)
	{
		temp = 0.0;
		for (int j = 0; j < matrix.size(); ++j)
		{
			temp += fabs(matrix[i][j]);
		}
		if (temp > norm)
			norm = temp;
	}
	return norm;
}

template<class T>
vector<T> Matrix<T>::Gauss(vector<T> a, Matrix<T> & inverse, ostream & o)
{
	o.precision(10);
	determinant = new T(1);
	if (size()!=a.size() || a.size()==0) return vector<T> ();
	Matrix<T> matr=(*this);
	inverse = unitMatr<T>(matr.size());
	int n = size();
	for (int i=0; i<size(); ++i)
		matr[i].push_back(a[i]);
	for (int col=0; col<n; ++col)
	{
		int row=0;
		for (row=col; row<n && matr[row][col]==(T)0; ++row);
		if (row==n) return vector<T> ();
		swap(matr.matrix[row],matr.matrix[col]);
		swap(inverse.matrix[row],inverse.matrix[col]);

		T x=matr[col][col];
		(*determinant) *= x;
		for (int j=0; j<n+1; ++j)
		{
			matr[col][j]=matr[col][j]/x;
			if (j != n) inverse[col][j] = inverse[col][j]/x;
		}

		vector<T> temp_x;
		vector<T> temp_y;
		for (int i=col; i<n; ++i)
		{
			if (i!=col)
			{
				temp_x=matr[col];
				temp_y=inverse[col];
				x=matr[i][col];
				for (int k=0; k<n+1; ++k)
				{
					temp_x[k]=temp_x[k]*x;
					matr[i][k]=matr[i][k]-temp_x[k];
					if (k != n)
					{
						temp_y[k]=temp_y[k]*x;
						inverse[i][k]=inverse[i][k]-temp_y[k];
					}
				}
			}
		}
	}

	o<<endl<<"Triangular matrix:\n";
	for (int i = 0; i < n; ++i)
	{
		for (int j = 0; j <= n; ++j)
		{
			o.width(15);
			o<<matr[i][j]<<' ';
		}
		o<<endl;
	}
	o<<endl;

	//Зворотній хід методу Гауса
	for (int i = n - 1; i > 0; --i)
	{
		for (int k = i - 1; k >= 0; --k)
		{
			T x = matr[k][i];
			vector<T> temp_x = matr[i];
			vector<T> temp_y = inverse[i];
			for (int j = 0; j <= n; ++j)
			{
				temp_x[j]=temp_x[j]*x;
				matr[k][j] = matr[k][j] - temp_x[j];
				if (j != n)
				{
					temp_y[j]=temp_y[j]*x;
					inverse[k][j] = inverse[k][j] - temp_y[j];
				}
			}
		}
	}

	vector<T> ans(n,0);
	T temp(0);
	ans[n-1]=matr[n-1][n];
	for (int i=n-2; i>=0; --i)
	{
		ans[i] = matr[i][n];
	}
	return ans;
}

template<class T>
vector<T> Matrix<T>::SqRoots(vector<T> b, Matrix<T> & Inv, ostream & o)
{
	if (determinant == NULL) determinant = new T(1);
	int N = size();
	Inv = Matrix<T>(N, (T) 0);
	for (int i = 0; i < N; ++i)
		for (int j = 0; j < N; ++j)
			if (i != j && matrix[i][j] != matrix[j][i]) return vector<T>();
	Matrix<T> S(N, (T)0);
	Matrix<T> D(N, (T)0);
	Matrix<T> ST(N, (T)0);
	D[0][0] = ((matrix[0][0] > (T)0) ? 1 : -1);
	S[0][0] = sqrt(matrix[0][0] * D[0][0]);
	for (int i = 0; i < N; ++i)
	{
		for (int j = i; j < N; ++j)
		{
			if (i == 0)
			{
				if (j != 0) S[i][j] = matrix[i][j] / (D[0][0] * S[0][0]);
				continue;
			}
			T sum = 0.0;
			for (int p = 0; p <= i - 1; ++p)
			{
				sum = sum + S[p][i] * D[p][p] * S[p][j];
			}
			S[i][j] = matrix[i][j] - sum;
			if (i == j)
			{
				D[i][j] = (S[i][j] > (T)0 ? 1 : -1);
				S[i][j] = sqrt(S[i][j] * D[i][j]);
			}
			else
			{
				D[i][j] = (T)0;
				S[i][j] = S[i][j] / (D[i][i] * S[i][i]);
			}
		}
	}
	ST = S.transpose();
	Matrix<T> B(N, (T)0);
	B = ST * D;

	T s = (T)1, d = (T)1, st = (T)1;
	for (int i =0 ; i < N; ++i)
	{
		s*=S[i][i];
		st*=ST[i][i];
		d*=D[i][i];
	}
	(*determinant) = s * d * st;

	o<<endl<<"S:\n"<<S;
	o<<endl;
	o<<endl<<"D:\n"<<D;
	o<<endl;
	
	vector<T> y(N, (T)0);
	y[0] = b[0] / B[0][0];
	for (int i = 1; i < N; ++i)
	{
		T sum = (T)0;
		for (int j = 0; j <= i - 1; ++j)
		{
			sum = sum + B[i][j] * y[j];
		}
		y[i] = (b[i] - sum) / B[i][i];
	}

	o<<"y (intermediate result):\n"<<y;
	o<<endl;

	vector<T> x(N, (T)0);
	x[N - 1] = y[N - 1] / S[N - 1][N - 1];
	for (int i = N - 2; i >= 0; --i)
	{
		T sum = (T)0;
		for (int j = i + 1; j <= N - 1; ++j)
		{
			sum = sum + S[i][j] * x[j];
		}
		x[i] = (y[i] - sum) / S[i][i];
	}

	//Знаходимо обернену
	vector<T> e(N, (T)0);
	for (int i = 0; i < N; ++i)
	{
		e[i] = 1;
		b = e;
		for (int j = 0; j < N; ++j)
			y[j] = 0;
		y[0] = b[0] / B[0][0];
		for (int k = 1; k < N; ++k)
		{
			T sum = (T)0;
			for (int j = 0; j <= k - 1; ++j)
			{
				sum = sum + B[k][j] * y[j];
			}
			y[k] = (b[k] - sum) / B[k][k];
		}

		vector<T> z(N, (T)0);
		for (int j = 0; j < N; ++j)
			z[j] = 0;
		z[N - 1] = y[N - 1] / S[N - 1][N - 1];
		for (int k = N - 2; k >= 0; --k)
		{
			T sum = (T)0;
			for (int j = k + 1; j <= N - 1; ++j)
			{
				sum = sum + S[k][j] * z[j];
			}
			z[k] = (y[k] - sum) / S[k][k];
		}

		for (int j = 0; j < N; ++j)
			Inv[j][i] = z[j];

		e[i] = 0;
	}

	return x;
}

template<class T>
vector<T> Matrix<T>::SimpleIteration(vector<T> f, const T & Eps, ostream & o)
{
	int N = size();
	Matrix<T> B(N, (T)0);
	vector<T> b(N, (T)0);
	for (int i = 0; i < N; ++i)
	{
		for (int j = 0; j < N; ++j)
		{
			if (i != j) B[i][j] = -matrix[i][j] / matrix[i][i];
			else B[i][j] = (T)0;
			b[i] = f[i] / matrix[i][i];
		}
	}

	o<<endl<<"Ax=f.\n x = Bx + b.\n"<<endl<<"B:\n"<<B;
	o<<endl<<"b:\n"<<b;
	o<<endl;

	vector<T> x_old = b;
	vector<T> x_new = b;

	o<<endl<<"x0:\n"<<x_old;
	o<<endl;

	T sum = (T)0;
	T q = (T)0;
	for (int i = 0; i < N; ++i)
	{
		sum = 0;
		for (int j = 0; j < N; ++j)
		{
			if (i != j) sum+=fabs(matrix[i][j]);
		}
		sum/=matrix[i][i];
		if (sum > q)
			q = sum;
	}
	T dif;
	vector<T> difference(N, (T)0);

	double n = B.Norm();
	if (n <= q && n < 1 && q < 1)
	{
		o<<endl<<"Method coincides with ||B||<q<1.\n ||B|| = "<<n<<"; q = "<<q<<"\nHow we can see inequality is right.\n";
	}
	else
	{
		T delta = Eps;
		Matrix<T> E = unitMatr<T>(N);
		Matrix<T> A(N, (T) 0);
		for (int i = 0; i < N; ++i)
			for (int j = 0; j < N; ++j)
				A[i][j] = matrix[i][j];
		T alpha = ((T)1) / (A.Norm() * (1 + delta));
		for (int i = 0; i < N; ++i)
			for (int j = 0; j < N; ++j)
				A[i][j] *= alpha;
		B = E - A;
	}
	int number_of_iter = 0;
	do
	{
		x_new = B * x_old + b;
		++number_of_iter;

		o<<"Number of iteration: "<<number_of_iter<<endl;
		o<<"x"<<number_of_iter<<" = ( ";
		for (int i = 0; i < N - 1; ++i)
			o<<x_new[i]<<", ";
		o<<x_new[N - 1]<<" )\n";

		difference = x_old - x_new;
		dif = NormVect(difference);
		x_old = x_new;
	}
	while(dif > (T)Eps);
	return x_new;
}

#endif