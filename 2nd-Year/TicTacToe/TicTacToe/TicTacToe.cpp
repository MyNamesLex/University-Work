// TicTacToe.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <cstdlib>
#include <ostream>
#include <numeric>

//work on duplicate numbers
//if(a b c d e f g h i == whatever slot we are going to insert number into)
//dont write in slot and prompt to put in a different number

// a b c
// d e f
// g h i

using namespace std;

void drawGrid(int &a, int &b, int &c, int &d, int &e, int &f, int &g, int &h, int &i);
void Start(int a, int b, int c, int d, int e, int f, int g, int h, int i);
void StartSequence(int a, int b, int c, int d, int e, int f, int g, int h, int i);
void Call(int& a, int& b, int& c, int& d, int& e, int& f, int& g, int& h, int& i, bool &P1Turn, bool &P2Turn);
void AIStart();
void AIGameCall(int& a, int& b, int& c, int& d, int& e, int& f, int& g, int& h, int& i, bool& P1Turn, bool& AITurn);

int a = 0;
int b = 0;
int c = 0;
int d = 0;
int e = 0;
int f = 0;
int g = 0;
int h = 0;
int i = 0;

bool P1Turn = true;
bool P2Turn = false;

bool AI = false;
bool AITurn = false;

int main()
{
    StartSequence(a, b, c, d, e, f, g, h, i);
}

