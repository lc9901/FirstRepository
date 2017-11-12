//#include <stdio.h>
//#include <stdlib.h>
//#define BASE_SIZE 200
//#define ATTACH_STEP 10
//
//typedef struct  StackBox
//{
//	char *bottom;
//	char *top;
//	int length;
//};
//
//bool InitStack(StackBox *stack){
//	stack->bottom = (char *)malloc( BASE_SIZE * sizeof(char));
//	if(!stack->bottom) return false;
//	stack->top = stack->bottom;
//	stack->length = 0;
//	return true;
//}
//
//void GetStackTop(StackBox *stack, char *e){
//	e = (stack->top - 1);
//}
//
//void Pop(StackBox *stack, char *e){
//	stack->length--;
//	e = (--stack->top);
//}
//
//bool Push(StackBox *stack,  char *e){
//	if(!stack) return false;
//	if(!stack->top) return false;
//	
//
//
//	(stack->top) = e;
//	stack->length++;
//	stack->top++;
//
//    return true;
//}
//
//int Convert(char a){
//	switch (a)
//	{
//		case '+':
//		    return 0;
//		case '-':
//			return 1;
//		case '*':
//			return 2;
//		case '/':
//			return 3;
//		case '(':
//			return 4;
//		case ')':
//			return 5;
//		case '#':
//			return 6;
//		default :
//			return 7;
//	}
//}
//
//int Compare(char a, char b){
//    int x = Convert(a);
//	int y = Convert(b);
//	int count[7][7] = {
//		{1,1,-1,-1,-1,1,1},
//		{1,1,-1,-1,-1,1,1},
//		{1,1,1,1,-1,1,1},
//		{1,1,1,1,-1,1,1},
//	    {-1,-1,-1,-1,-1,0,2},
//		{1,1,1,1,2,1,1},
//	    {-1,-1,-1,-1,-1,2,0}
//	};
//	return count[x][y];
//}

//int main(){
//    char a = '#';
//	char tops;
//	StackBox *OPND, *OPTR;
//	OPND = (StackBox *)malloc(sizeof(StackBox));
//	OPTR = (StackBox *)malloc(sizeof(StackBox));
//
//	InitStack(OPND);
//	InitStack(OPTR);
//
//	Push(OPTR, &a);
//
//	char input ;
//	do{
//		input = getchar();
//
//
//		GetStackTop(OPND, &tops);
//		printf("---%c\n", input);
//	}while(input != '#' || tops != '#');
//
//    return 0;
//}