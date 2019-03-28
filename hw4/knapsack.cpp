#include <iostream>

using namespace std;

int d(int n, int v[], int w[]);
int f(int n, int v[], int w[]);


int main() {
  char algChoice;
  cin >> algChoice;

  int capacity;
  cin >> capacity;

  int numItems;
  cin >> numItems;

  int weights[numItems];
  int costs[numItems];

  for (int i = 0; i < numItems; i++) {
    cin >> weights[i];
    cin >> costs[i];
  }
  return 0;
}

int d(int n, int v[], int w[]) {

}

int f(int n, int v[], int w[]) {

}
