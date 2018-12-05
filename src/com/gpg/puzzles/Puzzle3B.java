package com.gpg.puzzles;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

/**
 Advent Of Code Puzzle 3B :
 http://adventofcode.com/2018/day/3

 --- Part Two ---
 Amidst the chaos, you notice that exactly one claim doesn't overlap by even a single square inch of
 fabric with any other claim. If you can somehow draw attention to it, maybe the Elves will be able
 to make Santa's suit after all!

 For example, in the claims above, only claim 3 is intact after all claims are made.

 What is the ID of the only claim that doesn't overlap?

 The correct answer is 275 with puzzle3.dat

 */
class Puzzle3B
{
    // Solving using data processed from Part A instead of processing as a separate solver.
    void SolveMe(Map<String, Integer> takenAreas, Map<String, String> takenClaims) {

        System.out.println("Puzzle 3B Solver");
        List<String> noConflictClaims = new ArrayList<String>();

        for (String claimId: takenClaims.keySet()) {
            Boolean claimHasConflicts = false;
            String[] areaIds = takenClaims.get(claimId).split(",");

            for (String id : areaIds) {
                if (takenAreas.get(id) > 1) {
                    claimHasConflicts = true;
                    break;
                }
            }
            if (!claimHasConflicts) {
                noConflictClaims.add(claimId);
            }
        }

        for (String claimId : noConflictClaims) {
            System.out.println(String.format("The claim %s has no conflicts.", claimId));
        }
    }
}
