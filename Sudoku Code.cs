// See https://aka.ms/new-console-template for more information
using System;
public class Sudoku {

//TASK 1
//Method to validate game rules(row wise rule, column wise rule and grid wise rule) 
    public static bool validateBoard(int[,] board) {
        for (int i = 0; i < 9 ; i++) {       
            for (int j = 0; j < 9; j++) {      
                if (!isValidInRow(board, i, j,j+1)) { 
                    return false;
                } else if (!isValidInColumn(board, i, j, i+1)) {
                    return false;
                } else if (!isValidInGrid(board, i, j)) {
                    return false;
                }

            }
        }
        return true;
    }
    //validates 3*3 grids of the given row and column
    private static bool isValidInGrid(int[,] board, int row, int column) {
        int gridRowMin = (row / 3) * 3;//start of first row cell in a 3*3 grid
        int gridRowMax = gridRowMin + 2 ;//end of last row cell in a 3*3 grid
        int gridColMin = (column / 3) * 3;//start of first column cell in 3*3 grid
        int gridColMax = gridColMin + 2 ;//end of last column cell in 3*3 grid
        int element = board[row,column];
        for (int i = gridRowMin; i < gridRowMax; i++) {
            if (i == row)
                continue;
            for (int j = gridColMin; j < gridColMax; j++) {
                if (j == column)
                    continue;
                if (board[i,j] == element) {//validating the current element with the other elements in the grid 
                    return false;
                }
            }
        }
        return true;
    }
    //validates the given row, column element in the whole column from the given start value 
    private static bool isValidInColumn(int[,]board, int row, int column,int start) {
        int element = board[row,column];
        if (element <= 0 || element > 9) {
            return false;
        }
        for (int i = start; i < 9; i++) {
            if(i==row){
                continue;
            }
            if (board [i,column] == element) {//validating the current element with the other elements in the given column
                return false;
            }
        }
        return true;
    }
//validates the given row, column element in the whole row from the given start value 
    private static bool isValidInRow(int[,] board, int row, int column,int start) { 
        int element = board[row,column];
        if (element <= 0 || element > 9) {
            return false;
        }
        for (int i = start; i < 9; i++) {
            if(i==column)
            {
                continue;
            }
            if (board [row,i] == element) {//validating the current element with the other elements in the given row
                return false;
            }
        }
        return true;
    }
//Generates the complete sudoku board based on the game rules 
    public static int[,] generateSudokuBoard(int[,] inputBoard) {

        for (int i = 0; i < 9; i++) {
            for (int j = 0; j < 9; j++) {
                if (inputBoard[i,j] < 1 || inputBoard[i,j] > 9) {
                    for (int k = 1 ; k <= 9 ; k++) {
                        inputBoard[i,j] = k;
                        if (!isValidInRow(inputBoard, i, j, 0)) {
                            continue;
                        } else if (!isValidInColumn(inputBoard, i, j, 0)) {
                            continue;
                        } else if (!isValidInGrid(inputBoard, i, j)) {
                            continue;
                        }
                        break;
                    }
                }
            }
        }
        return inputBoard;
    }


