// BalancedParantheses.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <sstream>
#include <stack>
using namespace std;

int main()
{
	//((
	string input;
	getline(cin >> ws, input);
	stack<char> openParanthesses;
	istringstream ss(input);
	if (ss.gcount() %2 !=0) {
		cout << "No";
		return 0;
	}
	char c;
	char previousC;
	bool balanced = true;
	while (ss >> c) {

		if (c == '('
			|| c == '{'
			|| c == '[') {
			openParanthesses.push(c);
		}

		else if (openParanthesses.empty()) {
			balanced = false;
			break;
		}
		else if (c == ')') {
			if (openParanthesses.top() != '(') {
				break;
			}
			openParanthesses.pop();
		}
		else if (c == ']') {
			if (openParanthesses.top() != '[') {
				break;
			}
			openParanthesses.pop();
		}
		else if (c == '}') {
			if (openParanthesses.top() != '{') {
				break;
			}
			openParanthesses.pop();
		}
	}
	if (balanced && openParanthesses.empty()) {
		cout << "YES";
	}
	else {
		cout << "NO";
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
