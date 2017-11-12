#include <stdio.h>
#include <stdlib.h>
#include <stdarg.h>

#define ARRAY_DIM_MAX 10

typedef int Element;

typedef struct {
    Element *base;
	int dim; // The dimension of the array.
	int *bounds;
	int *constants;
} ArrayList;

bool Locate(ArrayList &arr, va_list ap, int &offSet)
{
	offSet = 0;
	for(int i = 0; i < arr.dim; i++)
	{
		int ind = va_arg(ap, int);
		if(ind < 0 || ind >= arr.bounds[i]) return false;
		offSet += arr.bounds[i + 1] * arr.constants[i + 1];
	}
	return true;
}

bool InitArray(ArrayList &arr, int dim, ...)
{ 
	if(dim < 1 || dim > ARRAY_DIM_MAX) return false;

	arr.dim = dim;
	arr.bounds = (int *)malloc(dim * sizeof(int));
	if(!arr.bounds) return false;
	int elemtotal = 1;
	va_list ap;
	va_start(ap, dim);
	for(int i = 0; i < dim; i++)
	{
		arr.bounds[i] = va_arg(ap, int);
		if(arr.bounds[i] < 0) return false;
		elemtotal *= arr.bounds[i];
	}
	va_end(ap);

	arr.base = (Element *)malloc(elemtotal * sizeof(Element));

	if(!arr.base) return false;

	arr.constants = (int *)malloc(dim * sizeof(int));
	if(!arr.constants) return false;
	arr.constants[dim - 1] = 1;
	for(int i = dim -2; i >= 0; --i)
	{
		arr.constants[i] = arr.bounds[i+1] * arr.constants[i +1];
	}
    return true;
}

bool DestoryArray(ArrayList &arr)
{
	if (!arr.base) return false;
	free(arr.base);

	if(!arr.bounds) return false;
	free(arr.bounds);

	if(!arr.constants) return false;
	free(arr.constants);

	return true;
}

bool GetValue(ArrayList &arr, Element &e, ...)
{
	int offSet;
	va_list ap;
	va_start(ap, e);
	if (Locate(arr, ap, offSet)) return false;
	e = *(arr.base +offSet);
	va_end(ap);
	return true;
}

bool SetValue(ArrayList &arr, Element &e, ...)
{
    int offSet;
	va_list ap;
	va_start(ap, e);
	if (Locate(arr, ap, offSet)) return false;
	*(arr.base + offSet) = e;
	va_end(ap);
	return true;
}

int main(){

	ArrayList arrTest1;
	bool result = InitArray(arrTest1, 3, 3,3,3);

	printf("%d",result);
    return 0;
}