package com.gpg.puzzles;

import java.util.ArrayList;
import java.util.List;

/**
 * A base class for each puzzle solver.
 */
public abstract class PuzzleBase {

    public void SolvePuzzle(ArrayList<String> inputData) {
        System.out.println(String.format("\nSolving Puzzle %s ...", this.getClass().getSimpleName()));

        if (!DataIsValid(inputData))
            return;

        SolveMe(inputData);

        System.out.println("Complete");
    }

    protected abstract boolean DataIsValid(ArrayList<String> inputData);
    protected abstract void SolveMe(ArrayList<String> inputData);

    protected boolean ValidateSingleLineDataFile(List<String> inputData) {
        if (inputData.size() != 1) {
            System.out.println("Incorrect input data - The input data should be a single line of text.");
            return false;
        }
        return true;
    }

    boolean ValidateMultiLineDataFile(List<String> inputData) {
        if (inputData.size() == 0) {
            System.out.println("Incorrect input data - The input data should be one or more lines of text.");
            return false;
        }
        return true;
    }

    static Boolean isStringNullOrEmpty(String test) {
        return test == null || test.trim().isEmpty();
    }
}