void drawGrid(int &a, int &b, int &c, int &d, int &e, int &f, int &g, int &h, int &i)
{
    //check if p1 won

    //horizontal 

    if (a + b + c == 15 && P1Turn == true)
    {
        cout << "Player 2 wins!" << endl;

        cout << a;
        cout << "  ";
        cout << b;
        cout << "  ";
        cout << c << endl;
        cout << "_______" << endl;
        cout << d;
        cout << "  ";
        cout << e;
        cout << "  ";
        cout << f << endl;
        cout << "_______" << endl;
        cout << g;
        cout << "  ";
        cout << h;
        cout << "  ";
        cout << i << endl;

        cout << endl;
        cout << "Numbers that won the game" << endl;
        cout << a;
        cout << "  ";
        cout << b;
        cout << "  ";
        cout << c;

        return;

    }

    if (d + e + f == 15 && P1Turn == true)
    {
        cout << "Player 2 wins!" << endl;

        cout << a;
        cout << "  ";
        cout << b;
        cout << "  ";
        cout << c << endl;
        cout << "_______" << endl;
        cout << d;
        cout << "  ";
        cout << e;
        cout << "  ";
        cout << f << endl;
        cout << "_______" << endl;
        cout << g;
        cout << "  ";
        cout << h;
        cout << "  ";
        cout << i << endl;

        cout << endl;
        cout << "Numbers that won the game" << endl;
        cout << d;
        cout << "  ";
        cout << e;
        cout << "  ";
        cout << f;
            

        return;
    }

    if (g + h + i == 15 && P1Turn == true)
    {
        cout << "Player 2 wins!" << endl;

        cout << a;
        cout << "  ";
        cout << b;
        cout << "  ";
        cout << c << endl;
        cout << "_______" << endl;
        cout << d;
        cout << "  ";
        cout << e;
        cout << "  ";
        cout << f << endl;
        cout << "_______" << endl;
        cout << g;
        cout << "  ";
        cout << h;
        cout << "  ";
        cout << i << endl;

        cout << endl;
        cout << "Numbers that won the game" << endl;
        cout << g;
        cout << "  ";
        cout << h;
        cout << "  ";
        cout << i;

        return;
    }

    //vertical

    if (a + d + g == 15 && P1Turn == true)
    {
        cout << "Player 2 wins!" << endl;

        cout << a;
        cout << "  ";
        cout << b;
        cout << "  ";
        cout << c << endl;
        cout << "_______" << endl;
        cout << d;
        cout << "  ";
        cout << e;
        cout << "  ";
        cout << f << endl;
        cout << "_______" << endl;
        cout << g;
        cout << "  ";
        cout << h;
        cout << "  ";
        cout << i << endl;

        cout << endl;
        cout << "Numbers that won the game" << endl;
        cout << a;
        cout << "  ";
        cout << d;
        cout << "  ";
        cout << g;

        return;
    }

    if (b + e + h == 15 && P1Turn == true)
    {
        cout << "Player 2 wins!" << endl;

        cout << a;
        cout << "  ";
        cout << b;
        cout << "  ";
        cout << c << endl;
        cout << "_______" << endl;
        cout << d;
        cout << "  ";
        cout << e;
        cout << "  ";
        cout << f << endl;
        cout << "_______" << endl;
        cout << g;
        cout << "  ";
        cout << h;
        cout << "  ";
        cout << i << endl;

        cout << endl;
        cout << "Numbers that won the game" << endl;
        cout << b;
        cout << "  ";
        cout << e;
        cout << "  ";
        cout << h;

        return;
    }

    if (c + f + i == 15 && P1Turn == true)
    {
        cout << "Player 2 wins!" << endl;

        cout << a;
        cout << "  ";
        cout << b;
        cout << "  ";
        cout << c << endl;
        cout << "_______" << endl;
        cout << d;
        cout << "  ";
        cout << e;
        cout << "  ";
        cout << f << endl;
        cout << "_______" << endl;
        cout << g;
        cout << "  ";
        cout << h;
        cout << "  ";
        cout << i << endl;

        cout << endl;
        cout << "Numbers that won the game" << endl;
        cout << c;
        cout << "  ";
        cout << f;
        cout << "  ";
        cout << i;

        return;
    }

    //diagonal

    if (a + e + i == 15 && P1Turn == true)
    {
        cout << "Player 2 wins!" << endl;

        cout << a;
        cout << "  ";
        cout << b;
        cout << "  ";
        cout << c << endl;
        cout << "_______" << endl;
        cout << d;
        cout << "  ";
        cout << e;
        cout << "  ";
        cout << f << endl;
        cout << "_______" << endl;
        cout << g;
        cout << "  ";
        cout << h;
        cout << "  ";
        cout << i << endl;
        
        cout << endl;
        cout << "Numbers that won the game" << endl;
        cout << a;
        cout << "  ";
        cout << e;
        cout << "  ";
        cout << i;

        return;
    }

    if (c + e + g == 15 && P1Turn == true)
    {
        cout << "Player 2 wins!" << endl;

        cout << a;
        cout << "  ";
        cout << b;
        cout << "  ";
        cout << c << endl;
        cout << "_______" << endl;
        cout << d;
        cout << "  ";
        cout << e;
        cout << "  ";
        cout << f << endl;
        cout << "_______" << endl;
        cout << g;
        cout << "  ";
        cout << h;
        cout << "  ";
        cout << i << endl;

        cout << endl;
        cout << "Numbers that won the game" << endl;
        cout << c;
        cout << "  ";
        cout << e;
        cout << "  ";
        cout << g;

        return;
    }

    //check if p2 won

    //horizontal 

    if (a + b + c == 15 && P2Turn == true || a + b + c == 15 && AITurn == true)
    {
        if (AI == false)
        {
            cout << "Player 1 wins!" << endl;
        }
        else
        {
            cout << "AI wins!" << endl;
        }

        cout << a;
        cout << "  ";
        cout << b;
        cout << "  ";
        cout << c << endl;
        cout << "_______" << endl;
        cout << d;
        cout << "  ";
        cout << e;
        cout << "  ";
        cout << f << endl;
        cout << "_______" << endl;
        cout << g;
        cout << "  ";
        cout << h;
        cout << "  ";
        cout << i << endl;

        cout << endl;
        cout << "Numbers that won the game" << endl;
        cout << a;
        cout << "  ";
        cout << b;
        cout << "  ";
        cout << c;

        return;
    }

    if (d + e + f == 15 && P2Turn == true || d + e + f == 15 && AITurn == true)
    {
        if (AI == false)
        {
            cout << "Player 1 wins!" << endl;
        }
        else
        {
            cout << "AI wins!" << endl;
        }

        cout << a;
        cout << "  ";
        cout << b;
        cout << "  ";
        cout << c << endl;
        cout << "_______" << endl;
        cout << d;
        cout << "  ";
        cout << e;
        cout << "  ";
        cout << f << endl;
        cout << "_______" << endl;
        cout << g;
        cout << "  ";
        cout << h;
        cout << "  ";
        cout << i << endl;

        cout << endl;
        cout << "Numbers that won the game" << endl;
        cout << d;
        cout << "  ";
        cout << e;
        cout << "  ";
        cout << f;

        return;
    }

    if (g + h + i == 15 && P2Turn == true || g + h + i == 15 && AITurn == true)
    {
        if (AI == false)
        {
            cout << "Player 1 wins!" << endl;
        }
        else
        {
            cout << "AI wins!" << endl;
        }

        cout << a;
        cout << "  ";
        cout << b;
        cout << "  ";
        cout << c << endl;
        cout << "_______" << endl;
        cout << d;
        cout << "  ";
        cout << e;
        cout << "  ";
        cout << f << endl;
        cout << "_______" << endl;
        cout << g;
        cout << "  ";
        cout << h;
        cout << "  ";
        cout << i << endl;

        cout << endl;
        cout << "Numbers that won the game" << endl;
        cout << g;
        cout << "  ";
        cout << h;
        cout << "  ";
        cout << i;

        return;
    }

    //vertical

    if (a + d + g == 15 && P2Turn == true || a + d + g == 15 && AITurn == true)
    {
        if (AI == false)
        {
            cout << "Player 1 wins!" << endl;
        }
        else
        {
            cout << "AI wins!" << endl;
        }

        cout << a;
        cout << "  ";
        cout << b;
        cout << "  ";
        cout << c << endl;
        cout << "_______" << endl;
        cout << d;
        cout << "  ";
        cout << e;
        cout << "  ";
        cout << f << endl;
        cout << "_______" << endl;
        cout << g;
        cout << "  ";
        cout << h;
        cout << "  ";
        cout << i << endl;

        cout << endl;
        cout << "Numbers that won the game" << endl;
        cout << a;
        cout << "  ";
        cout << d;
        cout << "  ";
        cout << g;

        return;
    }

    if (b + e + h == 15 && P2Turn == true || b + e + h == 15 && AITurn == true)
    {
        if (AI == false)
        {
            cout << "Player 1 wins!" << endl;
        }
        else
        {
            cout << "AI wins!" << endl;
        }

        cout << a;
        cout << "  ";
        cout << b;
        cout << "  ";
        cout << c << endl;
        cout << "_______" << endl;
        cout << d;
        cout << "  ";
        cout << e;
        cout << "  ";
        cout << f << endl;
        cout << "_______" << endl;
        cout << g;
        cout << "  ";
        cout << h;
        cout << "  ";
        cout << i << endl;

        cout << endl;
        cout << "Numbers that won the game" << endl;
        cout << b;
        cout << "  ";
        cout << e;
        cout << "  ";
        cout << h;

        return;
    }

    if (c + f + i == 15 && P2Turn == true || c + f + i == 15 && AITurn == true)
    {
        if (AI == false)
        {
            cout << "Player 1 wins!" << endl;
        }
        else
        {
            cout << "AI wins!" << endl;
        }

        cout << a;
        cout << "  ";
        cout << b;
        cout << "  ";
        cout << c << endl;
        cout << "_______" << endl;
        cout << d;
        cout << "  ";
        cout << e;
        cout << "  ";
        cout << f << endl;
        cout << "_______" << endl;
        cout << g;
        cout << "  ";
        cout << h;
        cout << "  ";
        cout << i << endl;

        cout << endl;
        cout << "Numbers that won the game" << endl;
        cout << c;
        cout << "  ";
        cout << f;
        cout << "  ";
        cout << i;

        return;
    }

    //diagonal

    if (a + e + i == 15 && P2Turn == true || a + e + i == 15 && AITurn == true)
    {
        if (AI == false)
        {
            cout << "Player 1 wins!" << endl;
        }
        else
        {
            cout << "AI wins!" << endl;
        }

        cout << a;
        cout << "  ";
        cout << b;
        cout << "  ";
        cout << c << endl;
        cout << "_______" << endl;
        cout << d;
        cout << "  ";
        cout << e;
        cout << "  ";
        cout << f << endl;
        cout << "_______" << endl;
        cout << g;
        cout << "  ";
        cout << h;
        cout << "  ";
        cout << i << endl;

        cout << endl;
        cout << "Numbers that won the game" << endl;
        cout << a;
        cout << "  ";
        cout << e;
        cout << "  ";
        cout << i;

        return;
    }

    if (c + e + g == 15 && P2Turn == true || c + e + g == 15 && AITurn == true)
    {
        if (AI == false)
        {
            cout << "Player 1 wins!" << endl;
        }
        else
        {
            cout << "AI wins!" << endl;
        }

        cout << a;
        cout << "  ";
        cout << b;
        cout << "  ";
        cout << c << endl;
        cout << "_______" << endl;
        cout << d;
        cout << "  ";
        cout << e;
        cout << "  ";
        cout << f << endl;
        cout << "_______" << endl;
        cout << g;
        cout << "  ";
        cout << h;
        cout << "  ";
        cout << i << endl;

        cout << endl;
        cout << "Numbers that won the game" << endl;
        cout << c;
        cout << " ";
        cout << e;
        cout << " ";
        cout << g;

        return;
    }

    //draw grid

    cout << a;
    cout << "  ";
    cout << b;
    cout << "  ";
    cout << c << endl;
    cout << "_______" << endl;
    cout << d;
    cout << "  ";
    cout << e;
    cout << "  ";
    cout << f << endl;
    cout << "_______" << endl;
    cout << g;
    cout << "  ";
    cout << h;
    cout << "  ";
    cout << i << endl;

    if (AI == false)
    {
        Call(a, b, c, d, e, f, g, h, i, P1Turn, P2Turn);
    }
    if (AI == true)
    {
        AIGameCall(a, b, c, d, e, f, g, h, i, P1Turn, AITurn);
    }
}

