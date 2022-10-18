# Code-Challenge

This repository consists of code challenge/test of Sudoku Validator and Solver.
This test is mainly divided into two tasks out of which I choose to work on Task-1 with an added bonus functionality in C# language. 

Below is the environmental setup which is used to code and execute this challenge.
1. IDE/Code editor- VS Code x64 1.69.1
2. .Net and C# downloads- C# & C# Extensions

In order to solve the task, a method named validateboard has been modeled, in which sudoku board in the form of 2d array is accepted and validated based on the most important games rules and then accordingly a boolean value is returned.
The game and task rules are mentioned as follows:
1. The board may not have empty spaces('0'), i.e each cell must be filled with a number between 1-9.
2. Each cell in a row is filled with a number between 1-9 such that the number occurs only one time in every row.
3. Each cell in a column is filled with a number between 1-9 such that the number occurs only one time in every column.
4. Each cell in a subgrid (3*3) is filled with a number between 1-9 such that the number occurs only one time in every subgrid.

***Please read the comments in the code carefully to comprehend easily***



