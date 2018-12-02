package com.gpg.puzzles;

import java.util.ArrayList;

/**
 Advent Of Code Puzzle 2 B:
 http://adventofcode.com/2018/day/2

 --- Day 2: Inventory Management System ---

 --- Part Two ---
 Confident that your list of box IDs is complete, you're ready to find the boxes full of prototype fabric.

 The boxes will have IDs which differ by exactly one character at the same position in both strings.
 For example, given the following box IDs:

 abcde
 fghij
 klmno
 pqrst
 fguij
 axcye
 wvxyz

 The IDs abcde and axcye are close, but they differ by two characters (the second and fourth).
 However, the IDs fghij and fguij differ by exactly one character, the third (h and u).
 Those must be the correct boxes.

 What letters are common between the two correct box IDs? (In the example above, this is found by
 removing the differing character from either ID, producing fgij.)

 */
public class Puzzle2B extends Puzzle2Base {

    protected void SolveMe(ArrayList<String> inputData) {
        String test = "";
        String match = "";

        for (Integer i = 0; i < inputData.size(); i++) {
            test = inputData.get(i);

            for (Integer j = 0; j < inputData.size(); j++) {
                if (j == i) {
                    continue;
                }

                String check = inputData.get(j);

                Integer diff = 0;

                for (Integer k = 0; k < test.length(); k++) {
                    if (test.charAt(k) != check.charAt(k)) {
                        diff++;
                    }
                    if (diff > 1) {
                        break;
                    }
                }

                if (diff == 1) {
                    for (Integer k = 0; k < test.length(); k++) {
                        if (test.charAt(k) == check.charAt(k)) {
                            match+=test.charAt(k);
                        }
                    }

                    System.out.println(String.format("Test = %s, Check = %s, Match = %s", test, check, match));
                    return;
                }
            }
        }

        System.out.println("If we got here we failed to find a match");
    }
}
