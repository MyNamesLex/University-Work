// Pointers.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
using namespace std;

void usepointers();
int main()
{
    usepointers();
}

void usepointers()
{
    int myvar1 = 5;
    int myvar2 = 20;
    double mydbl = 5.3;
    int* ptrVar; //this is going to store memory address of an int
    ptrVar = &myvar2; //take memory address of myvar2 and stores into pytrVar

    cout << *ptrVar << endl;//display the content of myVar2 using the ptrVar

    //change content of myvar2 using ptrVar
    //putting 10 into myvar2
    *ptrVar = 30;

    cout << *ptrVar << endl;


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
