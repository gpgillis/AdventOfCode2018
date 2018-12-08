package com.gpg.puzzles;

import java.util.ArrayList;
import java.util.TreeSet;

/**
 Advent Of Code Puzzle 5B :
 http://adventofcode.com/2018/day/5

 --- Day 5: Alchemical Reduction ---

 --- Part Two ---
 Time to improve the polymer.

 One of the unit types is causing problems; it's preventing the polymer from collapsing as much as it should. Your goal is to figure out which unit type is causing the most problems, remove all instances of it (regardless of polarity), fully react the remaining polymer, and measure its length.

 For example, again using the polymer dabAcCaCBAcCcaDA from above:

 Removing all A/a units produces dbcCCBcCcD. Fully reacting this polymer produces dbCBcD, which has length 6.
 Removing all B/b units produces daAcCaCAcCcaDA. Fully reacting this polymer produces daCAcaDA, which has length 8.
 Removing all C/c units produces dabAaBAaDA. Fully reacting this polymer produces daDA, which has length 4.
 Removing all D/d units produces abAcCaCBAcCcaA. Fully reacting this polymer produces abCBAc, which has length 6.
 In this example, removing all C/c units was best, producing the answer 4.

 What is the length of the shortest polymer you can produce by removing all units of exactly one type and fully reacting the result?

 Although it hasn't changed, you can still get your puzzle inp

 The correct answer 5898 is with puzzle5.dat

 */
public class Puzzle5B extends Puzzle5Base {
    protected void SolveMe(ArrayList<String> inputData) {

        System.out.println("Finding the individual unit types contained.");

        TreeSet<Character> unitTypes = new TreeSet<Character>();

        for (char c : inputData.get(0).toCharArray()) {
            c = Character.toUpperCase(c);
            unitTypes.add(c);
        }

        int smallestPolymerSize = inputData.get(0).length();

        for (char unit : unitTypes) {
            if (printMessages) {
                System.out.println("Source: " + inputData.get(0));
                System.out.println("Removing " + unit);
            }

            String test = inputData.get(0).replace(Character.toString(unit), "");
            test = test.replace(Character.toString(unit).toLowerCase(), "");

            if (printMessages)
                System.out.println("Test: " + test);

            int result = React(test);

            if (result < smallestPolymerSize)
                smallestPolymerSize = result;

            if (printMessages)
                System.out.println(String.format("Result = %d : smallest = %d", result, smallestPolymerSize));
        }

        System.out.println(String.format("There are %d different unit types.", unitTypes.size()));
        System.out.println("The smallest polymer size is " + smallestPolymerSize);
    }
}