    //TASK 1 TESTCASE-1
    public static void Main(string[] args){
        int[,] board = new int[9,9]{
                {4, 3, 5, 2, 6, 9, 7, 8, 1},
                {6, 8, 2, 5, 7, 1, 4, 9, 3},
                {1, 9, 7, 8, 3, 4, 5, 6, 2},
                {8, 2, 6, 1, 9, 5, 3, 4, 7},
                {3, 7, 4, 6, 8, 2, 9, 1, 5},
                {9, 5, 1, 7, 4, 3, 6, 2, 8},
                {5, 1, 9, 3, 2, 6, 8, 7, 4},
                {2, 4, 8, 9, 5, 7, 1, 3, 6},
                {7, 6, 3, 4, 1, 8, 2, 5, 9}};
        Console.WriteLine("Given Board valid:"+validateBoard(board));

    //TASK 1 TESTCASE-2

        int[,] board2 = new int[9,9]{
                {7, 9, 2, 1, 5, 4, 3, 8, 6},
                {6, 4, 3, 8, 2, 7, 1, 5, 9},
                {8, 5, 1, 3, 9, 6, 7, 2, 4},
                {2, 6, 5, 9, 7, 3, 8, 4, 1},
                {4, 8, 9, 5, 6, 1, 2, 7, 3},
                {3, 1, 7, 4, 8, 2, 9, 6, 5},
                {1, 3, 6, 7, 4, 8, 5, 9, 2},
                {9, 7, 4, 2, 1, 5, 6, 3, 8},
                {5, 2, 8, 6, 3, 9, 4, 1, 7}};
        Console.WriteLine("Given Board valid:"+validateBoard(board2));

    //TASK 1 TESTCASE-3

        int[,] board3_invalid = new int[9,9]{
                {7, 9, 2, 1, 5, 4, 3, 8, 6},
                {6, 4, 3, 8, 2, 7, 1, 5, 9},
                {8, 5, 1, 3, 9, 6, 7, 2, 4},
                {2, 6, 5, 9, 7, 3, 8, 4, 1},
                {4, 8, 9, 5, 6, 1, 2, 7, 3},
                {3, 1, 7, 4, 8, 2, 8, 6, 5},
                {1, 3, 6, 7, 4, 8, 9, 9, 2},
                {9, 7, 4, 2, 1, 5, 6, 3, 8},
                {5, 2, 8, 6, 3, 9, 4, 1, 7}};
        Console.WriteLine("Given Board valid:"+validateBoard(board3_invalid));
    
    //TASK 1 TESTCASE-4

        int[,] board4_with_zero = new int[9,9] {
                {7, 9, 2, 1, 5, 4, 3, 8, 6},
                {6, 4, 0, 8, 2, 7, 1, 5, 9},
                {8, 5, 1, 3, 9, 6, 7, 2, 4},
                {2, 6, 5, 9, 7, 3, 8, 4, 1},
                {4, 8, 9, 5, 6, 1, 2, 7, 3},
                {3, 1, 7, 4, 8, 2, 0, 6, 5},
                {1, 3, 6, 7, 4, 8, 9, 9, 2},
                {9, 7, 4, 2, 1, 5, 6, 3, 8},
                {5, 2, 8, 6, 3, 9, 4, 1, 7}};
        Console.WriteLine("Given Board valid:"+validateBoard(board4_with_zero));

    //TASK 1 TESTCASE-5

        int[,] board5_with_negatives = new int[9,9] {
                {7, 9, 2, 1, 5, 4, 3, 8, 6},
                {6, 4, 0, 8, 2, 7, 1, 5, 9},
                {8, 5, 1, -3, 9, 6, 7, 2, 4},
                {2, 6, 5, 9, 7, 3, 8, 4, 1},
                {4, 8, 9, 5, 6, 1, 2, 7, 3},
                {3, 1, 7, 4, 8, 2, 0, 6, 5},
                {1, 3, 6, 7, 4, 8, 9, 9, 2},
                {9, 7, 4, 2, 1, -5, 6, 3, 8},
                {5, 2, 8, 6, 3, 9, 4, 1, 7}};
        Console.WriteLine("Given Board valid:"+validateBoard(board5_with_negatives));

    //TASK 1 TESTCASE-6

        int[,] empty_sudoku_board6 = new int[9,9] {
                {0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0}};
        Console.WriteLine("Given Board valid:"+validateBoard(empty_sudoku_board6));

    //BONUS TASK
    //For Bonus points, the functionality is expanded wherein generateSudokuBoard method generates a valid sudoku board solution 
    //while accepting an incomplete sudoku board(board with empty spaces) as an input.

    //TEST CASE-1 
     
        int[,] input_board = new int[9,9] {
                {7, 9, 2, 1, 5, 4, 3, 8, 6},
                {6, 4, 3, 8, 2, 7, 1, 0, 9},
                {0, 5, 1, 3, 0, 6, 7, 2, 4},
                {2, 6, 5, 9, 7, 3, 8, 4, 1},
                {0, 8, 9, 5, 6, 1, 2, 7, 3},
                {3, 1, 7, 4, 8, 2, 9, 6, 5},
                {1, 3, 6, 0, 4, 8, 5, 9, 2},
                {9, 7, 4, 2, 1, 5, 6, 0, 8},
                {5, 2, 8, 0, 3, 9, 4, 1, 7}};
        input_board = generateSudokuBoard(input_board);

        for (int i=0; i<9; i++) {
            for (int j=0; j<9; j++) {
                Console.Write(input_board[i,j]+" ");
            }
            Console.WriteLine("");
        }
        Console.WriteLine("");

        //TEST CASE-2

        int[,] input_board2 = new int[9,9] {
                {3, 1, 6, 5, 7, 8, 4, 9, 2},
                {5, 2, 9, 1, 3, 4, 7, 6, 8},
                {4, 8, 7, 6, 2, 9, 5, 3, 1},
                {2, 6, 3, 0, 1, 5, 9, 8, 7},
                {9, 7, 4, 8, 6, 0, 1, 2, 5},
                {8, 5, 1, 7, 9, 2, 6, 4, 3},
                {1, 3, 8, 0, 4, 7, 2, 0, 6},
                {6, 9, 2, 3, 5, 1, 8, 7, 4},
                {7, 4, 5, 0, 8, 6, 3, 1, 0}};
        input_board = generateSudokuBoard(input_board2);

        for (int i=0; i<9; i++) {
            for (int j=0; j<9; j++) {
                Console.Write(input_board2[i,j]+" ");
            }
            Console.WriteLine("");
        }
        Console.WriteLine("");

    }
}

