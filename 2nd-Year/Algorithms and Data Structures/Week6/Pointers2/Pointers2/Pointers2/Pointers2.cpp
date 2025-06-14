// Pointers2.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
using namespace std;

void printfirstchar(char* a)
{//display first char of the string
    cout << *a;
}

void modify(char* a)
{
    //modify first two chars % 
    *a = '%';
    *(a + 1) = '%';
}

void swap(int* pnum1, int* pnum2)
{
    int temp = *pnum1;
    *pnum1 = *pnum2;
    *pnum2 = temp;
}
int main()
{
    /*int num1 = 10;
    int num2 = 34;

    cout << num1 << endl;
    cout << num2 << endl;
    swap(&num1, &num2);
    cout << num1 << endl;
    cout << num2 << endl;
    */

    //dynamic array 
    
    int n;

    cout << "number of elements ?";

    cin >> n;

    //allocate array of size n

    int* psome = new int[n];

    //operate on the array ...

    //de allocate the memory
    delete[] psome;

    /*
    //array notation vs arithmetic pointer

    double w[3] = { 1.0, 2.0, 5.0 };

    //two ways

    double* pw = w;

    cout << "w[0]" << w[0] << endl;

    cout << "w[0]" << *pw << endl;



    /*
    string test = "this is a test string";
    modify(&test[0]);
    cout << test << endl;
    
    char string2[] = "this is a test string";

    printfirstchar(string2);
    */

    /*
    int numA = 10;
    double numB = 20;

    //get memory location of those variable using & operator

    cout << "num1 value " << numA << endl;
    cout << "num1 memory address " << &numA << endl;

    cout << "numB value " << numB << endl;
    cout << "numB memory Address " << &numB << endl;

    //create a pointer and store memory address of a variable

    int numC = 6;

    int* p_numC;

    p_numC = &numC; //will get memory address of numC and put into p_numC

    cout << "value of numC " << numC << endl;
    cout << "value of numC " << *p_numC << endl;

    //wild pointer

    int* f;

    *f = 7765; //rewrite a random location of your memory (dangerous dont do)

    int i;
    i = 25;

    int* ptr;
    ptr = &i;

    *ptr = 30;

    cout << *ptr;

    */

    //array and pointers
    /*
    int myarray[5] = { 10,20,30,50,5 };

    for (int i = 0; i < 5; i++)
    {
        cout << myarray[i] << " " << endl;
    }

    //using pointers
    //pointers to first element of the array
    int* ptr;
    */

    /*
    ptr = &myarray[0];

    cout << "value is " << *ptr << endl;

    //read value in position 2

    ptr = ptr + 2; //arithmetic pointer

    cout << "value is " << *ptr << endl;

*/

    //read the full array
    /*
    ptr = &myarray[0];

    cout << "array traversal with ptr " << endl;

    for (int i = 0; i < 5; i++)
    {
        cout << *(ptr + i) << endl;
    }

    cout << "array traversal with moving ptr " << endl;

    for (int i = 0; i < 5; i++)
    {
        cout << *ptr++ << endl;
    }

    cout << "array traversal " << endl;

    for (int i = 0; i < 10; i++)
    {
        cout << *(ptr + i) << endl;
    }

    */

    //arithmetic pointers with strings
    /*
    char string[] = "test";

    cout << string << endl;

    char* ptr_string = &string[0];

    ptr_string = ptr_string + 2;
    
    *ptr_string = 'a';

    *(ptr_string + 1) = 'a';

    cout << string << endl;
    */
}


// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
