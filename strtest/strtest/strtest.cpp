#include <stdio.h>
#include <stdlib.h>

typedef struct StrCustom
{
    int length;
	char *base;
}StrCustom;

//typedef struct StrCustom
//{
//    int length;
//	char base[];
//}StrCustom;


bool InitString(StrCustom &str, int maxLength)
{
	str.base = (char *)malloc(sizeof(char) * maxLength);
	if(!str.base) return false;

	str.length = 0;
    return true;
}

bool AddChar(StrCustom &str, char ch)
{
	if(!str.base[str.length + 1]) return false;
	str.base[str.length++] = ch;
	return true;
}


bool SubString(StrCustom strSrc, StrCustom &strTag, int star, int len)
{
	if(star < 0 || len > strSrc.length - star || len > strTag.length) return false;

	for(int i = 0; i < len; i++)
	{
		AddChar(strTag, strSrc.base[star + i]);
	}
	return true;
}

int FindStr(StrCustom str, StrCustom chs)
{
	int i =0, j=0; 
	for (;i < str.length && j < chs.length;) 
	{
		if(str.base[i] == chs.base[j]) 
		{
		    i++;j++;
		}
		else
		{
		    i-=(j-1);
			j=0;
		}
	}
	return i - chs.length + 1;
}

int main()
{
    StrCustom strSrc, strT;
	InitString(strSrc, 20);
	InitString(strT, 10);

	AddChar(strSrc, 'A');
	AddChar(strSrc, 'B');
	AddChar(strSrc, 'A');
	AddChar(strSrc, 'C');
	AddChar(strSrc, 'B');
	AddChar(strSrc, 'D');
	AddChar(strSrc, 'B');
	AddChar(strSrc, 'B');
	AddChar(strSrc, 'D');
	AddChar(strSrc, 'B');

	printf("字符串strSrc的长度为%d", strSrc.length);

	AddChar(strT, 'B');
	AddChar(strT, 'A');

	printf("字符串strT的长度为%d", strT.length);
	int location;

	location = FindStr(strSrc, strT);

	printf("字符串的位置在%d", location);
	getchar();
}