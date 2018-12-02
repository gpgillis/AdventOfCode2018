package com.gpg.puzzles;

import java.util.ArrayList;
import java.util.List;

/**
     Advent Of Code Puzzle 1 Base:
     http://adventofcode.com/2018/day/1
 */
public abstract class Puzzle1Base extends PuzzleBase {

    protected List<Integer> shiftData;

    protected boolean DataIsValid(ArrayList<String> inputData) {
        return ValidateMultiLineDataFile(inputData);
    }

    protected void LoadShiftData(List<String> inputData) {
        shiftData = new ArrayList<Integer>(inputData.size());
        for (String v : inputData) {
            v = v.trim();
            if (v.startsWith("+")) {
                v = v.replace("+", "");
            }

            shiftData.add(Integer.parseInt(v));
        }
    }

    protected Integer CalculateFrequencyShift(Integer frequency, Integer shiftVal) {

        return frequency + shiftVal;
    }

}
