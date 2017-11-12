//#include <stdio.h>
//#include <stdlib.h>
//#define BASE_SIZE 200
//
//typedef struct {
//    int OccurTime;
//	int NType;
//} Events, ElementType;
//
//typedef struct{
//   // char name;
//	int ArrivalTime;
//} customer;
//
//typedef struct{
//	customer *head;
//	customer *tail;
//	int length;
//} ServerQueue;
//
//bool InitQueue(ServerQueue *queue){
//	queue->head = (customer * )malloc(BASE_SIZE * sizeof(customer));
//	if(!(queue->head)) return false;
//	queue->tail = queue->head;
//	queue->length = 0;
//	return true;
//}
//
//bool EnQueue(ServerQueue *queue, customer *c){
//	*(queue->tail) = *c;
//	queue->tail ++;
//	if(!(queue->tail)) return false;
//	queue->length ++;
//	return true;
//}
//
//bool DeQueue(ServerQueue *queue, customer *c){
//	*c = *(queue->head);
//	queue->head ++;
//	queue->length --;
//	return true;
//}
//
//void InsertQueue(ServerQueue q[], customer *c){
//	if(q[0].length < q[1].length){
//	    EnQueue(&q[0], c);
//	}else{
//	    EnQueue(&q[1], c);
//	}
//}
//
//int main(){
//
//
//	ServerQueue q[2];
//
//	for(int i = 0; i< 2; i++){
//		InitQueue(&q[i]);
//	}
//
//	int TotalTime = 0, CustomerCount = 0;
//
//	char *criterial = (char *)malloc(10 * sizeof(char)) ;
//	scanf("%s",criterial);
//	while( *criterial != '#'){
//		printf("请输入当前的时间\n");
//		int arriveTime, eventType;
//		scanf("%d",&arriveTime);
//
//		printf("请输入事件类型：<1~3>\n");
//		scanf("%d",&eventType);
//		customer currentCustomer;
//		if(eventType == 1){
//		    DeQueue(&q[0], &currentCustomer);
//			CustomerCount++;
//			TotalTime += ( arriveTime - currentCustomer.ArrivalTime);
//		} else if (eventType == 2){
//		    DeQueue(&q[1], &currentCustomer);
//			CustomerCount++;
//			TotalTime += ( arriveTime - currentCustomer.ArrivalTime);
//		} else {
//			customer cc;
//		    cc.ArrivalTime = arriveTime;
//		    InsertQueue(q, &cc);
//		}
//		printf("输入#结束，任意字符继续。。。\n");
//		scanf("%s",criterial);
//	}
//	printf("平均时间为%d", TotalTime/CustomerCount);
//
//	return 0;
//}