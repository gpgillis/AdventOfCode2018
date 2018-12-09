package com.gpg.puzzles;

import java.util.ArrayList;

/**
 Advent Of Code Puzzle 6 BASE:
 http://adventofcode.com/2018/day/6


 The correct answer is with puzzle .dat

 */
public abstract class Puzzle6Base extends PuzzleBase {
    protected boolean DataIsValid(ArrayList<String> inputData) {
       return ValidateMultiLineDataFile(inputData);
    }

}
