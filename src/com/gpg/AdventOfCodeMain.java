package com.gpg;

import java.io.*;
import java.util.ArrayList;

import com.gpg.puzzles.*;

import static com.gpg.util.ArgUtil.*;
import static com.gpg.util.Logging.fail;

/**
 *  Advent Of Code 2018 : http://adventofcode.com/2018/
 *  Main class for the solver application.
 */
public class AdventOfCodeMain {

    // To use the example.dat file, add this cmd arg :  --inputFile=resources\example.dat

    private static final String USAGE = "--puzzle=[pz] [--inputFile=[puzzle.dat]]";

    public static void main(String[] args) {
        int runPuzzle = getPuzzleRequest(args);

        if (runPuzzle < 0) {
            fail("You must specify a puzzle number to run.", null);
        }

        String fileName = getInputFileName(args);

        if (fileName == null || fileName.isEmpty()) {
            fileName = String.format("..\\resources\\puzzle%d.dat", runPuzzle);
        }

        ArrayList<String> inputData = getInputFileData(fileName);

        Solver solver = getPuzzleSolver(runPuzzle);

        if (solver == null) {
            System.out.println(String.format("No solver was found for puzzle %d", runPuzzle));
        }
        else {
            solver.Solve(inputData);
        }

        System.out.println("All puzzle solving is complete.");
    }

    private static String getInputFileName(String[] args) {

        String fileName = "";
        try {
            fileName = getArgument("inputFile", args);
        }
        catch (MissingArgumentException e) {
            // NO-OP
        }
        catch (IllegalArgumentException e) {
            fail(USAGE, e);
        }

        return fileName;
    }
    private static ArrayList<String> getInputFileData(String fileName) {

        ArrayList<String> lst = new ArrayList<String>();

        try {
            if (fileName != null && !fileName.equals("")) {
               BufferedReader br = new BufferedReader(new FileReader(fileName));
               String currentLine;

               while ((currentLine = br.readLine()) != null) {
                   lst.add(currentLine);
               }
            }
        }
        catch (FileNotFoundException e) {
            fail(USAGE, e);
        }
        catch (IOException e) {
            fail(USAGE, e);
        }

        return lst;
    }

    private static int getPuzzleRequest(String[] args) {
        String puzzleStr;
        try {
            puzzleStr = getArgument("puzzle", args);

            if(puzzleStr.isEmpty()) {
                return -1;
            }

            return Integer.parseInt(puzzleStr);
        }
        catch (NumberFormatException e) {
            fail("The puzzle argument must be an integer!", e);
        }
        catch (MissingArgumentException e) {
            return 0;
        }
        catch (IllegalArgumentException e) {
            fail(USAGE, e);
        }

        return 0;
    }

    private static Solver getPuzzleSolver(int runPuzzle) {

        switch (runPuzzle) {
            case 1:
                return new Solver(new Puzzle1A(), new Puzzle1B());
            case 2:
                return new Solver(new Puzzle2A(), new Puzzle2B());
            case 3:
                return new Solver(new Puzzle3A(), null);
        }

        return null;
    }
}
