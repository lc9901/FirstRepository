#include <stdio.h>
#include <stdlib.h>
#define BASE_SIZE 2000
#define ATTACH_STEP 10
#define JINZHI 8

typedef int DataType;

typedef struct LNode {
	DataType data;
} LNode;

typedef struct {
	LNode *top;
	LNode *bottom;
	int Length;
} Stack;

bool InitStack(Stack *stack){
	stack->bottom = (LNode *)malloc( BASE_SIZE * sizeof(LNode));
	if(!stack->bottom) return false;
	stack->top = stack->bottom;
	stack->Length = 0;
	return true;
}

bool DestoryStack(Stack *stack){
	return true;
}

bool IsEmpty(Stack *stack){
	return stack->bottom == stack->top;
}

int StackLienth(Stack *stack){
	return stack->Length;
}

void GetStackTop(Stack *stack, LNode &e){
	e.data = (stack->top - 1) ->data;
}

void Pop(Stack *stack, LNode &e){
	stack->Length--;
	e.data = (--stack->top)->data;
}

bool Push(Stack *stack, LNode &e){
	if(!stack) return false;
	if(!stack->top) return false;
	
	(stack->top)->data = e.data;
	stack->Length++;
	stack->top++;

    return true;
}

//int main(){
//	printf("ni de shijiae!!!");
//	Stack ss;
//	bool result = InitStack(&ss);
//		printf("The result is %d----1 \n", result);
//	LNode *ee = (LNode *)malloc(sizeof(LNode));
//	int count  ;
//	printf("ÇëÊäÈë");
//	scanf("%d",&count);
//	
//	while(count){
//	    ee->data = count % JINZHI;
//		result = Push(&ss, *ee);
//		count = count / JINZHI;
//	}
//	  printf("=====================================\n");
//	 LNode *eee = (LNode *)malloc(sizeof(LNode));
//
//	 while(!IsEmpty(&ss)){
//		  	  Pop(&ss, *eee);
//
//			  printf("%d", eee->data);
//	 }
//
//printf("\n");
//
//    return 0;
//}