void StartSequence(int a, int b, int c, int d, int e, int f, int g, int h, int i)
{
    string s;
    cout << "type 's' to start 2 player or 'ai' to start singleplayer ";
    cin >> s;

    if (s == "s")
    {
        Start(a, b, c, d, e, f, g, h, i);
    }

    if (s == "ai")
    {
        AI = true;
        AIStart();
    }
}

void Start(int a, int b, int c, int d, int e, int f, int g, int h, int i)
{
    drawGrid(a, b, c, d, e, f, g, h, i);
}

void Call(int &a, int &b, int &c, int &d, int &e, int &f, int &g, int &h, int &i, bool &P1Turn, bool &P2Turn)
{
    int col1row1 = 11;
    int col1row2 = 12;
    int col1row3 = 13;

    int col2row1 = 21;
    int col2row2 = 22;
    int col2row3 = 23;

    int col3row1 = 31;
    int col3row2 = 32;
    int col3row3 = 33;

    int StartPos;

    if (P1Turn == true)
    {
        cout << "Player 1's Turn ";
    }

    if (P2Turn == true)
    {
        cout << "Player 2's Turn ";
    }

    cout << "Pick a place to start ";
    cin >> StartPos;

    switch (StartPos)
    {
    case 11:
        cout << "Number entered";
        cout << " ";
        cout << StartPos << endl;
        break;
    case 12:
        cout << "Number entered";
        cout << " ";
        cout << StartPos << endl;
        break;
    case 13:
        cout << "Number entered";
        cout << " ";
        cout << StartPos << endl;
        break;
    case 21:
        cout << "Number entered";
        cout << " ";
        cout << StartPos << endl;
        break;
    case 22:
        cout << "Number entered";
        cout << " ";
        cout << StartPos << endl;
        break;
    case 23:
        cout << "Number entered";
        cout << " ";
        cout << StartPos << endl;
        break;
    case 31:
        cout << "Number entered";
        cout << " ";
        cout << StartPos << endl;
        break;
    case 32:
        cout << "Number entered";
        cout << " ";
        cout << StartPos << endl;
        break;
    case 33:
        cout << "Number entered";
        cout << " ";
        cout << StartPos << endl;
        break;

    default:
        cout << " Number has to be 1-9" << endl;
        cout << "Number entered";
        cout << " ";
        cout << StartPos << endl;

        Call(a, b, c, d, e, f, g, h, i, P1Turn, P2Turn);
        break;
    }

    if (StartPos == col1row1)
    {
        if (a != 0)
        {
            cout << "That position has been filled, please choose another spot" << endl;
            Call(a, b, c, d, e, f, g, h, i, P1Turn, P2Turn);
        }
        if (P1Turn == true)
        {
            cout << "Player 1 Turn ";
        }
        if (P2Turn == true)
        {
            cout << "Player 2 Turn ";
        }

        int number;
        cout << "Insert a number to place in column 1, row 1 ";
        cin >> number;
        while (number > 9 || number < 1)
        {
            cout << " Number has to be 1-9" << endl;

            cout << "Insert a number to place in column 1, row 1 ";

            cin >> number;
        }

        /*
        while (number == a || b || c || d || e || f || g || h)
        {
            cout << "duplicate number has been found" << endl; 

            cout << "Insert a number to place in column 1, row 1 " << endl;

            cin >> number;
        }
        */
        a = number;

        if (P2Turn == true)
        {
            P1Turn = true;
            P2Turn = false;
        }
        else if (P1Turn == true)
        {
            P1Turn = false;
            P2Turn = true;
        }

        drawGrid(a, b, c, d, e, f, g, h, i);
    }

    if (StartPos == col1row2)
    {
        if (b != 0)
        {
            cout << "That position has been filled, please choose another spot" << endl;
            Call(a, b, c, d, e, f, g, h, i, P1Turn, P2Turn);
        }

        if (P1Turn == true)
        {
            cout << "Player 1 Turn ";
        }
        if (P2Turn == true)
        {
            cout << "Player 2 Turn ";
        }

        int number;
        cout << "Insert a number to place in column 1, row 2 ";
        cin >> number;

        while (number > 9 || number < 1)
        {
            cout << " Number has to be 1-9" << endl;

            cout << "Insert a number to place in column 1, row 2 ";

            cin >> number;
        }
        /*
        while (number == a || b || c || d || e || f || g || h)
        {
            cout << "duplicate number has been found" << endl;

            cout << "Insert a number to place in column 1, row 2 " << endl;


            cin >> number;
        }
        */
        b = number;

        if (P2Turn == true)
        {
            P1Turn = true;
            P2Turn = false;
        }
        else if (P1Turn == true)
        {
            P1Turn = false;
            P2Turn = true;
        }

        drawGrid(a, b, c, d, e, f, g, h, i);
    }

    if (StartPos == col1row3)
    {
        if (c != 0)
        {
            cout << "That position has been filled, please choose another spot" << endl;
            Call(a, b, c, d, e, f, g, h, i, P1Turn, P2Turn);
        }

        if (P1Turn == true)
        {
            cout << "Player 1 Turn ";
        }
        if (P2Turn == true)
        {
            cout << "Player 2 Turn ";
        }

        int number;
        cout << "Insert a number to place in column 1, row 3 ";
        cin >> number;

        while (number > 9 || number < 1)
        {
            cout << " Number has to be 1-9" << endl;

            cout << "Insert a number to place in column 1, row 3 ";

            cin >> number;
        }
        /*
        while (number == a || b || c || d || e || f || g || h)
        {
            cout << "duplicate number has been found" << endl;

            cout << "Insert a number to place in column 1, row 3 " << endl;


            cin >> number;
        }
        */
        c = number;

        if (P2Turn == true)
        {
            P1Turn = true;
            P2Turn = false;
        }
        else if (P1Turn == true)
        {
            P1Turn = false;
            P2Turn = true;
        }

        drawGrid(a, b, c, d, e, f, g, h, i);
    }

    if (StartPos == col2row1)
    {
        if (d != 0)
        {
            cout << "That position has been filled, please choose another spot" << endl;
            Call(a, b, c, d, e, f, g, h, i, P1Turn, P2Turn);
        }

        if (P1Turn == true)
        {
            cout << "Player 1 Turn ";
        }
        if (P2Turn == true)
        {
            cout << "Player 2 Turn ";
        }

        int number;
        cout << "Insert a number to place in column 2, row 1 ";
        cin >> number;

        while (number > 9 || number < 1)
        {
            cout << " Number has to be 1-9" << endl;

            cout << "Insert a number to place in column 2, row 1 ";

            cin >> number;
        }

        /*
        while (number == a || b || c || d || e || f || g || h)
        {
            cout << "duplicate number has been found" << endl;

            cout << "Insert a number to place in column 2, row 1 " << endl;


            cin >> number;
        }
        */
        d = number;

        if (P2Turn == true)
        {
            P1Turn = true;
            P2Turn = false;
        }
        else if (P1Turn == true)
        {
            P1Turn = false;
            P2Turn = true;
        }

        drawGrid(a, b, c, d, e, f, g, h, i);
    }

    if (StartPos == col2row2)
    {
        if (e != 0)
        {
            cout << "That position has been filled, please choose another spot" << endl;
            Call(a, b, c, d, e, f, g, h, i, P1Turn, P2Turn);
        }

        if (P1Turn == true)
        {
            cout << "Player 1 Turn ";
        }
        if (P2Turn == true)
        {
            cout << "Player 2 Turn ";
        }

        int number;
        cout << "Insert a number to place in column 2, row 2 ";
        cin >> number;

        while (number > 9 || number < 1)
        {
            cout << " Number has to be 1-9" << endl;

            cout << "Insert a number to place in column 2, row 2 ";

            cin >> number;
        }
        /*
        while (number == a || b || c || d || e || f || g || h)
        {
            cout << "duplicate number has been found" << endl;

            cout << "Insert a number to place in column 2, row 2 " << endl;


            cin >> number;
        }
        */
        e = number;

        if (P2Turn == true)
        {
            P1Turn = true;
            P2Turn = false;
        }
        else if (P1Turn == true)
        {
            P1Turn = false;
            P2Turn = true;
        }


        drawGrid(a, b, c, d, e, f, g, h, i);
    }

    if (StartPos == col2row3)
    {
        if (f != 0)
        {
            cout << "That position has been filled, please choose another spot" << endl;
            Call(a, b, c, d, e, f, g, h, i, P1Turn, P2Turn);
        }

        if (P1Turn == true)
        {
            cout << "Player 1 Turn ";
        }
        if (P2Turn == true)
        {
            cout << "Player 2 Turn ";
        }

        int number;
        cout << "Insert a number to place in column 2, row 3 ";
        cin >> number;

        while (number > 9 || number < 1)
        {
            cout << " Number has to be 1-9" << endl;

            cout << "Insert a number to place in column 2, row 3 ";

            cin >> number;
        }
        /*
        while (number == a || b || c || d || e || f || g || h)
        {
            cout << "duplicate number has been found" << endl;

            cout << "Insert a number to place in column 2, row 3 " << endl;


            cin >> number;
        }
        */
        f = number;

        if (P2Turn == true)
        {
            P1Turn = true;
            P2Turn = false;
        }
        else if (P1Turn == true)
        {
            P1Turn = false;
            P2Turn = true;
        }


        drawGrid(a, b, c, d, e, f, g, h, i);
    }

    if (StartPos == col3row1)
    {
        if (g != 0)
        {
            cout << "That position has been filled, please choose another spot" << endl;
            Call(a, b, c, d, e, f, g, h, i, P1Turn, P2Turn);
        }

        if (P1Turn == true)
        {
            cout << "Player 1 Turn ";
        }
        if (P2Turn == true)
        {
            cout << "Player 2 Turn ";
        }

        int number;
        cout << "Insert a number to place in column 3, row 1 ";
        cin >> number;

        while (number > 9 || number < 1)
        {
            cout << " Number has to be 1-9" << endl;

            cout << "Insert a number to place in column 3, row 1 ";

            cin >> number;
        }

        /*
        while (number == a || b || c || d || e || f || g || h)
        {
            cout << "duplicate number has been found" << endl;

            cout << "Insert a number to place in column 3, row 1 " << endl;


            cin >> number;
        }
        */
        g = number;

        if (P2Turn == true)
        {
            P1Turn = true;
            P2Turn = false;
        }
        else if (P1Turn == true)
        {
            P1Turn = false;
            P2Turn = true;
        }
        drawGrid(a, b, c, d, e, f, g, h, i);
    }

    if (StartPos == col3row2)
    {
        if (h != 0)
        {
            cout << "That position has been filled, please choose another spot" << endl;
            Call(a, b, c, d, e, f, g, h, i, P1Turn, P2Turn);
        }

        if (P1Turn == true)
        {
            cout << "Player 1 Turn ";
        }
        if (P2Turn == true)
        {
            cout << "Player 2 Turn ";
        }

        int number;
        cout << "Insert a number to place in column 3, row 2 ";
        cin >> number;

        while (number > 9 || number < 1)
        {
            cout << " Number has to be 1-9" << endl;

            cout << "Insert a number to place in column 3, row 2 ";

            cin >> number;
        }

        /*
        while (number == a || b || c || d || e || f || g || h)
        {
            cout << "duplicate number has been found" << endl;

            cout << "Insert a number to place in column 3, row 2 " << endl;


            cin >> number;
        }
        */
        h = number;

        if (P2Turn == true)
        {
            P1Turn = true;
            P2Turn = false;
        }
        else if (P1Turn == true)
        {
            P1Turn = false;
            P2Turn = true;
        }


        drawGrid(a, b, c, d, e, f, g, h, i);
    }

    if (StartPos == col3row3)
    {
        if (i != 0)
        {
            cout << "That position has been filled, please choose another spot" << endl;
            Call(a, b, c, d, e, f, g, h, i, P1Turn, P2Turn);
        }

        if (P1Turn == true)
        {
            cout << "Player 1 Turn ";
        }
        if (P2Turn == true)
        {
            cout << "Player 2 Turn ";
        }

        int number;
        cout << "Insert a number to place in column 3, row 3 ";
        cin >> number;

        while (number > 9 || number < 1)
        {
            cout << " Number has to be 1-9" << endl;

            cout << "Insert a number to place in column 3, row 3 ";

            cin >> number;
        }

        /*
        while (number == a || b || c || d || e || f || g || h)
        {
            cout << "duplicate number has been found" << endl;

            cout << "Insert a number to place in column 3, row 3 " << endl;

            cin >> number;
        }
        */

        i = number;

        if (P2Turn == true)
        {
            P1Turn = true;
            P2Turn = false;
        }
        else if (P1Turn == true)
        {
            P1Turn = false;
            P2Turn = true;
        }

        drawGrid(a, b, c, d, e, f, g, h, i);
    }
}

