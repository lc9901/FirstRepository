#include <stdio.h>
#include <stdlib.h>
#define ARR_LENGTH 10

typedef struct 
{
    int arr[ARR_LENGTH + 1];
	int length;
} Arrays;

void PrintArr(Arrays &arr)
{

    for(int i = 1; i< ARR_LENGTH + 1; i++)
	{
		printf("%d", arr.arr[i]);
		if(i < ARR_LENGTH)
		{
		     printf(",");
		}
	}
	printf("\n");
}

void InsertionSort(Arrays &arr)
{
	printf("===========InsertionSort===============\n");
	for(int i = 2; i < ARR_LENGTH + 1; i++)
	{
		if(arr.arr[i] < arr.arr[i - 1])
		{
		    arr.arr[0] = arr.arr[i];
			arr.arr[i] = arr.arr[i - 1];
			int j = i - 1;
			for( ; arr.arr[0] < arr.arr[j - 1]; j--)
			{
			     arr.arr[j] = arr.arr[j - 1];
			}
			arr.arr[j] = arr.arr[0];
		}
	PrintArr(arr);
	}
	printf("==========================\n");
	PrintArr(arr);
}

void ShellInserttionSort(Arrays &arr)
{
	printf("===========ShellSort===============\n");
	int step[] = {1,2,3,5};
	bool flag = true;
	int i = 3;
	while(flag)
	{
		flag = false;
	    for(int j = 1; j < ARR_LENGTH + 1 - step[i]; j++)
		{
			if(arr.arr[j] > arr.arr[j + step[i]])
			{
			    arr.arr[0] = arr.arr[j];
				arr.arr[j] = arr.arr[j+ step[i]];
				arr.arr[j + step[i]] = arr.arr[0];
				flag = true;
			}
		}
	    PrintArr(arr);
		if(i > 0)
		{
		    i--;
		}
	}
	printf("==========================\n");
	PrintArr(arr);
}

void BubbleSort(Arrays &arr)
{
	printf("===========BubbleSort===============\n");
	
	int flag = ARR_LENGTH;
	bool booFlag = true;

	for(int i = 1; i < ARR_LENGTH + 1; i++, flag--)
	{
		booFlag = true;
		for(int j = 1; j < flag; j++)
		{
		    if(arr.arr[j] > arr.arr[j + 1])
			{
				// arr.arr[j] ¡û¡ú arr.arr[j + 1];
				arr.arr[0] = arr.arr[j];
				arr.arr[j] = arr.arr[j + 1];
				arr.arr[j + 1] = arr.arr[0];
				booFlag = false;
			}
		}

		if(booFlag)
		{
		    break;
		}
		PrintArr(arr);
	}

	printf("==========================\n");
	PrintArr(arr);
}


// int SelectMin(int a, int b)
// {
//	 return a > b ? b : a;
// }

void SelectSort(Arrays &arr)
{
	printf("===========SelectSort===============\n");
	for(int i =1; i < ARR_LENGTH ; i++)
	{
		int minLocaton = i; 
		for(int j = i + 1; j < ARR_LENGTH + 1; j++)
		{
			if(arr.arr[j] < arr.arr[minLocaton])
			{
				minLocaton = j;
			}
		}
		if (minLocaton != i)
		{
			arr.arr[0] = arr.arr[i];
			arr.arr[i] = arr.arr[minLocaton];
			arr.arr[minLocaton] = arr.arr[0];
		}
		PrintArr(arr);
	}
	printf("==========================\n");
	PrintArr(arr);
}

int Partition(Arrays &arr, int low, int high)
{
	arr.arr[0] = arr.arr[low];
	int key =  arr.arr[low];

	while(low < high)
	{
		while(low < high && arr.arr[high] >= key) --high;
		 arr.arr[low] = arr.arr[high];

		 while(low <high && arr.arr[low] <= key) ++low;

		 arr.arr[high] = arr.arr[low];
	}

	arr.arr[low] = arr.arr[0];
	
	return low;
}

void QSort(Arrays &arr, int low, int high)
{
    printf("===========QSort===============\n");
	if(low < high)
	{
		int pivotloc =  Partition(arr, low, high);
		QSort(arr, low, pivotloc-1);
		QSort(arr, pivotloc + 1, high);
	}
	PrintArr(arr);

}


void QuickSort(Arrays &arr)
{
	QSort(arr, 1, arr.length);
	printf("==========================\n");
	PrintArr(arr);
}

int main()
{
	Arrays arr;
	arr.arr[0] = 0;
	arr.arr[1] = 54;
	arr.arr[2] = 56;	
	arr.arr[3] = 23;	
	arr.arr[4] = 78;
	arr.arr[5] = 46;
	arr.arr[6] = 12;
	arr.arr[7] = 45;
	arr.arr[8] = 90;
	arr.arr[9] = 34;
	arr.arr[10] = 23;
	arr.length = ARR_LENGTH;
	PrintArr(arr);
	printf("==========================\n");
	// InsertionSort(arr);
	// ShellInserttionSort(arr);
	// BubbleSort(arr);
	// SelectSort(arr);
	QuickSort(arr);
	getchar();
}
