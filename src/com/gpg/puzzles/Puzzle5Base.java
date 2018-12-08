package com.gpg.puzzles;

import java.util.ArrayList;

/**
 Advent Of Code Puzzle 5 Base :
 http://adventofcode.com/2018/day/5

 */
public abstract class Puzzle5Base extends PuzzleBase {

    protected boolean DataIsValid(ArrayList<String> inputData) {
        return ValidateSingleLineDataFile(inputData);
    }

    protected int React(String input) {
        int totalRemoved = 0;

        if (input.length() == 0)
            return totalRemoved;


        if (printMessages)
            System.out.println("Reacting:");

        StringBuilder source = new StringBuilder(input);
        int passNum = 0;
        int removedThisPass;

        do {
            removedThisPass = 0;
            System.out.println("   Pass #" + ++passNum);

            for (Integer i = 0; i + 2 <= source.length(); i++) {

                int removed = testReactionAndRemove(source, i);
                removedThisPass += removed;

                if (printMessages)
                    System.out.println(String.format("SLVM: '%s' : %d - %d", source, i, source.length()));

                if (removed > 0) {  // Since units were removed, restart reaction at the beginning of the chain.
                    i = 0;
                }
            }

            totalRemoved += removedThisPass;

        } while (removedThisPass> 0 && source.length() > 0);

        if (printMessages)
            System.out.println(String.format("Removed %d units", totalRemoved));

        return source.length();
    }

    private  static Boolean testReaction(char a, char b) {
        return (Character.toLowerCase(a) == Character.toLowerCase(b) && a != b);
    }

    private static char[] getTestCharacters(StringBuilder data, Integer idx) throws IllegalArgumentException {

        if (idx >= data.length() || idx < 0) {
            return null;
        }

        return (idx == data.length() - 1)
                ? data.substring(idx).toCharArray()
                : data.substring(idx, idx + 2).toCharArray();
    }

    private static int testReactionAndRemove(StringBuilder sb, Integer idx) {

        int removed = 0;

        char[] test = getTestCharacters(sb, idx);

        if (test == null || test.length != 2)
            return removed;

        if (testReaction(test[0], test[1])) {
            sb.deleteCharAt(idx + 1);
            sb.deleteCharAt(idx);
            removed += 2;
            if (printMessages)
                System.out.println(String.format("TRRF: '%s' : %d - %d", sb, idx, sb.length()));
        }

        // If there is a previous character, test reaction with character now at idx.
        if (idx > 0) {
            test = getTestCharacters(sb, idx - 1);

            if (test == null || test.length != 2)
                return removed;

            if (testReaction(test[0], test[1])) {
                sb.deleteCharAt(idx);
                sb.deleteCharAt(idx - 1);
                removed += 2;
                if (printMessages)
                    System.out.println(String.format("TRRB: '%s' : %d - %d", sb, idx, sb.length()));
            }
        }

        if (removed > 0) {
            removed += testReactionAndRemove(sb, idx);
        }

        return removed;
    }
}
