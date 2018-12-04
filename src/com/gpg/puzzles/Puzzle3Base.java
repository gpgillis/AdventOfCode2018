package com.gpg.puzzles;

import java.util.ArrayList;
import java.util.Map;

/**
Advent Of Code Puzzle 3 BASE:
http://adventofcode.com/2018/day/3

*/
public abstract class Puzzle3Base extends PuzzleBase {

    protected boolean DataIsValid(ArrayList<String> inputData) {

        return ValidateMultiLineDataFile(inputData);
    }

    void RecordClaim(String claim, Map<String, Integer> takenAreas, Map<String, String> takenClaims) {
        String claimId = getClaimId(claim);

        System.out.println("Getting indexes and dimensions");
        String[] startIndexes = getIndexPoint(claim).split(",");
        String[] dimensions = getDimension(claim).split("x");

        System.out.println("Parsing integers for start x and y");
        Integer startX = Integer.parseInt(startIndexes[0]);
        Integer startY = Integer.parseInt(startIndexes[1]);

        //System.out.println(String.format("Processing claim areas startX = %d, startY = %d", startX, startY));
        System.out.println("Processing claim areas");

        for (Integer x = 1; x <= Integer.parseInt(dimensions[0]); x++) {
            for (Integer y = 1; y <= Integer.parseInt(dimensions[1]); y++) {
                String id = generateClaimIndexId(x + startX, y + startY);

                Integer claimCount = 1;
                if (takenAreas.containsKey(id)) {
                    claimCount = takenAreas.get(id) + 1;
                }
                takenAreas.put(id, claimCount);

                if (takenClaims.containsKey(claimId)) {
                    String prev = takenClaims.get(claimId);
                    takenClaims.put(claimId, String.format("%s,%s", prev, id));
                }
                else {
                    takenClaims.put(claimId, id);
                }
            }
        }
    }

    private static String generateClaimIndexId(Integer x, Integer y) {
        return String.format("%dx%d", x, y);
    }

    private static String getClaimId(String claim) {
        if (isStringNullOrEmpty(claim)) { return "INVALID"; }
        Integer endIndex = claim.indexOf("@");
        return claim.substring(1, endIndex).trim();
    }

    private static String getDimension(String claim) {
        if (isStringNullOrEmpty(claim)) { return "INVALID"; }

        Integer startIdx = claim.indexOf(":") + 1;

        return claim.substring((startIdx)).trim();
    }

    private static String getIndexPoint(String claim) {
        if (isStringNullOrEmpty(claim)) { return "INVALID"; }

        Integer startIdx = claim.indexOf("@") + 1;
        Integer endIdx = claim.indexOf(":");

        return claim.substring(startIdx, endIdx).trim();
    }
}
