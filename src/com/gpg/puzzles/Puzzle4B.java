package com.gpg.puzzles;

import java.util.Map;
import com.gpg.puzzles.Puzzle4Base;

/**
 Advent Of Code Puzzle 4A:
 http://adventofcode.com/2018/day/4

 --- Day 4: Repose Record ---

 --- Part Two ---
    Strategy 2: Of all guards, which guard is most frequently asleep on the same minute?

    In the example above, Guard #99 spent minute 45 asleep more than any other guard or minute - three times in total. (In all other cases, any guard spent any minute asleep at most twice.)

    What is the ID of the guard you chose multiplied by the minute you chose? (In the above example, the answer would be 99 * 45 = 4455.)

 The correct answer is with puzzle4.dat

 */
public class Puzzle4B {

    // Solving using data processed from Part A instead of processing as a separate solver.
    public void SolveMe(Map<String, Integer[]> data) {
        System.out.println(String.format("\nSolving Puzzle %s ...", this.getClass().getSimpleName()));

        String maxSleepMinuteGuardId = "";
        Integer maxSleepMinuteCount = -1;
        Integer maxSleepMinuteIndex = -1;


        for (String k : data.keySet()) {

            Integer maxIdx = Puzzle4Base.indexOfLargestValue(data.get(k));
            Integer maxMin = data.get(k)[maxIdx];
            if (maxMin > maxSleepMinuteCount) {
                maxSleepMinuteIndex = maxIdx;
                maxSleepMinuteCount = maxMin;
                maxSleepMinuteGuardId = k;
            }
        }

        System.out.println(String.format("GuardId %s was asleep the most at minute %d with %d counts.", maxSleepMinuteGuardId, maxSleepMinuteIndex, maxSleepMinuteCount));

        Long answerCheckSum = Long.parseLong(maxSleepMinuteGuardId.replace("#", "")) * maxSleepMinuteIndex;
        System.out.println(String.format("The answer checksum is %d", answerCheckSum));
    }
}
