package com.gpg.puzzles;

import java.util.ArrayList;

/**
 Advent Of Code Puzzle 5A :
 http://adventofcode.com/2018/day/5

 --- Day 5: Alchemical Reduction ---
 You've managed to sneak in to the prototype suit manufacturing lab. The Elves are making decent progress, but are still struggling with the suit's size reduction capabilities.

 While the very latest in 1518 alchemical technology might have solved their problem eventually, you can do better. You scan the chemical composition of the suit's material and discover that it is formed by extremely long polymers (one of which is available as your puzzle input).

 The polymer is formed by smaller units which, when triggered, react with each other such that two adjacent units of the same type and opposite polarity are destroyed. Units' types are represented by letters; units' polarity is represented by capitalization. For instance, r and R are units with the same type but opposite polarity, whereas r and s are entirely different types and do not react.

 For example:

 In aA, a and A react, leaving nothing behind.
 In abBA, bB destroys itself, leaving aA. As above, this then destroys itself, leaving nothing.
 In abAB, no two adjacent units are of the same type, and so nothing happens.
 In aabAAB, even though aa and AA are of the same type, their polarities match, and so nothing happens.
 Now, consider a larger example, dabAcCaCBAcCcaDA:

 dabAcCaCBAcCcaDA  The first 'cC' is removed.
 dabAaCBAcCcaDA    This creates 'Aa', which is removed.
 dabCBAcCcaDA      Either 'cC' or 'Cc' are removed (the result is the same).
 dabCBAcaDA        No further actions can be taken.
 After all possible reactions, the resulting polymer contains 10 units.

 How many units remain after fully reacting the polymer you scanned? (Note: in this puzzle and others, the input is large; if you copy/paste your input, make sure you get the whole thing.)

 The correct answer is 9390 with puzzle5.dat

 */
public class Puzzle5A extends Puzzle5Base {
    protected void SolveMe(ArrayList<String> inputData) {
        int remainingUnits = React(inputData.get(0));
        System.out.println(String.format("\n\nThere are %d units left", remainingUnits));
    }
}