//AI Code

void AIStart()
{
    drawGrid(a, b, c, d, e, f, g, h, i);
}

void AIGameCall(int& a, int& b, int& c, int& d, int& e, int& f, int& g, int& h, int& i, bool& P1Turn, bool& AITurn)
{
    int col1row1 = 11;
    int col1row2 = 12;
    int col1row3 = 13;

    int col2row1 = 21;
    int col2row2 = 22;
    int col2row3 = 23;

    int col3row1 = 31;
    int col3row2 = 32;
    int col3row3 = 33;

    int StartPos;
    int StartPosAI;

    if (P1Turn == true)
    {
        cout << "Player 1's Turn ";
    }

    if (AITurn == true)
    {
        cout << "AI's Turn ";

        StartPosAI = rand() % 10 + 3 | rand() % 20 + 3 | rand() % 30 + 3;

        switch (StartPosAI)
        {
        case 11:
            cout << "Number entered";
            cout << " ";
            cout << StartPosAI << endl;
            break;
        case 12:
            cout << "Number entered";
            cout << " ";
            cout << StartPosAI << endl;
            break;
        case 13:
            cout << "Number entered";
            cout << " ";
            cout << StartPosAI << endl;
            break;
        case 21:
            cout << "Number entered";
            cout << " ";
            cout << StartPosAI << endl;
            break;
        case 22:
            cout << "Number entered";
            cout << " ";
            cout << StartPosAI << endl;
            break;
        case 23:
            cout << "Number entered";
            cout << " ";
            cout << StartPosAI << endl;
            break;
        case 31:
            cout << "Number entered";
            cout << " ";
            cout << StartPosAI << endl;
            break;
        case 32:
            cout << "Number entered";
            cout << " ";
            cout << StartPosAI << endl;
            break;
        case 33:
            cout << "Number entered";
            cout << " ";
            cout << StartPosAI << endl;
            break;

        default:
            cout << " Number has to be 1-9" << endl;
            cout << "Number entered";
            cout << " ";
            cout << StartPosAI << endl;

            AIGameCall(a, b, c, d, e, f, g, h, i, P1Turn, AITurn);
            break;
        }

        if (StartPosAI == col1row1)
        {
            if (a != 0)
            {
                cout << "That position has been filled, please choose another spot" << endl;
                AIGameCall(a, b, c, d, e, f, g, h, i, P1Turn, AITurn);
            }

            if (P1Turn == true)
            {
                cout << "Player 1 Turn ";
            }
            if (P2Turn == true)
            {
                cout << "Player 2 Turn ";
            }

            int number = rand() % 9 + 1;
            cout << "Insert a number to place in column 1, row 1 " << endl;

            while (number > 9 || number < 1)
            {
                cout << " Number has to be 1-9" << endl;

                cout << "Insert a number to place in column 1, row 1 " << endl;

                cin >> number;
            }
            /*
            while (number == a || b || c || d || e || f || g || h)
            {
                cout << "duplicate number has been found" << endl;

                cout << "Insert a number to place in column 1, row 1 " << endl;

                cin >> number;
            }
            */
            a = number;

            if (AITurn == true)
            {
                P1Turn = true;
                AITurn = false;
            }
            else if (P1Turn == true)
            {
                P1Turn = false;
                AITurn = true;
            }

            drawGrid(a, b, c, d, e, f, g, h, i);
        }

        if (StartPosAI == col1row2)
        {
            if (b != 0)
            {
                cout << "That position has been filled, please choose another spot" << endl;
                AIGameCall(a, b, c, d, e, f, g, h, i, P1Turn, AITurn);
            }

            if (P1Turn == true)
            {
                cout << "Player 1 Turn ";
            }
            if (P2Turn == true)
            {
                cout << "Player 2 Turn ";
            }

            int number = rand() % 9 + 1;
            cout << "Insert a number to place in column 1, row 2 " << endl;

            while (number > 9 || number < 1)
            {
                cout << " Number has to be 1-9" << endl;

                cout << "Insert a number to place in column 1, row 2 " << endl;

                cin >> number;
            }
            /*
            while (number == a || b || c || d || e || f || g || h)
            {
                cout << "duplicate number has been found" << endl;

                cout << "Insert a number to place in column 1, row 2 " << endl;


                cin >> number;
            }
            */
            b = number;

            if (AITurn == true)
            {
                P1Turn = true;
                AITurn = false;
            }
            else if (P1Turn == true)
            {
                P1Turn = false;
                AITurn = true;
            }

            drawGrid(a, b, c, d, e, f, g, h, i);
        }

        if (StartPosAI == col1row3)
        {
            if (c != 0)
            {
                cout << "That position has been filled, please choose another spot" << endl;
                AIGameCall(a, b, c, d, e, f, g, h, i, P1Turn, AITurn);
            }

            if (P1Turn == true)
            {
                cout << "Player 1 Turn ";
            }
            if (P2Turn == true)
            {
                cout << "Player 2 Turn ";
            }

            int number = rand() % 9 + 1;
            cout << "Insert a number to place in column 1, row 3 " << endl;

            while (number > 9 || number < 1)
            {
                cout << " Number has to be 1-9" << endl;

                cout << "Insert a number to place in column 1, row 3 " << endl;

                cin >> number;
            }
            /*
            while (number == a || b || c || d || e || f || g || h)
            {
                cout << "duplicate number has been found" << endl;

                cout << "Insert a number to place in column 1, row 3 " << endl;


                cin >> number;
            }
            */
            c = number;

            if (AITurn == true)
            {
                P1Turn = true;
                AITurn = false;
            }
            else if (P1Turn == true)
            {
                P1Turn = false;
                AITurn = true;
            }

            drawGrid(a, b, c, d, e, f, g, h, i);
        }

        if (StartPosAI == col2row1)
        {
            if (d != 0)
            {
                cout << "That position has been filled, please choose another spot" << endl;
                AIGameCall(a, b, c, d, e, f, g, h, i, P1Turn, AITurn);

            }
            if (P1Turn == true)
            {
                cout << "Player 1 Turn ";
            }
            if (P2Turn == true)
            {
                cout << "Player 2 Turn ";
            }

            int number = rand() % 9 + 1;
            cout << "Insert a number to place in column 2, row 1 " << endl;

            while (number > 9 || number < 1)
            {
                cout << " Number has to be 1-9" << endl;

                cout << "Insert a number to place in column 2, row 1 " << endl;

                cin >> number;
            }

            /*
            while (number == a || b || c || d || e || f || g || h)
            {
                cout << "duplicate number has been found" << endl;

                cout << "Insert a number to place in column 2, row 1 " << endl;


                cin >> number;
            }
            */
            d = number;

            if (AITurn == true)
            {
                P1Turn = true;
                AITurn = false;
            }
            else if (P1Turn == true)
            {
                P1Turn = false;
                AITurn = true;
            }

            drawGrid(a, b, c, d, e, f, g, h, i);
        }

        if (StartPosAI == col2row2)
        {
            if (e != 0)
            {
                cout << "That position has been filled, please choose another spot" << endl;
                AIGameCall(a, b, c, d, e, f, g, h, i, P1Turn, AITurn);
            }

            if (P1Turn == true)
            {
                cout << "Player 1 Turn ";
            }
            if (P2Turn == true)
            {
                cout << "Player 2 Turn ";
            }

            int number = rand() % 9 + 1;
            cout << "Insert a number to place in column 2, row 2 " << endl;

            while (number > 9 || number < 1)
            {
                cout << " Number has to be 1-9" << endl;

                cout << "Insert a number to place in column 2, row 2 " << endl;

                cin >> number;
            }
            /*
            while (number == a || b || c || d || e || f || g || h)
            {
                cout << "duplicate number has been found" << endl;

                cout << "Insert a number to place in column 2, row 2 " << endl;


                cin >> number;
            }
            */
            e = number;

            if (AITurn == true)
            {
                P1Turn = true;
                AITurn = false;
            }
            else if (P1Turn == true)
            {
                P1Turn = false;
                AITurn = true;
            }

            drawGrid(a, b, c, d, e, f, g, h, i);
        }

        if (StartPosAI == col2row3)
        {
            if (f != 0)
            {
                cout << "That position has been filled, please choose another spot" << endl;
                AIGameCall(a, b, c, d, e, f, g, h, i, P1Turn, AITurn);
            }

            if (P1Turn == true)
            {
                cout << "Player 1 Turn ";
            }
            if (P2Turn == true)
            {
                cout << "Player 2 Turn ";
            }

            int number = rand() % 9 + 1;
            cout << "Insert a number to place in column 2, row 3 " << endl;

            while (number > 9 || number < 1)
            {
                cout << " Number has to be 1-9" << endl;

                cout << "Insert a number to place in column 2, row 3 " << endl;

                cin >> number;
            }
            /*
            while (number == a || b || c || d || e || f || g || h)
            {
                cout << "duplicate number has been found" << endl;

                cout << "Insert a number to place in column 2, row 3 " << endl;


                cin >> number;
            }
            */
            f = number;

            if (AITurn == true)
            {
                P1Turn = true;
                AITurn = false;
            }
            else if (P1Turn == true)
            {
                P1Turn = false;
                AITurn = true;
            }

            drawGrid(a, b, c, d, e, f, g, h, i);
        }

        if (StartPosAI == col3row1)
        {
            if (g != 0)
            {
                cout << "That position has been filled, please choose another spot" << endl;
                AIGameCall(a, b, c, d, e, f, g, h, i, P1Turn, AITurn);
            }

            if (P1Turn == true)
            {
                cout << "Player 1 Turn ";
            }

            int number = rand() % 9 + 1;
            cout << "Insert a number to place in column 3, row 1 " << endl;

            while (number > 9 || number < 1)
            {
                cout << " Number has to be 1-9" << endl;

                cout << "Insert a number to place in column 3, row 1 " << endl;

                cin >> number;
            }

            /*
            while (number == a || b || c || d || e || f || g || h)
            {
                cout << "duplicate number has been found" << endl;

                cout << "Insert a number to place in column 3, row 1 " << endl;


                cin >> number;
            }
            */
            g = number;

            if (AITurn == true)
            {
                P1Turn = true;
                AITurn = false;
            }
            else if (P1Turn == true)
            {
                P1Turn = false;
                AITurn = true;
            }

            drawGrid(a, b, c, d, e, f, g, h, i);
        }

        if (StartPosAI == col3row2)
        {
            if (h != 0)
            {
                cout << "That position has been filled, please choose another spot" << endl;
                AIGameCall(a, b, c, d, e, f, g, h, i, P1Turn, AITurn);
            }

            if (P1Turn == true)
            {
                cout << "Player 1 Turn ";
            }
            if (P2Turn == true)
            {
                cout << "Player 2 Turn ";
            }

            int number = rand() % 9 + 1;
            cout << "Insert a number to place in column 3, row 2 " << endl;

            while (number > 9 || number < 1)
            {
                cout << " Number has to be 1-9" << endl;

                cout << "Insert a number to place in column 3, row 2 " << endl;

                cin >> number;
            }

            /*
            while (number == a || b || c || d || e || f || g || h)
            {
                cout << "duplicate number has been found" << endl;

                cout << "Insert a number to place in column 3, row 2 " << endl;


                cin >> number;
            }
            */
            h = number;

            if (AITurn == true)
            {
                P1Turn = true;
                AITurn = false;
            }
            else if (P1Turn == true)
            {
                P1Turn = false;
                AITurn = true;
            }

            drawGrid(a, b, c, d, e, f, g, h, i);
        }

        if (StartPosAI == col3row3)
        {
            if (i != 0)
            {
                cout << "That position has been filled, please choose another spot" << endl;
                AIGameCall(a, b, c, d, e, f, g, h, i, P1Turn, AITurn);

            }
            if (P1Turn == true)
            {
                cout << "Player 1 Turn ";
            }
            if (AITurn == true)
            {
                cout << "AI's Turn ";
            }

            int number = rand() % 9 + 1;
            cout << "Insert a number to place in column 3, row 3 " << endl;

            while (number > 9 || number < 1)
            {
                cout << " Number has to be 1-9" << endl;

                cout << "Insert a number to place in column 3, row 3 " << endl;

                cin >> number;
            }

            /*
            while (number == a || b || c || d || e || f || g || h)
            {
                cout << "duplicate number has been found" << endl;

                cout << "Insert a number to place in column 3, row 3 " << endl;

                cin >> number;
            }
            */

            i = number;

            if (AITurn == true)
            {
                P1Turn = true;
                AITurn = false;
            }
            else if (P1Turn == true)
            {
                P1Turn = false;
                AITurn = true;
            }

            drawGrid(a, b, c, d, e, f, g, h, i);
        }

    }

    cout << "Pick a place to start ";
    cin >> StartPos;

    switch (StartPos)
    {
    case 11:
        cout << "Number entered";
        cout << " ";
        cout << StartPos << endl;
        break;
    case 12:
        cout << "Number entered";
        cout << " ";
        cout << StartPos << endl;
        break;
    case 13:
        cout << "Number entered";
        cout << " ";
        cout << StartPos << endl;
        break;
    case 21:
        cout << "Number entered";
        cout << " ";
        cout << StartPos << endl;
        break;
    case 22:
        cout << "Number entered";
        cout << " ";
        cout << StartPos << endl;
        break;
    case 23:
        cout << "Number entered";
        cout << " ";
        cout << StartPos << endl;
        break;
    case 31:
        cout << "Number entered";
        cout << " ";
        cout << StartPos << endl;
        break;
    case 32:
        cout << "Number entered";
        cout << " ";
        cout << StartPos << endl;
        break;
    case 33:
        cout << "Number entered";
        cout << " ";
        cout << StartPos << endl;
        break;

    default:
        cout << " Number has to be 1-9" << endl;
        cout << "Number entered";
        cout << " ";
        cout << StartPos << endl;

        AIGameCall(a, b, c, d, e, f, g, h, i, P1Turn, AITurn);
        break;
    }


    if (StartPos == col1row1)
    {
        if (a != 0)
        {
            cout << "That position has been filled, please choose another spot" << endl;
            AIGameCall(a, b, c, d, e, f, g, h, i, P1Turn, AITurn);

        }
        if (P1Turn == true)
        {
            cout << "Player 1 Turn ";
        }
        if (P2Turn == true)
        {
            cout << "Player 2 Turn ";
        }

        int number;
        cout << "Insert a number to place in column 1, row 1 ";
        cin >> number;
        while (number > 9 || number < 1)
        {
            cout << " Number has to be 1-9" << endl;

            cout << "Insert a number to place in column 1, row 1 ";

            cin >> number;
        }
        /*
        while (number == a || b || c || d || e || f || g || h)
        {
            cout << "duplicate number has been found" << endl;

            cout << "Insert a number to place in column 1, row 1 " << endl;

            cin >> number;
        }
        */
        a = number;

        if (AITurn == true)
        {
            P1Turn = true;
            AITurn = false;
        }
        else if (P1Turn == true)
        {
            P1Turn = false;
            AITurn = true;
        }

        drawGrid(a, b, c, d, e, f, g, h, i);
    }

    if (StartPos == col1row2)
    {
        if (b != 0)
        {
            cout << "That position has been filled, please choose another spot" << endl;
            AIGameCall(a, b, c, d, e, f, g, h, i, P1Turn, AITurn);

        }
        if (P1Turn == true)
        {
            cout << "Player 1 Turn ";
        }
        if (P2Turn == true)
        {
            cout << "Player 2 Turn ";
        }

        int number;
        cout << "Insert a number to place in column 1, row 2 ";
        cin >> number;

        while (number > 9 || number < 1)
        {
            cout << " Number has to be 1-9" << endl;

            cout << "Insert a number to place in column 1, row 2 ";

            cin >> number;
        }
        /*
        while (number == a || b || c || d || e || f || g || h)
        {
            cout << "duplicate number has been found" << endl;

            cout << "Insert a number to place in column 1, row 2 " << endl;


            cin >> number;
        }
        */
        b = number;

        if (AITurn == true)
        {
            P1Turn = true;
            AITurn = false;
        }
        else if (P1Turn == true)
        {
            P1Turn = false;
            AITurn = true;
        }

        drawGrid(a, b, c, d, e, f, g, h, i);
    }

    if (StartPos == col1row3)
    {
        if (c != 0)
        {
            cout << "That position has been filled, please choose another spot" << endl;
            AIGameCall(a, b, c, d, e, f, g, h, i, P1Turn, AITurn);
        }

        if (P1Turn == true)
        {
            cout << "Player 1 Turn ";
        }
        if (P2Turn == true)
        {
            cout << "Player 2 Turn ";
        }

        int number;
        cout << "Insert a number to place in column 1, row 3 ";
        cin >> number;

        while (number > 9 || number < 1)
        {
            cout << " Number has to be 1-9" << endl;

            cout << "Insert a number to place in column 1, row 3 ";

            cin >> number;
        }
        /*
        while (number == a || b || c || d || e || f || g || h)
        {
            cout << "duplicate number has been found" << endl;

            cout << "Insert a number to place in column 1, row 3 " << endl;


            cin >> number;
        }
        */

        c = number;

        if (AITurn == true)
        {
            P1Turn = true;
            AITurn = false;
        }
        else if (P1Turn == true)
        {
            P1Turn = false;
            AITurn = true;
        }

        drawGrid(a, b, c, d, e, f, g, h, i);
    }

    if (StartPos == col2row1)
    {
        if (d != 0)
        {
            cout << "That position has been filled, please choose another spot" << endl;
            AIGameCall(a, b, c, d, e, f, g, h, i, P1Turn, AITurn);
        }

        if (P1Turn == true)
        {
            cout << "Player 1 Turn ";
        }
        if (P2Turn == true)
        {
            cout << "Player 2 Turn ";
        }

        int number;
        cout << "Insert a number to place in column 2, row 1 ";
        cin >> number;

        while (number > 9 || number < 1)
        {
            cout << " Number has to be 1-9" << endl;

            cout << "Insert a number to place in column 2, row 1 ";

            cin >> number;
        }

        /*
        while (number == a || b || c || d || e || f || g || h)
        {
            cout << "duplicate number has been found" << endl;

            cout << "Insert a number to place in column 2, row 1 " << endl;


            cin >> number;
        }
        */
        d = number;

        if (AITurn == true)
        {
            P1Turn = true;
            AITurn = false;
        }
        else if (P1Turn == true)
        {
            P1Turn = false;
            AITurn = true;
        }

        drawGrid(a, b, c, d, e, f, g, h, i);
    }

    if (StartPos == col2row2)
    {
        if (e != 0)
        {
            cout << "That position has been filled, please choose another spot" << endl;
            AIGameCall(a, b, c, d, e, f, g, h, i, P1Turn, AITurn);
        }

        if (P1Turn == true)
        {
            cout << "Player 1 Turn ";
        }
        if (P2Turn == true)
        {
            cout << "Player 2 Turn ";
        }

        int number;
        cout << "Insert a number to place in column 2, row 2 ";
        cin >> number;

        while (number > 9 || number < 1)
        {
            cout << " Number has to be 1-9" << endl;

            cout << "Insert a number to place in column 2, row 2 ";

            cin >> number;
        }
        /*
        while (number == a || b || c || d || e || f || g || h)
        {
            cout << "duplicate number has been found" << endl;

            cout << "Insert a number to place in column 2, row 2 " << endl;


            cin >> number;
        }
        */
        e = number;

        if (AITurn == true)
        {
            P1Turn = true;
            AITurn = false;
        }
        else if (P1Turn == true)
        {
            P1Turn = false;
            AITurn = true;
        }

        drawGrid(a, b, c, d, e, f, g, h, i);
    }

    if (StartPos == col2row3)
    {
        if (f != 0)
        {
            cout << "That position has been filled, please choose another spot" << endl;
            AIGameCall(a, b, c, d, e, f, g, h, i, P1Turn, AITurn);
        }

        if (P1Turn == true)
        {
            cout << "Player 1 Turn ";
        }
        if (P2Turn == true)
        {
            cout << "Player 2 Turn ";
        }

        int number;
        cout << "Insert a number to place in column 2, row 3 ";
        cin >> number;

        while (number > 9 || number < 1)
        {
            cout << " Number has to be 1-9" << endl;

            cout << "Insert a number to place in column 2, row 3 ";

            cin >> number;
        }
        /*
        while (number == a || b || c || d || e || f || g || h)
        {
            cout << "duplicate number has been found" << endl;

            cout << "Insert a number to place in column 2, row 3 " << endl;


            cin >> number;
        }
        */
        f = number;

        if (AITurn == true)
        {
            P1Turn = true;
            AITurn = false;
        }
        else if (P1Turn == true)
        {
            P1Turn = false;
            AITurn = true;
        }

        drawGrid(a, b, c, d, e, f, g, h, i);
    }

    if (StartPos == col3row1)
    {
        if (g != 0)
        {
            cout << "That position has been filled, please choose another spot" << endl;
            AIGameCall(a, b, c, d, e, f, g, h, i, P1Turn, AITurn);

        }
        if (P1Turn == true)
        {
            cout << "Player 1 Turn ";
        }

        int number;
        cout << "Insert a number to place in column 3, row 1 ";
        cin >> number;

        while (number > 9 || number < 1)
        {
            cout << " Number has to be 1-9" << endl;

            cout << "Insert a number to place in column 3, row 1 ";

            cin >> number;
        }

        /*
        while (number == a || b || c || d || e || f || g || h)
        {
            cout << "duplicate number has been found" << endl;

            cout << "Insert a number to place in column 3, row 1 " << endl;


            cin >> number;
        }
        */
        g = number;

        if (AITurn == true)
        {
            P1Turn = true;
            AITurn = false;
        }
        else if (P1Turn == true)
        {
            P1Turn = false;
            AITurn = true;
        }

        drawGrid(a, b, c, d, e, f, g, h, i);
    }

    if (StartPos == col3row2)
    {
        if (h != 0)
        {
            cout << "That position has been filled, please choose another spot" << endl;
            AIGameCall(a, b, c, d, e, f, g, h, i, P1Turn, AITurn);
        }

        if (P1Turn == true)
        {
            cout << "Player 1 Turn ";
        }
        if (P2Turn == true)
        {
            cout << "Player 2 Turn ";
        }

        int number;
        cout << "Insert a number to place in column 3, row 2 ";
        cin >> number;

        while (number > 9 || number < 1)
        {
            cout << " Number has to be 1-9" << endl;

            cout << "Insert a number to place in column 3, row 2 ";

            cin >> number;
        }

        /*
        while (number == a || b || c || d || e || f || g || h)
        {
            cout << "duplicate number has been found" << endl;

            cout << "Insert a number to place in column 3, row 2 " << endl;


            cin >> number;
        }
        */
        h = number;

        if (AITurn == true)
        {
            P1Turn = true;
            AITurn = false;
        }
        else if (P1Turn == true)
        {
            P1Turn = false;
            AITurn = true;
        }

        drawGrid(a, b, c, d, e, f, g, h, i);
    }

    if (StartPos == col3row3)
    {
        if (i != 0)
        {
            cout << "That position has been filled, please choose another spot" << endl;
            AIGameCall(a, b, c, d, e, f, g, h, i, P1Turn, AITurn);

        }
        if (P1Turn == true)
        {
            cout << "Player 1 Turn ";
        }
        if (AITurn == true)
        {
            cout << "AI's Turn ";
        }

        int number;
        cout << "Insert a number to place in column 3, row 3 ";
        cin >> number;

        while (number > 9 || number < 1)
        {
            cout << " Number has to be 1-9" << endl;

            cout << "Insert a number to place in column 3, row 3 ";

            cin >> number;
        }

        /*
        while (number == a || b || c || d || e || f || g || h)
        {
            cout << "duplicate number has been found" << endl;

            cout << "Insert a number to place in column 3, row 3 " << endl;

            cin >> number;
        }
        */

        i = number;

        if (AITurn == true)
        {
            P1Turn = true;
            AITurn = false;
        }
        else if (P1Turn == true)
        {
            P1Turn = false;
            AITurn = true;
        }

        drawGrid(a, b, c, d, e, f, g, h, i);
    }
}