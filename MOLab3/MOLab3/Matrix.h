#pragma once
#include <vector>
#include <cmath>

using namespace std;

template<class T>
class Matrix//клас квадратних матриць
{
	vector<vector<T>> matrix;
public:
	Matrix<T>();
	Matrix<T>(int _size, T val=(T)0);
	int size() const { return (int) matrix.size(); }// розмір матриці
	template<class T>
	friend Matrix<T> unitMatr(int _size);//повертає одиничну матрицю відповідного розміру
	template<class T>
	friend bool operator>>(istream &i, Matrix<T> &a);//зчитування матриці з файлу
	template<class T>
	friend bool operator<<(ostream &o, Matrix<T> a);//вивід матриці у файл чи на екран
	Matrix<T> operator=(Matrix<T> a);
	Matrix<T> operator+(Matrix<T> a);
	Matrix<T> operator-(Matrix<T> a);
	Matrix<T> operator*(const double & a);
	vector<T> operator*(vector<T> a);//множення на вектор-стовпчик
	Matrix<T> operator*(Matrix<T> a);
	vector<T>& operator[](int i);
	Matrix<T> transpose();//транспонування
	bool operator==(Matrix<T> a);
	bool operator!=(Matrix<T> a);
	double NormMaxSumRow();
	void clear() {matrix.clear();}
	Matrix<T> Jacobi(const double & eps);
	T SumOutDiagQuad();//сума квадратів позадіагональних елементів
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
	o<<"(";
	for(int i=0; i<a.size(); ++i)
	{
		o<<a[i];
		if (i != (a.size() - 1)) o<<", ";
	}
	o<<")";
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

//матриці основні методи
template<class T>
Matrix<T>::Matrix<T>()
{
	matrix.clear();
}

template<class T>
Matrix<T>::Matrix<T>(int _size, T val)
{
	if (_size==0) matrix.clear();
	vector <T> y(0);
	for (int i=0; i<_size; ++i)
	{
		matrix.push_back(y);
		for (int j=0; j<_size; ++j)
			matrix[i].push_back(val);
	}
}

template<class T>
Matrix<T> Matrix<T>::operator=(Matrix<T> b)
{
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
Matrix<T> Matrix<T>::operator*(const double & a)
{
	if (a==0) return Matrix<T>(size());
	Matrix<T> result(size());
	for(int i=0; i<size(); ++i)
		for(int j=0; j<size(); ++j)
			result.matrix[i][j]=matrix[i][j]*a;
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
bool Matrix<T>::operator==(Matrix<T> a)
{
	if (size()!=a.size()) return false;
	for (int i=0; i<size(); ++i)
		for (int j=0; j<size(); ++j)
			if (matrix[i][j]!=a.matrix[i][j]) return false;
	return true;
}

template<class T>
bool Matrix<T>::operator!=(Matrix<T> a)
{
	if (size()!=a.size()) return true;
	for (int i=0; i<size(); ++i)
		for (int j=0; j<size(); ++j)
			if (matrix[i][j]!=a.matrix[i][j]) return true;
	return false;
}

template<class T>
double Matrix<T>::NormMaxSumRow()
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
T Matrix<T>::SumOutDiagQuad()
{
	T sum = (T)0;
	for (int i = 0; i < size(); ++i)
		for (int j = 0; j < size(); ++j)
			if (i != j) sum += matrix[i][j]*matrix[i][j];
	return sum;
}

template<class T>
T NormVectMax(vector<T> v)
{
	T max = (T)0;
	for (int i = 0 ; i < v.size(); ++i)
		if (fabs(v[i]) > max) max = fabs(v[i]);
	return max;
}

template<class T>
T NormVectAvg(vector<T> v)
{
	T sum = (T)0;
	for (int i = 0 ; i < v.size(); ++i)
		sum += v[i]*v[i];
	return sqrt(sum);
}

template<class T>
T quadEq(T b)
{
	T D;
	D=b*b+T(4);
	if (D<T(0)) return T(-999999);
	T t1, t2;
	t1=(b*(-1.0)-sqrt(D))/2.0;
	t2=(b*(-1.0)+sqrt(D))/2.0;
	return abs(t1)<abs(t2) ? t1 : t2;
}

template<class T>
T MaxOutDiagonalElem(Matrix<T> a, int & p, int  & q)
{
	T MAX(0);
	for (int i = 0; i < a.size(); ++i)
		for (int j = 0; j < a.size(); ++j)
			if (i != j && fabs(a[i][j]) > MAX)
			{
				MAX = fabs(a[i][j]);
				p = i;
				q = j;
			}
	return MAX;
}

template<class T>
Matrix<T> Matrix<T>::Jacobi(const double & eps)
{
	int n=size();
	Matrix<T> A(*this);
	Matrix<T> U(n);
	T MAX(0);
	int p=0, q=0;
	T teta=0;
	T phi, u1, u2;

	while(A.SumOutDiagQuad() > eps)
	{
		MAX=T(0); p=0; q=0;
		MAX=MaxOutDiagonalElem(A, p, q);
		if (p != q && fabs(A[p][q]) > (T)0.00000001)
		{
			teta = 2*A[p][q]/(A[p][p]-A[q][q]);
			phi = 1.0/2.0*atan(teta);
			
			u1=cos(phi);
			u2=sin(phi);
			for (int i=0; i<n; ++i)
				for (int j=0; j<n; ++j)
					if (i==j) U[i][j]=T(1);
					else U[i][j]=T(0);
			U[p][p]=u1;
			U[q][q]=u1;
			U[p][q]=(-1.0)*u2;
			U[q][p]=u2;
			A=U.transpose()*A*U;
		}
	}
	return A;
}