// Task B.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
using namespace std;

void recombination(string, string, string);


int main()
{
    string s1;
    cout << "insert a string(String 1)";
    cin >> s1;

    string s2;
    cout << "insert a string(String 2)";
    cin >> s2;

    string s3;
    cout << "insert a string(String 3)";
    cin >> s3;

    recombination(s1, s2, s3);
}

void recombination(string s1, string s2, string s3)
{
    int pos = 0;

    int n1Left = 0;
    int n1Right = 0;
    int n2Left = 0;
    int n2Right = 0;

    string s1_left[10];
    string s1_right[10];
    string s2_left[10];
    string s2_right[10];

    while (s1.find(s3, pos) != string::npos)
    {
        pos = s1.find(s3, pos); 
        s1_left[n1Left] = s1.substr(0, pos); 
        n1Left++; 

        s1_right[n1Right] = s1.substr(pos+s3.length(), s1.length() - (pos+s3.length())); 
        n1Right++;

        pos++;
    }
    pos = 0; 
    while (s2.find(s3, pos) != string::npos)
    {
        pos = s2.find(s3, pos);
        s2_left[n2Left] = s2.substr(0, pos);
        n2Left++;

        s2_right[n2Right] = s2.substr(pos + s3.length(), s2.length() - (pos+s3.length()));
        n2Right++;

        pos++;
    }

    for (int i = 0; i < n1Left; i++)
    {
        for (int j = 0; j < n2Right; j++)
        {
            cout << s1_left[i] + s3 + s2_right[j] << endl;
        }
    }

    for (int i = 0; i < n2Left; i++)
    {
        for (int j = 0; j < n1Right; j++)
        {
            cout << s2_left[i] + s3 + s1_right[j] << endl;
        }
    }
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
