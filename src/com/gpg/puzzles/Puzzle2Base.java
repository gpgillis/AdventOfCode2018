package com.gpg.puzzles;

import java.util.ArrayList;

/**
 Advent Of Code Puzzle 2 Base:
 http://adventofcode.com/2018/day/2
 */
public abstract class Puzzle2Base extends PuzzleBase {

    protected boolean DataIsValid(ArrayList<String> inputData) {
        return ValidateMultiLineDataFile(inputData);
    }

}
